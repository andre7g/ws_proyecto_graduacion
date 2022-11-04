using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ws_proyecto.Entities;
using ws_proyecto.Interfaces;
using ws_proyecto.Models.ResponseData;

namespace ws_proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioDietasController : ControllerBase
    {
        private IUsuarioDietas _UsuarioDietas;
        public UsuarioDietasController(IUsuarioDietas usuarioDietas)
        {
            _UsuarioDietas = usuarioDietas;
        }

        [HttpGet]
        public Response GetAll()
        {
            var data = _UsuarioDietas.getAll();
            return new Response
            {
                status = 200,
                message = "Usuario de dietas obtenido correctamente",
                data = data
            };
        }

        [HttpGet("all/{usuarioId}")]
        public Response GetAll(int usuarioId)
        {
            var data = _UsuarioDietas.getAll(usuarioId);
            return new Response
            {
                status = 200,
                message = "Usuario de dietas obtenido correctamente",
                data = data
            };
        }

        [HttpGet("{id}")]
        public Response GetById(int id)
        {
            var data = _UsuarioDietas.getById(id);
            return new Response
            {
                status = 200,
                message = "Usuario de dietas obtenido correctamente",
                data = data
            };
        }

        [HttpPost]
        public Response Create(UsuarioDietas _usuariodietas)
        {
            _UsuarioDietas.create(_usuariodietas);
            return new Response
            {
                status = 200,
                message = "Usuario de dietas creado correctamente",
                data = null
            };
        }

        [HttpPut]
        [Route("{id}")]
        public Response Update(int id, UsuarioDietas _usuariodietas)
        {
            _UsuarioDietas.update(id, _usuariodietas);
            return new Response
            {
                status = 200,
                message = "Usuario de dietas modificado correctamente",
                data = null
            };
        }
    }
}
