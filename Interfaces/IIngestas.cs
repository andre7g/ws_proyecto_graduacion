using ws_proyecto.Entities;
using ws_proyecto.Models.Dietas;

namespace ws_proyecto.Interfaces
{
    public interface IIngestas
    {
        object getAll();
        object getAll(int dietasId);
        object getById(int Id);
        void create(AgregarIngesta _ingestas);
        void update(int id, EliminarIngesta _ingestas);
    }
}
