using ws_proyecto.Entities;
using ws_proyecto.Models.Usuarios;

namespace ws_proyecto.Interfaces
{
    public interface IHistorialPagos
    {
        object getAll();
        object getAll(int usuarioId);
        object getById(int Id);
        void create(HistorialPagos _historial);
        void update(int id, EliminarPago _historial);
    }
}
