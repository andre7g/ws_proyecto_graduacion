using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ws_proyecto.Interfaces;
using ws_proyecto.Models.ResponseData;

namespace ws_proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlimentosPorcionController : ControllerBase
    {
        private IAlimentosPorcion _Alimentos;
        public AlimentosPorcionController(IAlimentosPorcion alimentos)
        {
            _Alimentos = alimentos;
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

    }
}
