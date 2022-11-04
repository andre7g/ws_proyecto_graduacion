using ws_proyecto.Entities;

namespace ws_proyecto.Interfaces
{
    public interface ITipoEjercicio
    {
        object getAll();
        object getAll(int EstadoId);
        object getById(int Id);
        void create(TipoEjercicio _tipoejercicio);
        void update(int id, TipoEjercicio _tipoejercicio);
    }
}
