using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ws_proyecto.Entities;
using ws_proyecto.Interfaces;
using ws_proyecto.Models.ResponseData;

namespace ws_proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesEjerciciosController : ControllerBase
    {
        private ISeriesEjercicios _ISeriesEjercicios;
        public SeriesEjerciciosController(ISeriesEjercicios seriesEjercicios)
        {
            _ISeriesEjercicios = seriesEjercicios;
        }

        [HttpGet("all/{serieId}")]
        public Response GetAll(int serieId)
        {
            var data = _ISeriesEjercicios.getAll(serieId);
            return new Response
            {
                status = 200,
                message = "Ejercicios obtenidos correctamente.",
                data = data
            };
        }

        [HttpGet("{id}")]
        public Response GetById(int id)
        {
            var data = _ISeriesEjercicios.getById(id);
            return new Response
            {
                status = 200,
                message = "Ejercicio obtenido correctamente.",
                data = data
            };
        }

        [HttpPost]
        public Response Create(SeriesEjercicios _seriesEjercicios)
        {
            _ISeriesEjercicios.create(_seriesEjercicios);
            return new Response
            {
                status = 200,
                message = "Ejercicio agregado correctamente.",
                data = null
            };
        }

        [HttpPut]
        [Route("{id}")]
        public Response Update(int id, SeriesEjercicios _seriesEjercicios)
        {
            _ISeriesEjercicios.update(id, _seriesEjercicios);
            return new Response
            {
                status = 200,
                message = "Ejercicio actualizado correctamente.",
                data = null
            };
        }
    }
}
