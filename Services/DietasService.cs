using ws_proyecto.Helpers;
using ws_proyecto.Entities;
using ws_proyecto.Interfaces;

namespace ws_proyecto.Services
{
    public class DietasService : IDietas
    {
        private DataContext _context;
        public DietasService(DataContext context)
        {
            _context = context;
        }

        public void create(Dietas _dietas)
        {
            Dietas data = _context.Dietas.Where(x => x.Nombre.ToUpper() == _dietas.Nombre.ToUpper() && x.Descripcion.ToUpper() == _dietas.Descripcion.ToUpper() && x.EstadosId == 1).FirstOrDefault();

            if (data != null)
                throw new KeyNotFoundException("La dieta ya existe.");

            try
            {
                _dietas.Nombre = _dietas.Nombre.ToUpper();
                _context.Dietas.Add(_dietas);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new KeyNotFoundException("Ocurrio un error al registrar la dieta." + ex.Message);
            }
        }

        public object getAll()
        {
            return getDietas();
        }

        public object getAll(int EstadoId)
        {
            return getDietas(EstadoId);
        }

        public object getById(int Id)
        {
            Dietas data = _context.Dietas.Where(x => x.Id == Id).FirstOrDefault();
            if (data == null) throw new KeyNotFoundException("Dieta no encontrada");
            return data;
        }
        private object getDietas()
        {
            var data = _context.Dietas.Select(x => new
            {
                x.Id,
                x.Nombre,
                x.Descripcion,
                x.EstadosId,
                x.Estados.Estado,
                x.TiposDietasId,
                x.TiposDietas.Tipo
            }).ToList();

            if (data.Count == 0) throw new KeyNotFoundException("Dieta no encontrada");
            return data;
        }
        private object getDietas(int estadosId)
        {
            var data = _context.Dietas.Select(x => new
            {
                x.Id,
                x.Nombre,
                x.Descripcion,
                x.EstadosId,
                x.Estados.Estado,
                x.TiposDietasId,
                x.TiposDietas.Tipo

            });

            if (estadosId != 0)
            {
                data = data.Where(x => x.EstadosId == estadosId);
            }

            if (data.Count() == 0) throw new KeyNotFoundException("Dieta no encontrada");
            return data.ToList();
        }

        public void update(int id, Dietas _dietas)
        {
            var dietas = _context.Dietas.Find(id);

            if (dietas == null)
                throw new KeyNotFoundException("No se encontró la dieta seleccionada");

            Dietas data = _context.Dietas.Where(x => x.Id != id && x.Nombre.ToUpper() == _dietas.Nombre.ToUpper() && x.Descripcion.ToUpper() == _dietas.Descripcion.ToUpper() && x.EstadosId == 1).FirstOrDefault();

            if (data != null)
                throw new KeyNotFoundException("La dieta ya existe.");

            dietas.Nombre = _dietas.Nombre.ToUpper();
            dietas.Descripcion = _dietas.Descripcion;
            dietas.EstadosId = _dietas.EstadosId;
            dietas.TiposDietasId = _dietas.TiposDietasId;

            try
            {
                _context.Dietas.Update(dietas);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException("Ocurrio un error al registrar la dieta." + ex.Message);
            }
        }
    }
}
