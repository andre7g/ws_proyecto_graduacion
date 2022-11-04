using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ws_proyecto.Interfaces;
using ws_proyecto.Models.ResponseData;

namespace ws_proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private IDashboard _IDashboard;
        public DashboardController(IDashboard dashboardInterface)
        {
            _IDashboard = dashboardInterface;
        }

        [HttpGet("getContadores")]
        public Response GetContadores()
        {
            var data = _IDashboard.getContadores();
            return new Response
            {
                status = 200,
                message = "Alimentos obtenidos correctamente",
                data = data
            };
        }
        [HttpGet("getRating")]
        public Response GetMejoresUsuarios()
        {
            var data = _IDashboard.getMejoresUsuarios();
            return new Response
            {
                status = 200,
                message = "Alimentos obtenidos correctamente",
                data = data
            };
        }
    }
}
