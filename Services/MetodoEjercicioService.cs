using ws_proyecto.Helpers;
using ws_proyecto.Entities;
using ws_proyecto.Interfaces;

namespace ws_proyecto.Services
{
    public class MetodoEjercicioService : IMetodoEjercicio
    {
        private DataContext _context;
        public MetodoEjercicioService(DataContext context)
        {
            _context = context;
        }

        public void create(MetodoEjercicio _metodoejercicio)
        {
            MetodoEjercicio data = _context.MetodoEjercicio.Where(x => x.Nombre.ToUpper() == _metodoejercicio.Nombre.ToUpper() && x.EstadosId == 1).FirstOrDefault();

            if (data != null)
                throw new KeyNotFoundException("El método de ejercicio ya existe.");

            var correlativo = _context.MetodoEjercicio.Select(x => x.Id).ToList();

            if (correlativo.Count() == 0)
            {
                _metodoejercicio.Id = 1;
            }
            else
            {
                _metodoejercicio.Id = correlativo.Max() + 1;
            }

            try
            {
                _context.MetodoEjercicio.Add(_metodoejercicio);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new KeyNotFoundException("Ocurrio un error al registrar el método de ejercicio." + ex.Message);
            }
        }

        public object getAll()
        {
            return getMetodoEjercicio();
        }

        public object getAll(int EstadoId)
        {
            return getMetodoEjercicio(EstadoId);
        }

        public object getById(int Id)
        {
            MetodoEjercicio data = _context.MetodoEjercicio.Where(x => x.Id == Id).FirstOrDefault();
            if (data == null) throw new KeyNotFoundException("Método de ejercicio no encontrado");
            return data;
        }
        private object getMetodoEjercicio()
        {
            var data = _context.MetodoEjercicio.Select(x => new
            {
                x.Id,
                x.Nombre,
                x.EstadosId,
                x.Estados.Estado
            }).ToList();

            if (data == null) throw new KeyNotFoundException("Método de ejercicio no encontrado");
            return data;
        }
        private object getMetodoEjercicio(int estadosId)
        {
            var data = _context.MetodoEjercicio.Select(x => new
            {
                x.Id,
                x.Nombre,
                x.EstadosId,
                x.Estados.Estado

            });

            if (estadosId != 0)
            {
                data = data.Where(x => x.EstadosId == estadosId);
            }

            if (data.ToList().Count() == 0) throw new KeyNotFoundException("Método de ejercicio no encontrado");
            return data.ToList();
        }

        public void update(int id, MetodoEjercicio _metodoejercicio)
        {
            var metodoejercicio = _context.MetodoEjercicio.Find(id);

            if (metodoejercicio == null)
                throw new KeyNotFoundException("No se encontró el método de ejercicio seleccionado");

            MetodoEjercicio data = _context.MetodoEjercicio.Where(x => x.Id != id && x.Nombre.ToUpper() == _metodoejercicio.Nombre.ToUpper() && x.EstadosId == 1).FirstOrDefault();

            if (data != null)
                throw new KeyNotFoundException("El méodo de ejercicio ya existe.");

            metodoejercicio.Nombre = _metodoejercicio.Nombre;
            metodoejercicio.EstadosId = _metodoejercicio.EstadosId;

            try
            {
                _context.MetodoEjercicio.Update(metodoejercicio);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException("Ocurrio un error al registrar el método de ejercicio." + ex.Message);
            }
        }
    }
}
