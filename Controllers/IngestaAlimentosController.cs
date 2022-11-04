using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ws_proyecto.Interfaces;
using ws_proyecto.Models.ResponseData;

namespace ws_proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngestaAlimentosController : ControllerBase
    {
        private IIngestaAlimentos _IngestaAlimentos;
        public IngestaAlimentosController(IIngestaAlimentos ingestaAlimentos)
        {
            _IngestaAlimentos = ingestaAlimentos;
        }

        [HttpGet]
        public Response GetAll()
        {
            var data = _IngestaAlimentos.getAll();
            return new Response
            {
                status = 200,
                message = "Ingesta de alimentos obtenida correctamente",
                data = data
            };
        }

        [HttpGet("all/{ingestaId}")]
        public Response GetAll(int ingestaId)
        {
            var data = _IngestaAlimentos.getAll(ingestaId);
            return new Response
            {
                status = 200,
                message = "Ingesta de alimentos obtenida correctamente",
                data = data
            };
        }

        [HttpGet("{id}")]
        public Response GetById(int id)
        {
            var data = _IngestaAlimentos.getById(id);
            return new Response
            {
                status = 200,
                message = "Ingesta de alimentos obtenida correctamente",
                data = data
            };
        }

        [HttpPost]
        public Response Create(Entities.IngestaAlimentos _ingestaAlimentos)
        {
            _IngestaAlimentos.create(_ingestaAlimentos);
            return new Response
            {
                status = 200,
                message = "Ingesta de alimentos creada correctamente",
                data = null
            };
        }

        [HttpPut]
        [Route("{id}")]
        public Response Update(int id, Entities.IngestaAlimentos _ingestaAlimentos)
        {
            _IngestaAlimentos.update(id, _ingestaAlimentos);
            return new Response
            {
                status = 200,
                message = "Ingesta de alimentos modificada correctamente",
                data = null
            };
        }
    }
}
