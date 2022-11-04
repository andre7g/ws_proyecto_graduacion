using ws_proyecto.Helpers;
using ws_proyecto.Interfaces;

namespace ws_proyecto.Services
{
    public class GruposAlimenticiosService : IGruposAlimenticios
    {
        private DataContext _context;
        public GruposAlimenticiosService(DataContext context)
        {
            _context = context;
        }
        public object getGruposAlimenticios()
        {
            var data = _context.GruposAlimenticios.Select(x => new
            {
                x.Id,
                x.Grupo
            }).ToList();
            if (data.Count == 0) throw new KeyNotFoundException("Grupos no encontrados.");
            return data;
        }
    }
}
