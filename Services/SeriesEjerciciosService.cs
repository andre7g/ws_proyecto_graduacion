using ws_proyecto.Entities;
using ws_proyecto.Helpers;
using ws_proyecto.Interfaces;

namespace ws_proyecto.Services
{
    public class SeriesEjerciciosService : ISeriesEjercicios
    {
        private DataContext _context;
        public SeriesEjerciciosService(DataContext context)
        {
            _context = context;
        }
        public void create(SeriesEjercicios _seriesEjercicios)
        {
            var data = _context.SeriesEjercicios.Where(x => x.EstadosId == 1 && x.EjerciciosId == _seriesEjercicios.EjerciciosId && x.MetodoEjercicioId == _seriesEjercicios.MetodoEjercicioId && x.SeriesId == _seriesEjercicios.SeriesId).FirstOrDefault();
            if (data != null)
                throw new KeyNotFoundException("Ya existe el ejerciocio seleccionado con el método seleccionado.");

            try
            {
                _seriesEjercicios.EjerciciosId = 1;
                _context.SeriesEjercicios.Add(_seriesEjercicios);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new KeyNotFoundException("Ocurrio un error al registrar la dieta." + ex.Message);
            }
        }

        public object getAll()
        {
            throw new NotImplementedException();
        }

        public object getAll(int SerieId)
        {
            var data = _context.SeriesEjercicios.Select(x => new
            {
                x.Id,
                x.SeriesId,
                x.EjerciciosId,
                x.Ejercicios.Nombre,
                desEjercicio = x.Ejercicios.Descripcion,
                x.Repeticiones,
                peso = x.PesoLb+"lbs",
                x.EstadosId,
                x.Estados.Estado,
                x.MetodoEjercicioId,
                metodo = x.MetodoEjercicio.Nombre,
                desEjercicioSerie = x.Descripcion,
                tiempo = x.TiempoMinutos+" minutos"

            });

            if (SerieId != 0)
            {
                data = data.Where(x => x.SeriesId == SerieId && x.EstadosId == 1);
            }

            if (data.ToList().Count() == 0) throw new KeyNotFoundException("Ejercicios por Serie no encontrados.");
            return data.ToList();
        }

        public object getById(int Id)
        {
            SeriesEjercicios data = _context.SeriesEjercicios.Where(x => x.Id == Id).FirstOrDefault();
            if (data == null) throw new KeyNotFoundException("Ejercicio no encontrado");
            return data;
        }

        public void update(int id, SeriesEjercicios _seriesEjercicios)
        {
            var data = _context.SeriesEjercicios.Find(id);

            if (data == null)
                throw new KeyNotFoundException("No se encontró el ejercicio de la serie seleccionada");

            SeriesEjercicios ejercicio = _context.SeriesEjercicios.Where(x => x.Id != id && x.EjerciciosId == _seriesEjercicios.EjerciciosId && x.MetodoEjercicioId == _seriesEjercicios.MetodoEjercicioId && x.EstadosId == 1 && x.SeriesId == _seriesEjercicios.SeriesId).FirstOrDefault();

            if (ejercicio != null)
                throw new KeyNotFoundException("Ya existe el ejerciocio seleccionado con el método seleccionado.");

            data.EjerciciosId = _seriesEjercicios.EjerciciosId;
            data.Repeticiones = _seriesEjercicios.Repeticiones;
            data.PesoLb = _seriesEjercicios.PesoLb;
            data.EstadosId = _seriesEjercicios.EstadosId;
            data.MetodoEjercicioId = _seriesEjercicios.MetodoEjercicioId;
            data.Descripcion = _seriesEjercicios.Descripcion;
            data.TiempoMinutos = _seriesEjercicios.TiempoMinutos;

            try
            {
                _context.SeriesEjercicios.Update(data);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException("Ocurrio un error al modificar el ejercicio." + ex.Message);
            }
        }
    }
}
