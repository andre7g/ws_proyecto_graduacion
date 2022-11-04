using ws_proyecto.Entities;
using ws_proyecto.Helpers;
using ws_proyecto.Interfaces;

namespace ws_proyecto.Services
{
    public class UsuarioRutinaService : IUsuarioRutina
    {
        private DataContext _context;
        public UsuarioRutinaService(DataContext context)
        {
            _context = context;
        }
        public void create(UsuarioRutina _usuarioRutina)
        {
            UsuarioRutina data = _context.UsuarioRutina.Where(x => x.UsuariosId == _usuarioRutina.UsuariosId && x.OrdenDia == _usuarioRutina.OrdenDia && x.EstadosId == 1).FirstOrDefault();

            try
            {
                _usuarioRutina.EstadosId = 1;
                _context.UsuarioRutina.Add(_usuarioRutina);
                _context.SaveChanges();
                if (data != null)
                {
                    updateRutina(data.Id);
                }
            }
            catch (Exception ex)
            {
                throw new KeyNotFoundException("Ocurrio un error al registrar la dieta." + ex.Message);
            }
        }

        public object getAll()
        {
            throw new NotImplementedException();
        }

        public object getAll(int UsuarioId)
        {
            var data = _context.UsuarioRutina.Select(x => new
            {
                x.Id,
                x.Dia,
                x.OrdenDia,
                x.EstadosId,
                x.Estados.Estado,
                x.RutinaId,
                x.Rutina.Nombre,
                x.UsuariosId

            });

            if (UsuarioId != 0)
            {
                data = data.Where(x => x.UsuariosId == UsuarioId && x.EstadosId == 1);
            }

            if (data.ToList().Count() == 0) throw new KeyNotFoundException("Rutina no encontrada");
            return data.OrderBy(x => x.OrdenDia).ToList();
        }

        public object getById(int Id)
        {
            UsuarioRutina data = _context.UsuarioRutina.Where(x => x.Id == Id).FirstOrDefault();
            if (data == null) throw new KeyNotFoundException("Rutina no encontrada");
            return data;
        }

        public void update(int id, UsuarioRutina _usuarioRutina)
        {
            var rutina = _context.UsuarioRutina.Find(id);

            if (rutina == null)
                throw new KeyNotFoundException("No se encontró la rutina seleccionada");

            UsuarioRutina data = _context.UsuarioRutina.Where(x => x.Id != id && x.UsuariosId == _usuarioRutina.UsuariosId && x.OrdenDia == _usuarioRutina.OrdenDia && x.EstadosId == 1).FirstOrDefault();

            rutina.Dia = _usuarioRutina.Dia;
            rutina.OrdenDia = _usuarioRutina.OrdenDia;
            rutina.EstadosId = _usuarioRutina.EstadosId;
            rutina.RutinaId = _usuarioRutina.RutinaId;

            try
            {
                _context.UsuarioRutina.Update(rutina);
                _context.SaveChanges();
                if (data != null)
                {
                    updateRutina(data.Id);
                }
            }
            catch (Exception ex)
            {
                throw new AppException("Ocurrio un error al registrar la dieta." + ex.Message);
            }
        }
        public void updateRutina(int id)
        {
            var rutina = _context.UsuarioRutina.Find(id);

            if (rutina == null)
                throw new KeyNotFoundException("No se encontró la rutina seleccionada.");

            rutina.EstadosId = 2;

            try
            {
                _context.UsuarioRutina.Update(rutina);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException("Ocurrio un error al registrar la dieta." + ex.Message);
            }
        }

    }
}
