using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ws_proyecto.Entities
{
    public class Rutina
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100, ErrorMessage = "El máximo de caracteres permitidos es de 100")]
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string Nombre { get; set; }

        [MaxLength(500, ErrorMessage = "El máximo de caracteres permitidos es de 100")]
        [Required(ErrorMessage = "El campo Descripción es obligatorio")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo Dificultad es obligatorio")]
        [Precision(2)]
        public int Dificultad { get; set; }

        [Range(1, 2, ErrorMessage = "El campo Estado es obligatorio")]
        [ForeignKey("EstadosId")]
        public int EstadosId { get; set; }
        [JsonIgnore]
        public Estados? Estados { get; set; }

        [JsonIgnore]
        public ICollection<Series>? Series { get; set; }
        public ICollection<UsuarioRutina>? UsuarioRutina { get; set; }
    }
}
