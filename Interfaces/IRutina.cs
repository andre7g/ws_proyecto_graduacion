using ws_proyecto.Entities;

namespace ws_proyecto.Interfaces
{
    public interface IRutina
    {
        object getAll();
        object getAll(int EstadoId);
        object getById(int Id);
        void create(Rutina _rutina);
        void update(int id, Rutina _rutina);
    }
}
