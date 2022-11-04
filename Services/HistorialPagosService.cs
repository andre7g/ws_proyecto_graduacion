using ws_proyecto.Entities;
using ws_proyecto.Helpers;
using ws_proyecto.Interfaces;
using ws_proyecto.Models.Usuarios;

namespace ws_proyecto.Services
{
    public class HistorialPagosService : IHistorialPagos
    {
        private DataContext _context;
        public HistorialPagosService(DataContext context)
        {
            _context = context;
        }
        public void create(HistorialPagos _historial)
        {
            var historial = _context.HistorialPagos.Where(x => x.UsuariosId == _historial.UsuariosId && x.EstadosId == 1 && x.Mes == _historial.Mes && x.Anio == _historial.Anio).FirstOrDefault();
            if (historial != null)
                throw new KeyNotFoundException("Y a se realizó el pado de este mes.");

            try
            {
                _historial.FechaPago = System.DateTime.Now;
                _context.HistorialPagos.Add(_historial);
                _context.SaveChanges();
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

        public object getAll(int usuarioId)
        {
            return getHistorialPagosByUsuario(usuarioId);
        }

        public object getById(int Id)
        {
            throw new NotImplementedException();
        }
        private object getHistorialPagosByUsuario(int usuarioId)
        {
            var data = _context.HistorialPagos.Select(x => new
            {
                x.Id,
                x.Mes,
                x.Anio,
                FechaPago = x.FechaPago.ToString("dd/MM/yyyy"),
                x.EstadosId,
                x.Estados.Estado,
                x.UsuariosId
            });

            data = data.Where(x => x.EstadosId == 1 && x.UsuariosId == usuarioId);
            

            if (data.Count() == 0) throw new KeyNotFoundException("Historial pagos de usuario no encontrado.");
            return data.ToList();
        }
        public void update(int id, EliminarPago _historial)
        {
            var pago = _context.HistorialPagos.Find(id);

            if (pago == null)
                throw new KeyNotFoundException("No se encontró el historial de pago.");

            pago.EstadosId = _historial.estadoId;

            try
            {
                _context.HistorialPagos.Update(pago);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException("Ocurrio un error al registrar el tipo de ingesta." + ex.Message);
            }
        }
    }
}
