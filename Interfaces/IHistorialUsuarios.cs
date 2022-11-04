using ws_proyecto.Entities;

namespace ws_proyecto.Interfaces
{
    public interface IHistorialUsuarios
    {
        object getAllByUsuario(int UsuarioId);
        object getById(int Id);
        void create(HistorialUsuarios _historialUsuarios);
        void update(int id, HistorialUsuarios _historialUsuarios);
    }
}
