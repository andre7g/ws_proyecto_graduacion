using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ws_proyecto.Models.ResponseData;
using ws_proyecto.Interfaces;
using ws_proyecto.Models.Ejercicios;

namespace ws_proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private ISeries _Series;
        public SeriesController(ISeries series)
        {
            _Series = series;
        }

        [HttpGet]
        public Response GetAll()
        {
            var data = _Series.getAll();
            return new Response
            {
                status = 200,
                message = "Serie obtenida correctamente",
                data = data
            };
        }

        [HttpGet("all/{rutinaId}")]
        public Response GetAll(int rutinaId)
        {
            var data = _Series.getAll(rutinaId);
            return new Response
            {
                status = 200,
                message = "Serie obtenida correctamente",
                data = data
            };
        }

        [HttpGet("{id}")]
        public Response GetById(int id)
        {
            var data = _Series.getById(id);
            return new Response
            {
                status = 200,
                message = "Serie obtenida correctamente",
                data = data
            };
        }

        [HttpPost]
        public Response Create(CrearSeries _series)
        {
            _Series.create(_series);
            return new Response
            {
                status = 200,
                message = "Serie creada correctamente",
                data = null
            };
        }

        [HttpPut]
        [Route("{id}")]
        public Response Update(int id, Entities.Series _series)
        {
            _Series.update(id, _series);
            return new Response
            {
                status = 200,
                message = "Serie modificada correctamente",
                data = null
            };
        }
    }
}
