using Microsoft.AspNetCore.Mvc;
using ws_proyecto.Models.ResponseData;
using ws_proyecto.Entities;
using ws_proyecto.Interfaces;
using ws_proyecto.Models.Auth;

namespace ws_proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : Controller
    {
        private IUsuarios _usuariosInterface;
        public UsuariosController(IUsuarios usuariosInterface)
        {
            _usuariosInterface = usuariosInterface;
        }

        [HttpPost("login")]
        public Response Autenticar(AutenticarRequest _model)
        {
            Response res = _usuariosInterface.Auth(_model);
            return new Response
            {
                status = res.status,
                message = res.message,
                data = res.data
            };
        }
        [HttpPost("authMovil")]
        public Response AutenticarMovil(AutenticarRequest _model)
        {
            Response res = _usuariosInterface.AuthMovil(_model);
            return new Response
            {
                status = res.status,
                message = res.message,
                data = res.data
            };
        }
        [HttpGet("VerificarUsuario/{idUsuario?}")]
        public Response VerificarUsuario(int idUsuario)
        {
            Response res = _usuariosInterface.Verificar(idUsuario);
            return new Response
            {
                status = res.status,
                message = res.message,
                data = res.data
            };
        }
        [HttpGet("VerificarMovil/{idUsuario?}")]
        public Response VerificarMovil(int idUsuario)
        {
            Response res = _usuariosInterface.VerificarMovil(idUsuario);
            return new Response
            {
                status = res.status,
                message = res.message,
                data = res.data
            };
        }
        [HttpGet]
        public Response GetAll()
        {
            var data = _usuariosInterface.getAll();
            return new Response
            {
                status = 200,
                message = "Lista de Usuarios obtenida correctamente",
                data = data
            };
        }

        [HttpGet("all/{EstadoId}")]
        public Response GetAll(int EstadoId)
        {
            var data = _usuariosInterface.getAll(EstadoId);
            return new Response
            {
                status = 200,
                message = "Lista de Usuarios obtenida correctamente",
                data = data
            };
        }

        [HttpGet("{id}")]
        public Response GetById(int id)
        {
            var data = _usuariosInterface.getById(id);
            return new Response
            {
                status = 200,
                message = "Usuario obtenido correctamente",
                data = data
            };
        }

        [HttpPost]
        public Response Create(Usuarios _usuarios)
        {
            _usuariosInterface.create(_usuarios);
            return new Response
            {
                status = 200,
                message = "Usuario creado correctamente",
                data = null
            };
        }

        [HttpPut]
        [Route("{id}")]
        public Response Update(int id, Usuarios _usuarios)
        {
            _usuariosInterface.update(id, _usuarios);
            return new Response
            {
                status = 200,
                message = "Usuario modificado correctamente",
                data = null
            };
        }
    }
}
