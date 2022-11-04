using ws_proyecto.Entities;
using ws_proyecto.Helpers;
using ws_proyecto.Interfaces;

namespace ws_proyecto.Services
{
    public class UnidadMedidasService : IUnidadMedidas
    {
        private DataContext _context;
        public UnidadMedidasService(DataContext context)
        {
            _context = context;
        }

        public void create(UnidadMedidas _unidadmedidas)
        {
            UnidadMedidas data = _context.UnidadMedidas.Where(x => x.Nombre.ToUpper() == _unidadmedidas.Nombre.ToUpper() && x.EstadosId == 1).FirstOrDefault();

            if (data != null)
                throw new KeyNotFoundException("La unidad de medida ya existe.");

            var correlativo = _context.UnidadMedidas.Select(x => x.Id).ToList();

            try
            {
                _context.UnidadMedidas.Add(_unidadmedidas);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new KeyNotFoundException("Ocurrio un error al registrar la unidad de medida." + ex.Message);
            }
        }

        public object getAll()
        {
            return getUnidadMedidas();
        }

        public object getAll(int EstadoId)
        {
            return getUnidadMedidas(EstadoId);
        }

        public object getById(int Id)
        {
            UnidadMedidas data = _context.UnidadMedidas.Where(x => x.Id == Id).FirstOrDefault();
            if (data == null) throw new KeyNotFoundException("Unidad de medida no encontrada");
            return data;
        }
        private object getUnidadMedidas()
        {
            var data = _context.UnidadMedidas.Select(x => new
            {
                x.Id,
                x.Nombre,
                x.EstadosId,
                x.Estados.Estado,
            }).ToList();

            if (data == null) throw new KeyNotFoundException("Unidad de medida no encontrada");
            return data;
        }
        private object getUnidadMedidas(int estadosId)
        {
            var data = _context.UnidadMedidas.Select(x => new
            {
                x.Id,
                x.Nombre,
                x.EstadosId,
                x.Estados.Estado,

            });

            if (estadosId != 0)
            {
                data = data.Where(x => x.EstadosId == estadosId);
            }

            if (data.ToList().Count() == 0) throw new KeyNotFoundException("Unidad de medida no encontrada");
            return data.ToList();
        }

        public void update(int id, UnidadMedidas _unidadmedidas)
        {
            var unidadmedidas = _context.UnidadMedidas.Find(id);

            if (unidadmedidas == null)
                throw new KeyNotFoundException("No se encontró la unidad de medida seleccionada");

            UnidadMedidas data = _context.UnidadMedidas.Where(x => x.Id != id && x.Nombre.ToUpper() == _unidadmedidas.Nombre.ToUpper() && x.EstadosId == 1).FirstOrDefault();

            if (data != null)
                throw new KeyNotFoundException("La unidad de medida ya existe.");

            unidadmedidas.Nombre = _unidadmedidas.Nombre;
            unidadmedidas.EstadosId = _unidadmedidas.EstadosId;

            try
            {
                _context.UnidadMedidas.Update(unidadmedidas);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException("Ocurrio un error al registrar la unidad de medida." + ex.Message);
            }
        }
    }
}
