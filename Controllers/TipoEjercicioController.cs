using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ws_proyecto.Models.ResponseData;
using ws_proyecto.Interfaces;

namespace ws_proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoEjercicioController : ControllerBase
    {
        private ITipoEjercicio _TipoEjercicio;
        public TipoEjercicioController(ITipoEjercicio tipoEjercicio)
        {
            _TipoEjercicio = tipoEjercicio;
        }

        [HttpGet]
        public Response GetAll()
        {
            var data = _TipoEjercicio.getAll();
            return new Response
            {
                status = 200,
                message = "Tipo de ejercicio obtenido correctamente",
                data = data
            };
        }

        [HttpGet("all/{EstadoId}")]
        public Response GetAll(int EstadoId)
        {
            var data = _TipoEjercicio.getAll(EstadoId);
            return new Response
            {
                status = 200,
                message = "Tipo de ejercicio obtenido correctamente",
                data = data
            };
        }

        [HttpGet("{id}")]
        public Response GetById(int id)
        {
            var data = _TipoEjercicio.getById(id);
            return new Response
            {
                status = 200,
                message = "Tipo de ejercicio obtenido correctamente",
                data = data
            };
        }

        [HttpPost]
        public Response Create(Entities.TipoEjercicio _tipoejercicio)
        {
            _TipoEjercicio.create(_tipoejercicio);
            return new Response
            {
                status = 200,
                message = "Tipo de ejercicio creado correctamente",
                data = null
            };
        }

        [HttpPut]
        [Route("{id}")]
        public Response Update(int id, Entities.TipoEjercicio _tipoejercicio)
        {
            _TipoEjercicio.update(id, _tipoejercicio);
            return new Response
            {
                status = 200,
                message = "Tipo de ejercicio modificado correctamente",
                data = null
            };
        }
    }
}
