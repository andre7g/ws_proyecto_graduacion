using ws_proyecto.Entities;

namespace ws_proyecto.Interfaces
{
    public interface IDietas
    {
        object getAll();
        object getAll(int EstadoId);
        object getById(int Id);
        void create(Dietas _dietas);
        void update(int id, Dietas _dietas);
    }
}
