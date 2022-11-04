using ws_proyecto.Entities;
using ws_proyecto.Helpers;
using ws_proyecto.Interfaces;

namespace ws_proyecto.Services
{
    public class UsuarioDietasService : IUsuarioDietas
    {
        private DataContext _context;
        public UsuarioDietasService(DataContext context)
        {
            _context = context;
        }

        public void create(UsuarioDietas _usuariodietas)
        {
            UsuarioDietas data = _context.UsuarioDietas.Where(x => x.DietasId == _usuariodietas.DietasId && x.UsuariosId == _usuariodietas.UsuariosId && x.EstadosId == 1).FirstOrDefault();

            if (data != null)
                throw new KeyNotFoundException("El usuario ya cuenta con la dieta seleccionada.");

            try
            {
                _context.UsuarioDietas.Add(_usuariodietas);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new KeyNotFoundException("Ocurrio un error al registrar el usuario de dietas." + ex.Message);
            }
        }

        public object getAll()
        {
            return getUsuarioDietas();
        }

        public object getAll(int usuarioId)
        {
            return getUsuarioDietas(usuarioId);
        }

        public object getById(int Id)
        {
            UsuarioDietas data = _context.UsuarioDietas.Where(x => x.Id == Id).FirstOrDefault();
            if (data == null) throw new KeyNotFoundException("Dieta no encontrada");
            return data;
        }
        private object getUsuarioDietas()
        {
            var data = _context.UsuarioDietas.Select(x => new
            {
                x.Id,
                x.EstadosId,
                x.Estados.Estado,
                x.DietasId,
                x.Dietas.Nombre,
                x.UsuariosId,
                Usuarios = x.Usuarios.Id
            }).ToList();

            if (data == null) throw new KeyNotFoundException("Dieta no encontrada");
            return data;
        }
        private object getUsuarioDietas(int usuarioId)
        {
            var data = _context.UsuarioDietas.Select(x => new
            {
                x.Id,
                x.EstadosId,
                x.Estados.Estado,
                x.DietasId,
                x.Dietas.Nombre,
                x.UsuariosId,
            });

            data = data.Where(x => x.EstadosId == 1 && x.UsuariosId == usuarioId);
            

            if (data.ToList().Count() == 0) throw new KeyNotFoundException("Dieta no encontrada");
            return data.ToList();
        }

        public void update(int id, UsuarioDietas _usuariodietas)
        {
            var usuariodietas = _context.UsuarioDietas.Find(id);

            if (usuariodietas == null)
                throw new KeyNotFoundException("No se encontró la dieta seleccionada.");

            UsuarioDietas data = _context.UsuarioDietas.Where(x => x.Id != id && x.DietasId == _usuariodietas.DietasId && x.EstadosId == 1).FirstOrDefault();
            if (data != null)
                throw new KeyNotFoundException("El usuario ya cuenta con la dieta seleccionada.");

            usuariodietas.EstadosId = _usuariodietas.EstadosId;
            usuariodietas.DietasId = _usuariodietas.DietasId;
            usuariodietas.UsuariosId = _usuariodietas.UsuariosId;

            try
            {
                _context.UsuarioDietas.Update(usuariodietas);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException("Ocurrio un error al registrar el usuario de dietas." + ex.Message);
            }
        }
    }
}
