using ws_proyecto.Entities;

namespace ws_proyecto.Interfaces
{
    public interface IIngestaAlimentos
    {
        object getAll();
        object getAll(int ingestaId);
        object getById(int Id);
        void create(IngestaAlimentos _ingestaAlimentos);
        void update(int id, IngestaAlimentos _ingestaAlimentos);
    }
}
