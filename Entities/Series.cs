using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ws_proyecto.Entities
{
    public class Series
    {
        [Key]
        public int Id { get; set; }
        [Range(1, 9999, ErrorMessage = "El campo Rutina es obligatorio")]
        [ForeignKey("RutinaId")]
        public int RutinaId { get; set; }
        [JsonIgnore]
        public Rutina? Rutina { get; set; }

        [Range(1, 9999, ErrorMessage = "El campo Tipo de Ejercicio es obligatorio")]
        [ForeignKey("TipoEjercicioId")]
        public int TipoEjercicioId { get; set; }
        [JsonIgnore]
        public TipoEjercicio? TipoEjercicio { get; set; }

        [Range(1, 2, ErrorMessage = "El campo Estado es obligatorio")]
        [ForeignKey("EstadosId")]
        public int EstadosId { get; set; }
        [JsonIgnore]
        public Estados? Estados { get; set; }
        public int? Completado { get; set; }


        [JsonIgnore]
        public ICollection<SeriesEjercicios>? SeriesEjercicios { get; set; }

    }
}
