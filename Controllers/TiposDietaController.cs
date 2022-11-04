using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ws_proyecto.Models.ResponseData;
using ws_proyecto.Interfaces;

namespace ws_proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposDietaController : ControllerBase
    {
        private ITiposDieta _tiposDieta;
        public TiposDietaController(ITiposDieta tiposDieta)
        {
            _tiposDieta = tiposDieta;
        }

        [HttpGet]
        public Response GetAll()
        {
            var data = _tiposDieta.getAll();
            return new Response
            {
                status = 200,
                message = "Tipo de dieta obtenido correctamente",
                data = data
            };
        }

        [HttpGet("all/{EstadoId}")]
        public Response GetAll(int EstadoId)
        {
            var data = _tiposDieta.getAll(EstadoId);
            return new Response
            {
                status = 200,
                message = "Tipo de dieta obtenido correctamente",
                data = data
            };
        }

        [HttpGet("{id}")]
        public Response GetById(int id)
        {
            var data = _tiposDieta.getById(id);
            return new Response
            {
                status = 200,
                message = "Tipo de dieta obtenido correctamente",
                data = data
            };
        }

        [HttpPost]
        public Response Create(Entities.TiposDietas _tipos)
        {
            _tiposDieta.create(_tipos);
            return new Response
            {
                status = 200,
                message = "Tipo de dieta creado correctamente",
                data = null
            };
        }

        [HttpPut]
        [Route("{id}")]
        public Response Update(int id, Entities.TiposDietas _tipos)
        {
            _tiposDieta.update(id, _tipos);
            return new Response
            {
                status = 200,
                message = "Tipo de dieta modificado correctamente",
                data = null
            };
        }
    }
}
