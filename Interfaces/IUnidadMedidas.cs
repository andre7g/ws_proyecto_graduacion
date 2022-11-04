using ws_proyecto.Entities;

namespace ws_proyecto.Interfaces
{
    public interface IUnidadMedidas
    {
        object getAll();
        object getAll(int EstadoId);
        object getById(int Id);
        void create(UnidadMedidas _unidadmedidas);
        void update(int id, UnidadMedidas _unidadmedidas);
    }
}
