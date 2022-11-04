using ws_proyecto.Helpers;
using ws_proyecto.Entities;
using ws_proyecto.Interfaces;

namespace ws_proyecto.Services
{
    public class TiposDietaService : ITiposDieta
    {
        private DataContext _context;
        public TiposDietaService(DataContext context)
        {
            _context = context;
        }

        public void create(TiposDietas _tiposdieta)
        {
            TiposDietas data = _context.TiposDietas.Where(x => x.Tipo.ToUpper() == _tiposdieta.Tipo.ToUpper() && x.EstadosId == 1).FirstOrDefault();

            if (data != null)
                throw new KeyNotFoundException("El tipo de dieta ya existe.");

            var correlativo = _context.TiposDietas?.Select(x => x.Id).ToList();

            try
            {
                _context.TiposDietas?.Add(_tiposdieta);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new KeyNotFoundException("Ocurrio un error al registrar el tipo de dieta." + ex.Message);
            }
        }

        public object getAll()
        {
            return getTiposDieta();
        }

        public object getAll(int EstadoId)
        {
            return getTiposDieta(EstadoId);
        }

        public object getById(int Id)
        {
            TiposDietas data = _context.TiposDietas.Where(x => x.Id == Id).FirstOrDefault();
            if (data == null) throw new KeyNotFoundException("Tipo de dieta no encontrada");
            return data;
        }
        private object getTiposDieta()
        {
            var data = _context.TiposDietas?.Select(x => new
            {
                x.Id,
                x.Tipo,
                x.EstadosId,
                x.Estados.Estado,
            }).ToList();

            if (data == null) throw new KeyNotFoundException("Tipo de dieta no encontrada");
            return data;
        }
        private object getTiposDieta(int estadosId)
        {
            var data = _context.TiposDietas.Select(x => new
            {
                x.Id,
                x.Tipo,
                x.EstadosId,
                x.Estados.Estado,

            });

            if (estadosId != 0)
            {
                data = data.Where(x => x.EstadosId == estadosId);
            }

            if (data.ToList().Count() == 0) throw new KeyNotFoundException("Tipo de dieta no encontrada");
            return data.ToList();
        }

        public void update(int id, TiposDietas _tiposdieta)
        {
            var tipos = _context.TiposDietas?.Find(id);

            if (tipos == null)
                throw new KeyNotFoundException("No se encontró el tipo de dieta seleccionado");

            TiposDietas data = _context.TiposDietas.Where(x => x.Id != id && x.Tipo.ToUpper() == _tiposdieta.Tipo.ToUpper() && x.EstadosId == 1).FirstOrDefault();

            if (data != null)
                throw new KeyNotFoundException("El tipo de dieta ya existe.");

            tipos.Tipo = _tiposdieta.Tipo;
            tipos.EstadosId = _tiposdieta.EstadosId;

            try
            {
                _context.TiposDietas.Update(tipos);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException("Ocurrio un error al registrar el tipo de dieta." + ex.Message);
            }
        }
    }
}
