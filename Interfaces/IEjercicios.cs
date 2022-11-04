using ws_proyecto.Entities;

namespace ws_proyecto.Interfaces
{
    public interface IEjercicios
    {
        object getAll();
        object getAll(int EstadoId);
        object getById(int Id);
        void create(Ejercicios _ejercicio);
        void update(int id, Ejercicios _ejercicio);
    }
}
