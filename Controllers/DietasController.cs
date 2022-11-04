using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ws_proyecto.Models.ResponseData;
using ws_proyecto.Interfaces;

namespace ws_proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DietasController : ControllerBase
    {
        private IDietas _Dietas;
        public DietasController(IDietas dietas)
        {
            _Dietas = dietas;
        }

        [HttpGet]
        public Response GetAll()
        {
            var data = _Dietas.getAll();
            return new Response
            {
                status = 200,
                message = "Dieta obtenida correctamente",
                data = data
            };
        }

        [HttpGet("all/{EstadoId}")]
        public Response GetAll(int EstadoId)
        {
            var data = _Dietas.getAll(EstadoId);
            return new Response
            {
                status = 200,
                message = "Dieta obtenida correctamente",
                data = data
            };
        }

        [HttpGet("{id}")]
        public Response GetById(int id)
        {
            var data = _Dietas.getById(id);
            return new Response
            {
                status = 200,
                message = "Dieta obtenida correctamente",
                data = data
            };
        }

        [HttpPost]
        public Response Create(Entities.Dietas _dietas)
        {
            _Dietas.create(_dietas);
            return new Response
            {
                status = 200,
                message = "Dieta creada correctamente",
                data = null
            };
        }

        [HttpPut]
        [Route("{id}")]
        public Response Update(int id, Entities.Dietas _dietas)
        {
            _Dietas.update(id, _dietas);
            return new Response
            {
                status = 200,
                message = "Dieta modificada correctamente",
                data = null
            };
        }
    }
}
