using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ws_proyecto.Models.ResponseData;
using ws_proyecto.Interfaces;

namespace ws_proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetodoEjercicioController : ControllerBase
    {
        private IMetodoEjercicio _MetodoEjercicio;
        public MetodoEjercicioController(IMetodoEjercicio metodoEjercicio)
        {
            _MetodoEjercicio = metodoEjercicio;
        }

        [HttpGet]
        public Response GetAll()
        {
            var data = _MetodoEjercicio.getAll();
            return new Response
            {
                status = 200,
                message = "Método de ejercicio obtenido correctamente",
                data = data
            };
        }

        [HttpGet("all/{EstadoId}")]
        public Response GetAll(int EstadoId)
        {
            var data = _MetodoEjercicio.getAll(EstadoId);
            return new Response
            {
                status = 200,
                message = "Método de ejercicio obtenido correctamente",
                data = data
            };
        }

        [HttpGet("{id}")]
        public Response GetById(int id)
        {
            var data = _MetodoEjercicio.getById(id);
            return new Response
            {
                status = 200,
                message = "Método de ejercicio obtenido correctamente",
                data = data
            };
        }

        [HttpPost]
        public Response Create(Entities.MetodoEjercicio _metodoejercicio)
        {
            _MetodoEjercicio.create(_metodoejercicio);
            return new Response
            {
                status = 200,
                message = "Método de ejercicio creado correctamente",
                data = null
            };
        }

        [HttpPut]
        [Route("{id}")]
        public Response Update(int id, Entities.MetodoEjercicio _metodoejercicio)
        {
            _MetodoEjercicio.update(id, _metodoejercicio);
            return new Response
            {
                status = 200,
                message = "Método de ejercicio modificado correctamente",
                data = null
            };
        }
    }
}
