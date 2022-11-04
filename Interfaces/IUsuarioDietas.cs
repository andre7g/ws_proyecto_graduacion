using ws_proyecto.Entities;

namespace ws_proyecto.Interfaces
{
    public interface IUsuarioDietas
    {
        object getAll();
        object getAll(int usuarioId);
        object getById(int Id);
        void create(UsuarioDietas _usuariodietas);
        void update(int id, UsuarioDietas _usuariodietas);
    }
}
