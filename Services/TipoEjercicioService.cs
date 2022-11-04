using ws_proyecto.Helpers;
using ws_proyecto.Entities;
using ws_proyecto.Interfaces;

namespace ws_proyecto.Services
{
    public class TipoEjercicioService : ITipoEjercicio
    {
        private DataContext _context;
        public TipoEjercicioService(DataContext context)
        {
            _context = context;
        }

        public void create(TipoEjercicio _tipoejercicio)
        {
            TipoEjercicio data = _context.TipoEjercicio.Where(x => x.Tipo.ToUpper() == _tipoejercicio.Tipo.ToUpper() && x.EstadosId == 1).FirstOrDefault();

            if (data != null)
                throw new KeyNotFoundException("El tipo de ejercicio ya existe.");

            var correlativo = _context.TipoEjercicio.Select(x => x.Id).ToList();

            if (correlativo.Count() == 0)
            {
                _tipoejercicio.Id = 1;
            }
            else
            {
                _tipoejercicio.Id = correlativo.Max() + 1;
            }

            try
            {
                _context.TipoEjercicio.Add(_tipoejercicio);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new KeyNotFoundException("Ocurrio un error al registrar el tipo de ejercicio." + ex.Message);
            }
        }

        public object getAll()
        {
            return getTipoEjercicio();
        }

        public object getAll(int EstadoId)
        {
            return getTipoEjercicio(EstadoId);
        }

        public object getById(int Id)
        {
            TipoEjercicio data = _context.TipoEjercicio.Where(x => x.Id == Id).FirstOrDefault();
            if (data == null) throw new KeyNotFoundException("Tipo de ejercicio no encontrado");
            return data;
        }
        private object getTipoEjercicio()
        {
            var data = _context.TipoEjercicio.Select(x => new
            {
                x.Id,
                x.Tipo,
                x.EstadosId,
                x.Estados.Estado
            }).ToList();

            if (data == null) throw new KeyNotFoundException("Tipo de ejercicio no encontrado");
            return data;
        }
        private object getTipoEjercicio(int estadosId)
        {
            var data = _context.TipoEjercicio.Select(x => new
            {
                x.Id,
                x.Tipo,
                x.EstadosId,
                x.Estados.Estado

            });

            if (estadosId != 0)
            {
                data = data.Where(x => x.EstadosId == estadosId);
            }

            if (data.ToList().Count() == 0) throw new KeyNotFoundException("Tipo de ejercicio no encontrado");
            return data.ToList();
        }

        public void update(int id, TipoEjercicio _tipoejercicio)
        {
            var ejercicio = _context.TipoEjercicio.Find(id);

            if (ejercicio == null)
                throw new KeyNotFoundException("No se encontró el tipo de ejercicio seleccionado");

            TipoEjercicio data = _context.TipoEjercicio.Where(x => x.Id != id && x.Tipo.ToUpper() == _tipoejercicio.Tipo.ToUpper() && x.EstadosId == 1).FirstOrDefault();

            if (data != null)
                throw new KeyNotFoundException("El tipo de ejercicio ya existe.");

            ejercicio.Tipo = _tipoejercicio.Tipo;
            ejercicio.EstadosId = _tipoejercicio.EstadosId;

            try
            {
                _context.TipoEjercicio.Update(ejercicio);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException("Ocurrio un error al registrar el tipo de ejercicio." + ex.Message);
            }
        }
    }
}
