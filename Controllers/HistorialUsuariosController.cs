using Microsoft.AspNetCore.Mvc;
using ws_proyecto.Models.ResponseData;
using ws_proyecto.Entities;
using ws_proyecto.Interfaces;

namespace ws_proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialUsuariosController : ControllerBase
    {
        private IHistorialUsuarios _historialUsuarios;
        public HistorialUsuariosController(IHistorialUsuarios historialUsuarios)
        {
            _historialUsuarios = historialUsuarios;
        }
        [HttpGet("all/{UsuarioId}")]
        public Response GetAll(int UsuarioId)
        {
            var data = _historialUsuarios.getAllByUsuario(UsuarioId);
            return new Response
            {
                status = 200,
                message = "Historial de Usuario obtenido correctamente.",
                data = data
            };
        }
        [HttpGet("{id}")]
        public Response GetById(int id)
        {
            var data = _historialUsuarios.getById(id);
            return new Response
            {
                status = 200,
                message = "Historial obtenido correctamente",
                data = data
            };
        }
        [HttpPost]
        public Response Create(HistorialUsuarios _historial)
        {
            _historialUsuarios.create(_historial);
            return new Response
            {
                status = 200,
                message = "Control creado correctamente.",
                data = null
            };
        }
    }
}
