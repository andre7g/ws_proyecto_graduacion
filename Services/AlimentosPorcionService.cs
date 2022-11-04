using ws_proyecto.Helpers;
using ws_proyecto.Interfaces;

namespace ws_proyecto.Services
{
    public class AlimentosPorcionService : IAlimentosPorcion
    {
        private DataContext _context;
        public AlimentosPorcionService(DataContext context)
        {
            _context = context;
        }
        public object getByGruposAlimenticios(int gruposAlimenticiosId)
        {
            
            var data = _context.AlimentosPorcion.Where(x => x.GruposAlimenticiosId == gruposAlimenticiosId && x.EstadosId == 1).Select(x => new
            {
                x.Id,
                text =  x.Porcion+" de " + x.Nombre + " - " + x.Energia_KcaL + "kcal.",
                x.Energia_KcaL,
                x.Proteina_g,
                x.GrasaTotal_g,
                x.Carbohidratos_g,
                x.Porcion,
                x.Nombre
            });
            return data;

        }
        public void calculosBd()
        {
            decimal proteinas = 0;
            decimal grasa = 0;
            decimal carbos = 0;
            decimal pesoAlimento = 0;
            decimal kcal = 0;


            var data = _context.AlimentosPorcion.Where(x => x.GruposAlimenticiosId == 1).ToList();
            foreach (var i in data)
            {
                var alimento = _context.Alimentos.Where(x => x.Codigo == i.CodigoAlimento).FirstOrDefault();

                if (alimento != null)
                {
                    proteinas = alimento.Proteina_g;
                    grasa = alimento.GrasaTotal_g;
                    carbos = alimento.Carbohidratos_g;
                    pesoAlimento = i.PesoGramos;

                    i.Proteina_g = Decimal.Round((pesoAlimento * (proteinas / 100)), 2);
                    i.GrasaTotal_g = Decimal.Round((pesoAlimento * (grasa / 100)), 2);
                    i.Carbohidratos_g = Decimal.Round((pesoAlimento * (carbos / 100)), 2);
                    kcal = Convert.ToDecimal(((i.Proteina_g * 4) + (i.GrasaTotal_g * 9) + (i.Carbohidratos_g * 4)));
                    i.Energia_KcaL = Decimal.Round(kcal);

                    _context.AlimentosPorcion.Update(i);
                    _context.SaveChanges();

                }
            }
        }

        public object getById(int Id)
        {
            var data = _context.AlimentosPorcion.Where(x => x.Id == Id).Select(x => new
            {
                x.Id,
                x.CodigoAlimento,
                x.Nombre,
                x.Porcion,
                x.PesoGramos,
                x.Proteina_g,
                x.GrasaTotal_g,
                x.Carbohidratos_g,
                x.Energia_KcaL,
                alimento = _context.Alimentos.Where(a => a.Codigo == x.CodigoAlimento).FirstOrDefault()
            }).FirstOrDefault();

            if (data == null) throw new KeyNotFoundException("Alimentos no encontrados");
            return data;
        }
    }
}
