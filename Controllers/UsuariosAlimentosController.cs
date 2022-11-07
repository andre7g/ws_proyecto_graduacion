using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ws_proyecto.Interfaces;
using ws_proyecto.Models.Alimentos;
using ws_proyecto.Models.ResponseData;

namespace ws_proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosAlimentosController : ControllerBase
    {
        private IUsuariosAlimentos _IAlimentos;
        public UsuariosAlimentosController(IUsuariosAlimentos alimentos)
        {
            _IAlimentos = alimentos;
        }

        [HttpGet("{usuarioId}")]
        public Response GetById(int usuarioId)
        {
            var data = _IAlimentos.getByUsuario(usuarioId);
            return new Response
            {
                status = 200,
                message = "Usuario obtenido correctamente.",
                data = data
            };
        }

        [HttpPost]
        public Response Create(AgregarAlimentoUsuario _alimentos)
        {
            _IAlimentos.create(_alimentos);
            return new Response
            {
                status = 200,
                message = "Alimento agregado correctamente.",
                data = null
            };
        }
    }
}
