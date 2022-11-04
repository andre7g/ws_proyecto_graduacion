using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ws_proyecto.Interfaces;
using ws_proyecto.Models.ResponseData;

namespace ws_proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadMedidasController : ControllerBase
    {
        private IUnidadMedidas _UnidadMedidas;
        public UnidadMedidasController(IUnidadMedidas unidadMedidas)
        {
            _UnidadMedidas = unidadMedidas;
        }

        [HttpGet]
        public Response GetAll()
        {
            var data = _UnidadMedidas.getAll();
            return new Response
            {
                status = 200,
                message = "Unidad de medida obtenida correctamente",
                data = data
            };
        }

        [HttpGet("all/{EstadoId}")]
        public Response GetAll(int EstadoId)
        {
            var data = _UnidadMedidas.getAll(EstadoId);
            return new Response
            {
                status = 200,
                message = "Unidad de medida obtenida correctamente",
                data = data
            };
        }

        [HttpGet("{id}")]
        public Response GetById(int id)
        {
            var data = _UnidadMedidas.getById(id);
            return new Response
            {
                status = 200,
                message = "Unidad de medida obtenida correctamente",
                data = data
            };
        }

        [HttpPost]
        public Response Create(Entities.UnidadMedidas _unidadmedidas)
        {
            _UnidadMedidas.create(_unidadmedidas);
            return new Response
            {
                status = 200,
                message = "Unidad de medida creada correctamente",
                data = null
            };
        }

        [HttpPut]
        [Route("{id}")]
        public Response Update(int id, Entities.UnidadMedidas _unidadmedidas)
        {
            _UnidadMedidas.update(id, _unidadmedidas);
            return new Response
            {
                status = 200,
                message = "Unidad de medida modificada correctamente",
                data = null
            };
        }
    }
}
