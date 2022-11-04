using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ws_proyecto.Models.ResponseData;
using ws_proyecto.Entities;
using ws_proyecto.Interfaces;

namespace ws_proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EjercicioController : ControllerBase
    {
        private IEjercicios _Ejercicio;
        public EjercicioController(IEjercicios ejercicio)
        {
            _Ejercicio = ejercicio;
        }

        [HttpGet]
        public Response GetAll()
        {
            var data = _Ejercicio.getAll();
            return new Response
            {
                status = 200,
                message = "Ejercicio obtenido correctamente",
                data = data
            };
        }

        [HttpGet("all/{EstadoId}")]
        public Response GetAll(int EstadoId)
        {
            var data = _Ejercicio.getAll(EstadoId);
            return new Response
            {
                status = 200,
                message = "Ejercicio obtenido correctamente",
                data = data
            };
        }

        [HttpGet("{id}")]
        public Response GetById(int id)
        {
            var data = _Ejercicio.getById(id);
            return new Response
            {
                status = 200,
                message = "Ejercicio obtenido correctamente",
                data = data
            };
        }

        [HttpPost]
        public Response Create(Ejercicios _ejercicio)
        {
            _Ejercicio.create(_ejercicio);
            return new Response
            {
                status = 200,
                message = "Ejercicio creado correctamente",
                data = null
            };
        }

        [HttpPut]
        [Route("{id}")]
        public Response Update(int id, Entities.Ejercicios _ejercicio)
        {
            _Ejercicio.update(id, _ejercicio);
            return new Response
            {
                status = 200,
                message = "Ejercicio modificado correctamente",
                data = null
            };
        }
    }
}
