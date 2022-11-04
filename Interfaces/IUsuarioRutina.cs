using ws_proyecto.Entities;

namespace ws_proyecto.Interfaces
{
    public interface IUsuarioRutina
    {
        object getAll();
        object getAll(int UsuarioId);
        object getById(int Id);
        void create(UsuarioRutina _usuarioRutina);
        void update(int id, UsuarioRutina _usuarioRutina);
    }
}
