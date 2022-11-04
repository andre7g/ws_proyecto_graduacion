using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ws_proyecto.Entities;
using ws_proyecto.Interfaces;
using ws_proyecto.Models.ResponseData;
using ws_proyecto.Models.Usuarios;

namespace ws_proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialPagosController : ControllerBase
    {
        private IHistorialPagos _historialPagos;
        public HistorialPagosController(IHistorialPagos historialPagos)
        {
            _historialPagos = historialPagos;
        }

        [HttpGet("all/{usuarioId}")]
        public Response GetAll(int usuarioId)
        {
            var data = _historialPagos.getAll(usuarioId);
            return new Response
            {
                status = 200,
                message = "Historial de usuario obtenido correctamente.",
                data = data
            };
        }
        [HttpPost]
        public Response Create(HistorialPagos _historial)
        {
            _historialPagos.create(_historial);
            return new Response
            {
                status = 200,
                message = "Historial de usuario creado correctamente.",
                data = null
            };
        }

        [HttpPut]
        [Route("{id}")]
        public Response Update(int id, EliminarPago _historial)
        {
            _historialPagos.update(id, _historial);
            return new Response
            {
                status = 200,
                message = "Historial de pago eliminado correctamente.",
                data = null
            };
        }
    }
}
