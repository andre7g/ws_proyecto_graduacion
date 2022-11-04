using ws_proyecto.Helpers;
using ws_proyecto.Entities;
using ws_proyecto.Interfaces;

namespace ws_proyecto.Services
{
    public class HistorialUsuariosService : IHistorialUsuarios
    {
        private DataContext _context;
        public HistorialUsuariosService(DataContext context)
        {
            _context = context;
        }
        public void create(HistorialUsuarios _historialUsuarios)
        {
            var historial = _context.HistorialUsuarios.Where(x => x.UsuariosId == _historialUsuarios.UsuariosId && x.EstadosId == 1).FirstOrDefault();
            if (historial != null)
            {
                updateEstadoHistorial(historial.Id);
            }
            try
            {
                _historialUsuarios.Fecha = System.DateTime.Now;
                _context.HistorialUsuarios.Add(_historialUsuarios);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new KeyNotFoundException("Ocurrio un error alcrear el control de usuario." + ex.Message);
            }
        }

        public object getAllByUsuario(int UsuarioId)
        {
            var data = _context.HistorialUsuarios.Where(x => x.UsuariosId == UsuarioId && x.EstadosId != 3).Select(x => new
            {
                x.Id,
                fecha = x.Fecha.ToString("dd/MM/yyyy"),
                peso = x.Peso + " lb",
                altura = x.Altura + " cm",
                x.IMC,
                x.CaloriasConsumir,
                x.Rating,
                x.EstadosId,
                x.UsuariosId
            }).OrderByDescending(x => x.Id).ToList();

            if (data.ToList().Count() == 0) throw new KeyNotFoundException("Historial Usuario no encontrados");
            return data.ToList();
        }

        public object getById(int Id)
        {
            var data = _context.HistorialUsuarios
            .Where(x => x.Id == Id).FirstOrDefault();

            if (data == null) throw new KeyNotFoundException("Historial no encontrado.");

            return data;
        }

        public void update(int id, HistorialUsuarios _historialUsuarios)
        {
            throw new NotImplementedException();
        }
        public void updateEstadoHistorial(int id)
        {
            var historial = _context.HistorialUsuarios.Find(id);

            historial.EstadosId = 2;
            try
            {
                _context.HistorialUsuarios.Update(historial);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException("Ocurrio un error al actualizar el Acuerdo Ministerial. " + ex.Message);
            }
        }
    }
}
