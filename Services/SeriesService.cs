using ws_proyecto.Helpers;
using ws_proyecto.Entities;
using ws_proyecto.Interfaces;
using ws_proyecto.Models.Ejercicios;

namespace ws_proyecto.Services
{
    public class SeriesService : ISeries
    {
        private DataContext _context;
        public SeriesService(DataContext context)
        {
            _context = context;
        }

        public void create(CrearSeries _series)
        {
            for (int i = 0; i < _series.Repeticiones; i++ )
            {
                Series series = new Series();
                series.RutinaId = _series.RutinaId;
                series.TipoEjercicioId = _series.TipoEjercicioId;
                series.EstadosId = 1;
                series.Completado = 0;

                try
                {
                    _context.Series.Add(series);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new KeyNotFoundException("Ocurrio un error al registrar la serie." + ex.Message);
                }
            }

        }

        public object getAll()
        {
            return getSeries();
        }

        public object getAll(int rutinaId)
        {
            return getSeries(rutinaId);
        }

        public object getById(int Id)
        {
            Series data = _context.Series.Where(x => x.Id == Id).FirstOrDefault();
            if (data == null) throw new KeyNotFoundException("Serie no encontrada");
            return data;
        }
        private object getSeries()
        {
            var data = _context.Series.Select(x => new
            {
                x.Id,
                x.RutinaId,
                x.Rutina.Nombre,
                x.TipoEjercicioId,
                x.TipoEjercicio.Tipo,
                x.EstadosId,
                x.Estados.Estado,
                x.Completado
            }).ToList();

            if (data == null) throw new KeyNotFoundException("Serie no encontrada");
            return data;
        }
        private object getSeries(int rutinaId)
        {
            var data = _context.Series.Select(x => new
            {
                x.Id,
                x.RutinaId,
                x.Rutina.Nombre,
                x.TipoEjercicioId,
                x.TipoEjercicio.Tipo,
                x.EstadosId,
                x.Estados.Estado,
                x.Completado

            });

            if (rutinaId != 0)
            {
                data = data.Where(x => x.RutinaId == rutinaId && x.EstadosId == 1);
            }

            if (data.ToList().Count() == 0) throw new KeyNotFoundException("Serie no encontrada");
            return data.ToList();
        }

        public void update(int id, Series _series)
        {
            var series = _context.Series.Find(id);
            series.EstadosId = 2;

            try
            {
                _context.Series.Update(series);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException("Ocurrio un error al registrar la serie." + ex.Message);
            }
        }
    }
}
