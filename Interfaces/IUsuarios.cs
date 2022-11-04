using ws_proyecto.Entities;
using ws_proyecto.Models.Auth;
using ws_proyecto.Models.ResponseData;

namespace ws_proyecto.Interfaces
{
    public interface IUsuarios
    {
        object getAll();
        object getAll(int EstadoId);
        object getById(int Id);
        Response Auth(AutenticarRequest model);
        Response AuthMovil(AutenticarRequest model);
        Response Verificar(int Id);
        Response VerificarMovil(int Id);
        void create(Usuarios _Usuarios);
        void update(int id, Usuarios _Usuarios);
    }
}
