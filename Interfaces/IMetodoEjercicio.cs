using ws_proyecto.Entities;

namespace ws_proyecto.Interfaces
{
    public interface IMetodoEjercicio
    {
        object getAll();
        object getAll(int EstadoId);
        object getById(int Id);
        void create(MetodoEjercicio _metodoejercicio);
        void update(int id, MetodoEjercicio _metodoejercicio);
    }
}
