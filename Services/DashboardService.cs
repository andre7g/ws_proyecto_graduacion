using ws_proyecto.Helpers;
using ws_proyecto.Interfaces;
using ws_proyecto.Models.Dashboard;

namespace ws_proyecto.Services
{
    public class DashboardService : IDashboard
    {
        private DataContext _context;
        public DashboardService(DataContext context)
        {
            _context = context;
        }
        public object getContadores()
        {
            DashboardContResponse data = new DashboardContResponse();
            int cont = 0;
            var usuarios_fecha = _context.Usuarios.Where(x => x.EstadosId == 1).Select(s => new { 
                s.Fecha_Inicio,
                s.Id
            }).ToList();

            foreach (var u in usuarios_fecha)
            {
                if (u.Fecha_Inicio.Year == System.DateTime.Now.Year)
                {
                    if (u.Fecha_Inicio.Month < System.DateTime.Now.Month)
                    {

                    }
                }


                if (u.Fecha_Inicio.Day > System.DateTime.Now.Day)
                {
                    var pago = _context.HistorialPagos.Where(x => x.EstadosId == 1 && x.UsuariosId == u.Id && x.Numero_mes == System.DateTime.Now.Month && x.Anio == System.DateTime.Now.Year).FirstOrDefault();
                    if (pago == null)
                    {
                        cont++;
                    }
                }
            }



            data.cont_usuarios = _context.Usuarios.Where(x => x.EstadosId == 1).ToList().Count();
            data.cont_dietas = _context.Dietas.Where(x => x.EstadosId == 1).ToList().Count();
            data.cont_rutinas = _context.Rutina.Where(x => x.EstadosId == 1).ToList().Count();

            data.cont_pendientes = 0;



            return data;
        }

        public object getGrafica()
        {
            throw new NotImplementedException();
        }

        public object getMejoresUsuarios()
        {
            var data = _context.Usuarios.Where(x => x.EstadosId == 1 && x.HistorialUsuarios.Count() > 0 ).Select(x => new
            {
                x.Id,
                nombre = x.Nombres + " " + x.Apellidos,
                x.Dpi,
                x.Telefono,
                x.Direccion,
                x.Codigo,
                x.Email,
                Fecha_Nacimiento = x.Fecha_Nacimiento.ToString("dd/MM/yyyy"),
                Fecha_Inicio = x.Fecha_Inicio.ToString("dd/MM/yyyy"),
                x.EstadosId,
                x.Estados.Estado,
                x.Genero,
                peso = _context.HistorialUsuarios.Where(h => h.UsuariosId == x.Id && h.EstadosId == 1).Select(s => s.Peso).FirstOrDefault(),
                altura = _context.HistorialUsuarios.Where(h => h.UsuariosId == x.Id && h.EstadosId == 1).Select(s => s.Altura).FirstOrDefault(),
                calorias = _context.HistorialUsuarios.Where(h => h.UsuariosId == x.Id && h.EstadosId == 1).Select(s => s.CaloriasConsumir).FirstOrDefault(),
                imc = _context.HistorialUsuarios.Where(h => h.UsuariosId == x.Id && h.EstadosId == 1).Select(s => s.IMC).FirstOrDefault(),
                sumatoria_rating = _context.HistorialUsuarios.Where(h => h.UsuariosId == x.Id).Sum(a => a.Rating),
                cantidad_rating = _context.HistorialUsuarios.Where(h => h.UsuariosId == x.Id).Count()

                //estado = x.Estados.Estado != null ? x.Estados.Estado : "null" 
            }).OrderByDescending(u => (u.sumatoria_rating));
            

            if (data.ToList().Count() == 0) throw new KeyNotFoundException("Usuarios no encontrados");
            return data.ToList().Take(5);
        }
    }
}
