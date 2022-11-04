using ws_proyecto.Entities;

namespace ws_proyecto.Interfaces
{
    public interface IAlimentos
    {
        object getAll();
        object getByGruposAlimenticios(int GruposAlimenticiosId);
        object getById(int Id);
        void create(Alimentos _alimentos);
        void update(int id, Alimentos _alimentos);
    }
}
