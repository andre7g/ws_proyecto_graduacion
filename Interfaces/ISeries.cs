using ws_proyecto.Entities;
using ws_proyecto.Models.Ejercicios;

namespace ws_proyecto.Interfaces
{
    public interface ISeries
    {
        object getAll();
        object getAll(int rutinaId);
        object getById(int Id);
        void create(CrearSeries _series);
        void update(int id, Series _series);
    }
}
