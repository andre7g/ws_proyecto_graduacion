using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ws_proyecto.Models.ResponseData;
using ws_proyecto.Interfaces;

namespace ws_proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RutinaController : ControllerBase
    {
        private IRutina _Rutina;
        public RutinaController(IRutina rutina)
        {
            _Rutina = rutina;
        }

        [HttpGet]
        public Response GetAll()
        {
            var data = _Rutina.getAll();
            return new Response
            {
                status = 200,
                message = "Rutina obtenida correctamente",
                data = data
            };
        }

        [HttpGet("all/{EstadoId}")]
        public Response GetAll(int EstadoId)
        {
            var data = _Rutina.getAll(EstadoId);
            return new Response
            {
                status = 200,
                message = "Rutina obtenida correctamente",
                data = data
            };
        }

        [HttpGet("{id}")]
        public Response GetById(int id)
        {
            var data = _Rutina.getById(id);
            return new Response
            {
                status = 200,
                message = "Rutina obtenida correctamente",
                data = data
            };
        }

        [HttpPost]
        public Response Create(Entities.Rutina _rutina)
        {
            _Rutina.create(_rutina);
            return new Response
            {
                status = 200,
                message = "Rutina creada correctamente",
                data = null
            };
        }

        [HttpPut]
        [Route("{id}")]
        public Response Update(int id, Entities.Rutina _rutina)
        {
            _Rutina.update(id, _rutina);
            return new Response
            {
                status = 200,
                message = "Rutina modificada correctamente",
                data = null
            };
        }
    }
}
