using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ws_proyecto.Models.ResponseData;
using ws_proyecto.Interfaces;
using ws_proyecto.Entities;
using ws_proyecto.Models.Dietas;

namespace ws_proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngestasController : ControllerBase
    {
        private IIngestas _Ingestas;
        public IngestasController(IIngestas ingestas)
        {
            _Ingestas = ingestas;
        }

        [HttpGet]
        public Response GetAll()
        {
            var data = _Ingestas.getAll();
            return new Response
            {
                status = 200,
                message = "Ingesta obtenida correctamente",
                data = data
            };
        }

        [HttpGet("all/{dietasId}")]
        public Response GetAll(int dietasId)
        {
            var data = _Ingestas.getAll(dietasId);
            return new Response
            {
                status = 200,
                message = "Ingesta obtenida correctamente",
                data = data
            };
        }

        [HttpGet("{id}")]
        public Response GetById(int id)
        {
            var data = _Ingestas.getById(id);
            return new Response
            {
                status = 200,
                message = "Ingesta obtenida correctamente",
                data = data
            };
        }

        [HttpPost]
        public Response Create(AgregarIngesta _ingestas)
        {
            _Ingestas.create(_ingestas);
            return new Response
            {
                status = 200,
                message = "Ingesta creada correctamente",
                data = null
            };
        }

        [HttpPut]
        [Route("{id}")]
        public Response Update(int id, EliminarIngesta _ingestas)
        {
            _Ingestas.update(id, _ingestas);
            return new Response
            {
                status = 200,
                message = "Ingesta modificada correctamente",
                data = null
            };
        }
    }
}
