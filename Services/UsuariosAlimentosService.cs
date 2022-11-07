using ws_proyecto.Entities;
using ws_proyecto.Helpers;
using ws_proyecto.Interfaces;
using ws_proyecto.Models.Alimentos;
using ws_proyecto.Models.Usuarios;

namespace ws_proyecto.Services
{
    public class UsuariosAlimentosService : IUsuariosAlimentos
    {
        private DataContext _context;
        public UsuariosAlimentosService(DataContext context)
        {
            _context = context;
        }
        public void create(AgregarAlimentoUsuario _alimentos)
        {
            AlimentosPorcion data = _context.AlimentosPorcion.Where(x => x.Id == _alimentos.AlimentoId).FirstOrDefault();
            if (data == null)
                throw new KeyNotFoundException("Alimento no encontrado.");

            decimal cantidad = Convert.ToDecimal(_alimentos.Cantidad);
            decimal kcal = Convert.ToDecimal(data.Energia_KcaL);
            decimal pro = Convert.ToDecimal(data.Proteina_g);
            decimal gra = Convert.ToDecimal(data.GrasaTotal_g);
            decimal carb = Convert.ToDecimal(data.Carbohidratos_g);

            UsuariosAlimentos newData = new UsuariosAlimentos();
            newData.Fecha_Consumo = System.DateTime.Now;
            newData.Cantidad = _alimentos.Cantidad;
            newData.Calorias = Decimal.Round(cantidad*kcal);
            newData.Proteina_g = Decimal.Round((pro*cantidad),2);
            newData.GrasaTotal_g = Decimal.Round((gra * cantidad),2);
            newData.Carbohidratos_g = Decimal.Round((carb * cantidad),2);
            newData.UsuariosId = _alimentos.UsuarioId;
            newData.AlimentosPorcionId = _alimentos.AlimentoId;
            newData.EstadosId = 1;

            try
            {
                _context.UsuariosAlimentos.Add(newData);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new KeyNotFoundException("Ocurrio un error al registrar los alimentos." + ex.Message);
            }
        }

        public object getByUsuario(int usuarioId)
        {
            var now = System.DateTime.Now.Date;
            var sis = _context.UsuariosAlimentos.Where(x => x.UsuariosId == usuarioId).Select(a => a.Fecha_Consumo.Date).FirstOrDefault();

            UsuarioAppResponse res = new UsuarioAppResponse();

            res.Proteinas = _context.UsuariosAlimentos.Where(x => x.UsuariosId == usuarioId && x.Fecha_Consumo.Date == now).Sum(a => a.Proteina_g);
            res.Grasas = _context.UsuariosAlimentos.Where(x => x.UsuariosId == usuarioId && x.Fecha_Consumo.Date == now).Sum(a => a.GrasaTotal_g);
            res.Carbohidratos = _context.UsuariosAlimentos.Where(x => x.UsuariosId == usuarioId && x.Fecha_Consumo.Date == now).Sum(a => a.Carbohidratos_g);
            res.KCal = _context.UsuariosAlimentos.Where(x => x.UsuariosId == usuarioId && x.Fecha_Consumo.Date == now).Sum(a => a.Calorias);

            res.Peso = _context.HistorialUsuarios.Where(x => x.UsuariosId == usuarioId && x.EstadosId == 1).Select( s => s.Peso ).FirstOrDefault();
            res.Altura = _context.HistorialUsuarios.Where(x => x.UsuariosId == usuarioId && x.EstadosId == 1).Select( s => s.Altura ).FirstOrDefault();
            res.Imc = _context.HistorialUsuarios.Where(x => x.UsuariosId == usuarioId && x.EstadosId == 1).Select( s => s.IMC ).FirstOrDefault();
            var sumatoria_rating = _context.HistorialUsuarios.Where(h => h.UsuariosId == usuarioId).Sum(a => a.Rating);
            var cantidad_rating = _context.HistorialUsuarios.Where(h => h.UsuariosId == usuarioId).Count();
            if (sumatoria_rating != 0 && cantidad_rating != 0)
            {
                res.Ranquin = Decimal.Round(sumatoria_rating / cantidad_rating);
                if (res.Ranquin < 1)
                {
                    res.Ranquin = 1;
                }

            }
            else
            {
                res.Ranquin = 1;

            }
            double imc = Decimal.ToDouble(res.Imc); 

            if (imc > 0 && imc < 18.5)
            {
                res.Tipo = "Bajo Peso";
            }
            else if (imc >= 18.5 && imc < 24.9)
            {
                res.Tipo = "Peso Normal";
            }
            else if (imc >= 25 && imc < 29.9)
            {
                res.Tipo = "Pre-obesidad o Sobrepeso";
            }
            else if (imc >= 30 && imc < 34.9)
            {
                res.Tipo = "Obesidad clase I";
            }
            else if (imc >= 35 && imc < 39.9)
            {
                res.Tipo = "Obesidad clase II";
            }
            else if (imc >= 40)
            {
                res.Tipo = "Obesidad clase III";
            }
            else
            {
                res.Tipo = "Sin control mensual";
            }

            return res;
        }
    }
}
