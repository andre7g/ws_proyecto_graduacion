using ws_proyecto.Models.Alimentos;

namespace ws_proyecto.Interfaces
{
    public interface IUsuariosAlimentos
    {
        object getByUsuario(int usuarioId);
        void create(AgregarAlimentoUsuario _alimentos);
    }
}
