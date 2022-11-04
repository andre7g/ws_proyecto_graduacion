using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ws_proyecto.Interfaces;
using ws_proyecto.Models.ResponseData;

namespace ws_proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GruposAlimenticiosController : ControllerBase
    {


        private IGruposAlimenticios _gruposAlimenticios;
        public GruposAlimenticiosController(IGruposAlimenticios gruposAlimenticiosalimentos)
        {
            _gruposAlimenticios = gruposAlimenticiosalimentos;
        }


        [HttpGet]
        public Response GetAll()
        {
            var data = _gruposAlimenticios.getGruposAlimenticios();
            return new Response
            {
                status = 200,
                message = "Grupos Alimenticios obtenidos correctamente.",
                data = data
            };
        }



    }
}
