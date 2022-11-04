using ws_proyecto.Helpers;
using ws_proyecto.Entities;
using ws_proyecto.Interfaces;
using ws_proyecto.Models.Dietas;
using ws_proyecto.Models.ResponseData;

namespace ws_proyecto.Services
{
    public class IngestasService : IIngestas
    {
        private DataContext _context;
        public IngestasService(DataContext context)
        {
            _context = context;
        }

        public void create(AgregarIngesta _ingestas)
        {
            int ingestaId = createIngesta(_ingestas);
            if (ingestaId != 0)
            {
                foreach (var i in _ingestas.ListaAlimentos)
                {
                    IngestaAlimentos alimento = new IngestaAlimentos();
                    alimento.Cantidad = i.Cantidad;
                    alimento.Proteina_g = i.Proteina_g;
                    alimento.GrasaTotal_g = i.GrasaTotal_g;
                    alimento.Carbohidratos_g = i.Carbohidratos_g;
                    alimento.Energia_KcaL = i.Energia_KcaL;
                    alimento.IngestasId = ingestaId;
                    alimento.AlimentosPorcionId = i.AlimentosPorcion_Id;
                    alimento.EstadosId = 1;
                    try
                    {
                        _context.IngestaAlimentos.Add(alimento);
                        _context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw new KeyNotFoundException("Ocurrio un error al registrar la ingesta." + ex.Message);
                    }

                }

            }

        }
        public int createIngesta(AgregarIngesta _ingestas)
        {
            int ingestaId = 0;
            var data = _context.Ingestas.Where(x => x.Nombre.ToUpper() == _ingestas.Nombre.ToUpper() && x.EstadosId == 1 && x.DietasId == _ingestas.DietasId).FirstOrDefault();
            if (data != null)
                throw new KeyNotFoundException("La ingesta con el nombre ingresado ya existe.");

            Ingestas nuevaIngesta = new Ingestas();
            nuevaIngesta.Nombre = _ingestas.Nombre;
            nuevaIngesta.Descripcion = _ingestas.Descripcion;
            nuevaIngesta.DietasId = _ingestas.DietasId;
            nuevaIngesta.EstadosId = 1;
            nuevaIngesta.Proteina_g = _ingestas.Proteina_g;
            nuevaIngesta.GrasaTotal_g = _ingestas.GrasaTotal_g;
            nuevaIngesta.Carbohidratos_g = _ingestas.Carbohidratos_g;
            nuevaIngesta.Energia_KcaL = _ingestas.Energia_KcaL;


            try
            {
                _context.Ingestas.Add(nuevaIngesta);
                _context.SaveChanges();
                ingestaId = nuevaIngesta.Id;
            }
            catch (Exception ex)
            {
                throw new KeyNotFoundException("Ocurrio un error al registrar la ingesta." + ex.Message);
            }
            return ingestaId;
        }
        public object getAll()
        {
            return getIngestas();
        }

        public object getAll(int dietasId)
        {
            return getIngestas(dietasId);
        }

        public object getById(int Id)
        {
            Ingestas data = _context.Ingestas.Where(x => x.Id == Id).FirstOrDefault();
            if (data == null) throw new KeyNotFoundException("Ingesta no encontrada");
            return data;
        }
        private object getIngestas()
        {
            var data = _context.Ingestas.Select(x => new
            {
                x.Id,
                x.Nombre,
                x.Descripcion,
                x.EstadosId,
                x.Estados.Estado,
                x.DietasId,
                Dietas = x.Dietas.Nombre
            }).ToList();

            if (data == null) throw new KeyNotFoundException("Ingesta no encontrada");
            return data;
        }
        private object getIngestas(int dietasId)
        {
            var data = _context.Ingestas.Select(x => new
            {
                x.Id,
                x.Nombre,
                x.Descripcion,
                x.EstadosId,
                x.Estados.Estado,
                x.DietasId,
                Dietas = x.Dietas.Nombre,
                x.Proteina_g,
                x.GrasaTotal_g,
                x.Carbohidratos_g,
                x.Energia_KcaL
            });

            data = data.Where(x => x.EstadosId == 1 && x.DietasId == dietasId);
            

            if (data.ToList().Count() == 0) throw new KeyNotFoundException("Ingesta no encontrada");
            return data.ToList();
        }

        public void update(int id, EliminarIngesta _ingestas)
        {
            var ingestas = _context.Ingestas.Find(id);

            if (ingestas == null)
                throw new KeyNotFoundException("No se encontró la ingesta seleccionada.");

            var alimentos = _context.IngestaAlimentos.Where(x => x.IngestasId == id).ToList();
            foreach (var i in alimentos)
            {
                updateAlimentosIngesta(i.Id);
            }

            ingestas.EstadosId = _ingestas.estadoId;

            try
            {
                _context.Ingestas.Update(ingestas);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException("Ocurrio un error al registrar el tipo de ingesta." + ex.Message);
            }
        }
        public void updateAlimentosIngesta(int id)
        {
            var alimento = _context.IngestaAlimentos.Find(id);
            alimento.EstadosId = 2;
            try
            {
                _context.IngestaAlimentos.Update(alimento);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException("Ocurrio un error al registrar el tipo de ingesta." + ex.Message);
            }
        }
    }
}
