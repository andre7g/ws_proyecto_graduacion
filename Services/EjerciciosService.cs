using ws_proyecto.Helpers;
using ws_proyecto.Entities;
using ws_proyecto.Interfaces;

namespace ws_proyecto.Services
{
    public class EjerciciosService : IEjercicios
    {
        private DataContext _context;
        public EjerciciosService(DataContext context)
        {
            _context = context;
        }

        public void create(Ejercicios _ejercicio)
        {
            Ejercicios data = _context.Ejercicios.Where(x => x.Nombre.ToUpper() == _ejercicio.Nombre.ToUpper() && x.EstadosId == 1).FirstOrDefault();

            if (data != null)
                throw new KeyNotFoundException("El ejercicio ya existe.");

            var correlativo = _context.Ejercicios.Select(x => x.Id).ToList();

            if (correlativo.Count() == 0)
            {
                _ejercicio.Id = 1;
            }
            else
            {
                _ejercicio.Id = correlativo.Max() + 1;
            }

            try
            {
                _ejercicio.Nombre = _ejercicio.Nombre.ToUpper();
                _context.Ejercicios.Add(_ejercicio);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new KeyNotFoundException("Ocurrio un error al registrar el ejercicio." + ex.Message);
            }
        }

        public object getAll()
        {
            return getEjercicio();
        }

        public object getAll(int EstadoId)
        {
            return getEjercicio(EstadoId);
        }

        public object getById(int Id)
        {
            Ejercicios data = _context.Ejercicios.Where(x => x.Id == Id).FirstOrDefault();
            if (data == null) throw new KeyNotFoundException("Ejercicio no encontrado");
            return data;
        }
        private object getEjercicio()
        {
            var data = _context.Ejercicios.Select(x => new
            {
                x.Id,
                x.Nombre,
                x.Descripcion,
                x.Dificultad,
                x.EstadosId,
                x.Estados.Estado
            }).ToList();

            if (data == null) throw new KeyNotFoundException("Ejercicio no encontrado");
            return data;
        }
        private object getEjercicio(int estadosId)
        {
            var data = _context.Ejercicios.Select(x => new
            {
                x.Id,
                x.Nombre,
                x.Descripcion,
                x.Dificultad,
                x.EstadosId,
                x.Estados.Estado

            });

            if (estadosId != 0)
            {
                data = data.Where(x => x.EstadosId == estadosId);
            }

            if (data.ToList().Count() == 0) throw new KeyNotFoundException("Ejercicio no encontrado");
            return data.ToList();
        }

        public void update(int id, Ejercicios _ejercicio)
        {
            var ejercicio = _context.Ejercicios.Find(id);

            if (ejercicio == null)
                throw new KeyNotFoundException("No se encontró el ejercicio seleccionado");

            Ejercicios data = _context.Ejercicios.Where(x => x.Id != id && x.Nombre.ToUpper() == _ejercicio.Nombre.ToUpper() && x.EstadosId == 1).FirstOrDefault();

            if (data != null)
                throw new KeyNotFoundException("El ejercicio ya existe.");

            ejercicio.Nombre = _ejercicio.Nombre.ToUpper();
            ejercicio.Descripcion = _ejercicio.Descripcion;
            ejercicio.Dificultad = _ejercicio.Dificultad;
            ejercicio.EstadosId = _ejercicio.EstadosId;

            try
            {
                _context.Ejercicios.Update(ejercicio);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException("Ocurrio un error al registrar el ejercicio." + ex.Message);
            }
        }
    }
}
