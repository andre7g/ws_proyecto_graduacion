using ws_proyecto.Entities;

namespace ws_proyecto.Interfaces
{
    public interface ITiposDieta
    {
        object getAll();
        object getAll(int EstadoId);
        object getById(int Id);
        void create(TiposDietas _tiposdieta);
        void update(int id, TiposDietas _tiposdieta);
    }
}
