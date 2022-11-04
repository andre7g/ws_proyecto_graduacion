using ws_proyecto.Helpers;
using ws_proyecto.Entities;
using ws_proyecto.Interfaces;

namespace ws_proyecto.Services
{
    public class RutinaService : IRutina
    {
        private DataContext _context;
        public RutinaService(DataContext context)
        {
            _context = context;
        }

        public void create(Rutina _rutina)
        {
            Rutina data = _context.Rutina.Where(x => x.Nombre.ToUpper() == _rutina.Nombre.ToUpper() && x.EstadosId == 1).FirstOrDefault();

            if (data != null)
                throw new KeyNotFoundException("El nombre de la rutina ya existe.");


            try
            {
                _rutina.Nombre = _rutina.Nombre.ToUpper();
                _context.Rutina.Add(_rutina);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new KeyNotFoundException("Ocurrio un error al registrar la rutina." + ex.Message);
            }
        }

        public object getAll()
        {
            return getRutina();
        }

        public object getAll(int EstadoId)
        {
            return getRutina(EstadoId);
        }

        public object getById(int Id)
        {
            Rutina data = _context.Rutina.Where(x => x.Id == Id).FirstOrDefault();
            if (data == null) throw new KeyNotFoundException("Rutina no encontrada");
            return data;
        }
        private object getRutina()
        {
            var data = _context.Rutina.Select(x => new
            {
                x.Id,
                x.Nombre,
                x.Descripcion,
                x.Dificultad,
                x.EstadosId,
                x.Estados.Estado,
            }).ToList();

            if (data == null) throw new KeyNotFoundException("Rutina no encontrada");
            return data;
        }
        private object getRutina(int estadosId)
        {
            var data = _context.Rutina.Select(x => new
            {
                x.Id,
                x.Nombre,
                x.Descripcion,
                x.Dificultad,
                x.EstadosId,
                x.Estados.Estado,

            });

            if (estadosId != 0)
            {
                data = data.Where(x => x.EstadosId == estadosId);
            }

            if (data.ToList().Count() == 0) throw new KeyNotFoundException("Rutina no encontrada");
            return data.ToList();
        }

        public void update(int id, Rutina _rutina)
        {
            var rutina = _context.Rutina.Find(id);

            if (rutina == null)
                throw new KeyNotFoundException("No se encontró la rutina seleccionada");

            Rutina data = _context.Rutina.Where(x => x.Nombre.ToUpper() == _rutina.Nombre.ToUpper() && x.EstadosId == 1 && x.Id != _rutina.Id).FirstOrDefault();

            if (data != null)
                throw new KeyNotFoundException("El nombre de la rutina ya existe.");

            rutina.Nombre = _rutina.Nombre.ToUpper();
            rutina.Descripcion = _rutina.Descripcion;
            rutina.Dificultad = _rutina.Dificultad;
            rutina.EstadosId = _rutina.EstadosId;

            try
            {
                _context.Rutina.Update(rutina);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException("Ocurrio un error al registrar la rutina." + ex.Message);
            }
        }
    }
}
