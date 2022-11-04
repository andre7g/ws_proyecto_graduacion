using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ws_proyecto.Interfaces;
using ws_proyecto.Models.ResponseData;

namespace ws_proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlimentosController : ControllerBase
    {
        private IAlimentos _Alimentos;
        public AlimentosController(IAlimentos alimentos)
        {
            _Alimentos = alimentos;
        }

        [HttpGet]
        public Response GetAll()
        {
            var data = _Alimentos.getAll();
            return new Response
            {
                status = 200,
                message = "Alimentos obtenidos correctamente",
                data = data
            };
        }

        [HttpGet("byGrupoAlimenticio/{GruposAlimenticiosId}")]
        public Response GetAll(int GruposAlimenticiosId)
        {
            var data = _Alimentos.getByGruposAlimenticios(GruposAlimenticiosId);
            return new Response
            {
                status = 200,
                message = "Alimentos obtenidos correctamente",
                data = data
            };
        }

        [HttpGet("{id}")]
        public Response GetById(int id)
        {
            var data = _Alimentos.getById(id);
            return new Response
            {
                status = 200,
                message = "Alimentos obtenidos correctamente",
                data = data
            };
        }

        [HttpPost]
        public Response Create(Entities.Alimentos _alimentos)
        {
            _Alimentos.create(_alimentos);
            return new Response
            {
                status = 200,
                message = "Alimentos creados correctamente",
                data = null
            };
        }

        [HttpPut]
        [Route("{id}")]
        public Response Update(int id, Entities.Alimentos _alimentos)
        {
            _Alimentos.update(id, _alimentos);
            return new Response
            {
                status = 200,
                message = "Alimentos modificados correctamente",
                data = null
            };
        }
    }
}
