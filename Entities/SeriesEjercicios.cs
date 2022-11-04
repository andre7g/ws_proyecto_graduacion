using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ws_proyecto.Entities
{
    public class SeriesEjercicios
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(1000, ErrorMessage = "El máximo de caracteres permitidos es de 1000")]
        public string? Descripcion { get; set; }


        [Range(1, 10000, ErrorMessage = "El campo SeriesId es obligatorio")]
        [ForeignKey("SeriesId")]
        public int SeriesId { get; set; }
        [JsonIgnore]
        public Series? Series { get; set; }


        [Range(1, 10000, ErrorMessage = "El campo EjerciciosId es obligatorio")]
        [ForeignKey("EjerciciosId")]
        public int EjerciciosId { get; set; }
        [JsonIgnore]
        public Ejercicios? Ejercicios { get; set; }

        [Required(ErrorMessage = "El campo Repeticiones es obligatorio")]
        public int Repeticiones { get; set; }

        [Required(ErrorMessage = "El campo TiempoMinutos es obligatorio")]
        public int TiempoMinutos { get; set; }

        [Required(ErrorMessage = "El campo PesoLb es obligatorio")]
        [Precision(4, 2)]
        public decimal PesoLb { get; set; }

        [Range(1, 2, ErrorMessage = "El campo EstadosId es obligatorio")]
        [ForeignKey("EstadosId")]
        public int EstadosId { get; set; }
        [JsonIgnore]
        public Estados? Estados { get; set; }

        [Range(1, 10000, ErrorMessage = "El campo MetodoEjercicioId es obligatorio")]
        [ForeignKey("MetodoEjercicioId")]
        public int MetodoEjercicioId { get; set; }
        [JsonIgnore]
        public MetodoEjercicio? MetodoEjercicio { get; set; }

    }
}
