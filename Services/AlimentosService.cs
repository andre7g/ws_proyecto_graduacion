using ws_proyecto.Entities;
using ws_proyecto.Helpers;
using ws_proyecto.Interfaces;

namespace ws_proyecto.Services
{
    public class AlimentosService : IAlimentos
    {
        private DataContext _context;
        public AlimentosService(DataContext context)
        {
            _context = context;
        }

        public void create(Alimentos _alimentos)
        {
            Alimentos data = _context.Alimentos.Where(x => x.Nombre.ToUpper() == _alimentos.Nombre.ToUpper() && x.EstadosId == 1).FirstOrDefault();

            if (data != null)
                throw new KeyNotFoundException("Los alimentos ya existen.");

            var correlativo = _context.Alimentos.Select(x => x.Id).ToList();

            try
            {
                _context.Alimentos.Add(_alimentos);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new KeyNotFoundException("Ocurrio un error al registrar los alimentos." + ex.Message);
            }
        }

        public object getAll()
        {
            return getAlimentos();
        }

        public object getByGruposAlimenticios(int GruposAlimenticiosId)
        {
            return getAlimentos(GruposAlimenticiosId);
        }

        public object getById(int Id)
        {
            Alimentos data = _context.Alimentos.Where(x => x.Id == Id).FirstOrDefault();
            if (data == null) throw new KeyNotFoundException("Alimentos no encontrados");
            return data;
        }
        private object getAlimentos()
        {
            var data = _context.Alimentos.Select(x => new
            {
                x.Id,
                x.Codigo,
                x.Nombre,
                x.AguaPorcentaje,
                x.Energia_KcaL,
                x.Proteina_g,
                x.GrasaTotal_g,
                x.Carbohidratos_g,
                x.FibraDietTotal_g,
                x.Ceniza_g,
                x.Calcio_mg,
                x.Fosforo_mg,
                x.Hierro_mg,
                x.Tiamina_mg,
                x.Riboflavina_mg,
                x.Niacina_mg,
                x.VitC_mg,
                x.VitAEquivRetinol_mcg,
                x.AcGrasasMonoInsat_g,
                x.AcGrasasPoliInsat_g,
                x.AcGrasasSaturadas_g,
                x.Colesterol_mg,
                x.Potasio_mg,
                x.Sodio_mg,
                x.Zinc_mg,
                x.Magnecio_mg,
                x.VitB6_mg,
                x.VitB12_mcg,
                x.AcFolico_mcg,
                x.FolatoEquivFD_mcg,
                x.FraccionComestible,
                x.EstadosId,
                x.Estados.Estado,
                x.GruposAlimenticiosId,
                x.GruposAlimenticios.Grupo
            }).ToList();

            if (data == null) throw new KeyNotFoundException("Alimentos no encontrados");
            return data;
        }
        private object getAlimentos(int GruposAlimeticiosId)
        {
            var data = _context.Alimentos.Select(x => new
            {
                x.Id,
                x.Codigo,
                x.Nombre,
                x.AguaPorcentaje,
                x.Energia_KcaL,
                x.Proteina_g,
                x.GrasaTotal_g,
                x.Carbohidratos_g,
                x.FibraDietTotal_g,
                x.Ceniza_g,
                x.Calcio_mg,
                x.Fosforo_mg,
                x.Hierro_mg,
                x.Tiamina_mg,
                x.Riboflavina_mg,
                x.Niacina_mg,
                x.VitC_mg,
                x.VitAEquivRetinol_mcg,
                x.AcGrasasMonoInsat_g,
                x.AcGrasasPoliInsat_g,
                x.AcGrasasSaturadas_g,
                x.Colesterol_mg,
                x.Potasio_mg,
                x.Sodio_mg,
                x.Zinc_mg,
                x.Magnecio_mg,
                x.VitB6_mg,
                x.VitB12_mcg,
                x.AcFolico_mcg,
                x.FolatoEquivFD_mcg,
                x.FraccionComestible,
                x.EstadosId,
                x.Estados,
                x.GruposAlimenticiosId,
                x.GruposAlimenticios

            });

            if (GruposAlimeticiosId != 0)
            {
                data = data.Where(x => x.GruposAlimenticiosId == GruposAlimeticiosId && x.EstadosId == 1);
            }

            if (data.ToList().Count() == 0) throw new KeyNotFoundException("Alimentos no encontrados");
            return data.ToList();
        }

        public void update(int id, Alimentos _alimentos)
        {
            var alimentos = _context.Alimentos.Find(id);

            if (alimentos == null)
                throw new KeyNotFoundException("No se encontraron los alimentos seleccionados");

            Alimentos data = _context.Alimentos.Where(x => x.Id != id && x.Nombre.ToUpper() == _alimentos.Nombre.ToUpper() && x.EstadosId == 1).FirstOrDefault();

            alimentos.Codigo = _alimentos.Codigo;
            alimentos.Nombre = _alimentos.Nombre;
            alimentos.AguaPorcentaje = _alimentos.AguaPorcentaje;
            alimentos.Energia_KcaL = _alimentos.Energia_KcaL;
            alimentos.Proteina_g = _alimentos.Proteina_g;
            alimentos.GrasaTotal_g = _alimentos.GrasaTotal_g;
            alimentos.Carbohidratos_g = _alimentos.Carbohidratos_g;
            alimentos.FibraDietTotal_g = _alimentos.FibraDietTotal_g;
            alimentos.Ceniza_g = _alimentos.Ceniza_g;
            alimentos.Calcio_mg = _alimentos.Calcio_mg;
            alimentos.Fosforo_mg = _alimentos.Fosforo_mg;
            alimentos.Hierro_mg = _alimentos.Hierro_mg;
            alimentos.Tiamina_mg = _alimentos.Tiamina_mg;
            alimentos.Riboflavina_mg = _alimentos.Riboflavina_mg;
            alimentos.Niacina_mg = _alimentos.Niacina_mg;
            alimentos.VitC_mg = _alimentos.VitC_mg;
            alimentos.VitAEquivRetinol_mcg = _alimentos.VitAEquivRetinol_mcg;
            alimentos.AcGrasasMonoInsat_g = _alimentos.AcGrasasMonoInsat_g;
            alimentos.AcGrasasPoliInsat_g = _alimentos.AcGrasasPoliInsat_g;
            alimentos.AcGrasasSaturadas_g = _alimentos.AcGrasasSaturadas_g;
            alimentos.Colesterol_mg = _alimentos.Colesterol_mg;
            alimentos.Potasio_mg = _alimentos.Potasio_mg;
            alimentos.Sodio_mg = _alimentos.Sodio_mg;
            alimentos.Zinc_mg = _alimentos.Zinc_mg;
            alimentos.Magnecio_mg = _alimentos.Magnecio_mg;
            alimentos.VitB6_mg = _alimentos.VitB6_mg;
            alimentos.VitB12_mcg = _alimentos.VitB12_mcg;
            alimentos.AcFolico_mcg = _alimentos.AcFolico_mcg;
            alimentos.FolatoEquivFD_mcg = _alimentos.FolatoEquivFD_mcg;
            alimentos.FraccionComestible = _alimentos.FraccionComestible;
            alimentos.EstadosId = _alimentos.EstadosId;
            alimentos.GruposAlimenticiosId = _alimentos.GruposAlimenticiosId;

            try
            {
                _context.Alimentos.Update(alimentos);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException("Ocurrio un error al registrar los alimentos." + ex.Message);
            }
        }
    }
}
