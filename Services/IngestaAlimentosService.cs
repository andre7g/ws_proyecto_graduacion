using ws_proyecto.Entities;
using ws_proyecto.Helpers;
using ws_proyecto.Interfaces;

namespace ws_proyecto.Services
{
    public class IngestaAlimentosService : IIngestaAlimentos
    {
        private DataContext _context;
        public IngestaAlimentosService(DataContext context)
        {
            _context = context;
        }

        public void create(IngestaAlimentos _ingestaAlimentos)
        {
            IngestaAlimentos data = _context.IngestaAlimentos.Where(x => x.Cantidad == _ingestaAlimentos.Cantidad && x.EstadosId == 1).FirstOrDefault();

            if (data != null)
                throw new KeyNotFoundException("La ingesta de alimentos ya existe.");

            var correlativo = _context.IngestaAlimentos.Select(x => x.Id).ToList();

            try
            {
                _context.IngestaAlimentos.Add(_ingestaAlimentos);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new KeyNotFoundException("Ocurrio un error al registrar la ingesta de alimentos." + ex.Message);
            }
        }

        public object getAll()
        {
            return getIngestaAlimentos();
        }

        public object getAll(int EstadoId)
        {
            return getIngestaAlimentos(EstadoId);
        }

        public object getById(int Id)
        {
            IngestaAlimentos data = _context.IngestaAlimentos.Where(x => x.Id == Id).FirstOrDefault();
            if (data == null) throw new KeyNotFoundException("Ingesta de alimentos no encontrada");
            return data;
        }
        private object getIngestaAlimentos()
        {
            var data = _context.IngestaAlimentos.Select(x => new
            {
                x.Id,
                x.Cantidad,
                x.Carbohidratos_g,
                x.Proteina_g,
                x.GrasaTotal_g,
                x.EstadosId,
                x.Estados.Estado,
                x.IngestasId,
                x.Ingestas.Nombre,
                x.AlimentosPorcionId,
               Alimentos = x.AlimentosPorcion.Nombre
            }).ToList();

            if (data == null) throw new KeyNotFoundException("Ingesta de alimentos no encontrada");
            return data;
        }
        private object getIngestaAlimentos(int ingestaId)
        {
            var data = _context.IngestaAlimentos.Select(x => new
            {
                x.Id,
                x.Cantidad,
                x.Carbohidratos_g,
                x.Proteina_g,
                x.GrasaTotal_g,
                x.Energia_KcaL,
                x.EstadosId,
                x.Estados.Estado,
                x.IngestasId,
                x.Ingestas.Nombre,
                x.AlimentosPorcionId,
                Alimento = x.AlimentosPorcion.Porcion+ " de " +x.AlimentosPorcion.Nombre,
                nombre_alimento = x.AlimentosPorcion.Nombre,
                porcion_alimento = x.AlimentosPorcion.Porcion


            });


            data = data.Where(x => x.EstadosId == 1 && x.IngestasId == ingestaId);
            

            if (data.ToList().Count() == 0) throw new KeyNotFoundException("Ingesta de alimentos no encontrada");
            return data.ToList();
        }

        public void update(int id, IngestaAlimentos _ingestaAlimentos)
        {
            var ingesta = _context.IngestaAlimentos.Find(id);

            if (ingesta == null)
                throw new KeyNotFoundException("No se encontró la ingesta de alimentos seleccionada");

            IngestaAlimentos data = _context.IngestaAlimentos.Where(x => x.Id != id && x.Cantidad == _ingestaAlimentos.Cantidad && x.EstadosId == 1).FirstOrDefault();

            ingesta.Cantidad = _ingestaAlimentos.Cantidad;
            ingesta.Carbohidratos_g = _ingestaAlimentos.Carbohidratos_g;
            ingesta.Proteina_g = _ingestaAlimentos.Proteina_g;
            ingesta.GrasaTotal_g = _ingestaAlimentos.GrasaTotal_g;
            ingesta.EstadosId = _ingestaAlimentos.EstadosId;
            ingesta.IngestasId = _ingestaAlimentos.IngestasId;
            ingesta.AlimentosPorcionId = _ingestaAlimentos.AlimentosPorcionId;

            try
            {
                _context.IngestaAlimentos.Update(ingesta);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException("Ocurrio un error al registrar la ingesta de alimentos." + ex.Message);
            }
        }
    }
}
