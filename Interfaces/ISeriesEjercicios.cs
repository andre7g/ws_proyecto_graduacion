using ws_proyecto.Entities;

namespace ws_proyecto.Interfaces
{
    public interface ISeriesEjercicios
    {
        object getAll();
        object getAll(int SerieId);
        object getById(int Id);
        void create(SeriesEjercicios _seriesEjercicios);
        void update(int id, SeriesEjercicios _seriesEjercicios);
    }
}
