using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ws_proyecto.Entities;
using ws_proyecto.Interfaces;
using ws_proyecto.Models.ResponseData;

namespace ws_proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioRutinaController : ControllerBase
    {
        private IUsuarioRutina _UsuarioRutina;
        public UsuarioRutinaController(IUsuarioRutina usuarioRutina)
        {
            _UsuarioRutina = usuarioRutina;
        }

        [HttpGet("all/{UsuarioId}")]
        public Response GetAll(int UsuarioId)
        {
            var data = _UsuarioRutina.getAll(UsuarioId);
            return new Response
            {
                status = 200,
                message = "Rutinas obtenidas correctamente.",
                data = data
            };
        }

        [HttpGet("{id}")]
        public Response GetById(int id)
        {
            var data = _UsuarioRutina.getById(id);
            return new Response
            {
                status = 200,
                message = "Rutina obtenida correctamente",
                data = data
            };
        }

        [HttpPost]
        public Response Create(UsuarioRutina _rutinas)
        {
            _UsuarioRutina.create(_rutinas);
            return new Response
            {
                status = 200,
                message = "Rutina agregada correctamente",
                data = null
            };
        }

        [HttpPut]
        [Route("{id}")]
        public Response Update(int id, UsuarioRutina _rutinas)
        {
            _UsuarioRutina.update(id, _rutinas);
            return new Response
            {
                status = 200,
                message = "Rutina modificada correctamente",
                data = null
            };
        }
    }
}
