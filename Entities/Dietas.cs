using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ws_proyecto.Entities
{
    public class Dietas
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100, ErrorMessage = "El máximo de caracteres permitidos es de 100")]
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string Nombre { get; set; }

        [MaxLength(1000, ErrorMessage = "El máximo de caracteres permitidos es de 1000")]
        public string? Descripcion { get; set; }

        [Range(1, 2, ErrorMessage = "El campo Estado es obligatorio")]
        [ForeignKey("EstadosId")]
        public int EstadosId { get; set; }
        [JsonIgnore]
        public Estados? Estados { get; set; }

        [Range(1, 9999, ErrorMessage = "El campo Tipos Dieta es obligatorio")]
        [ForeignKey("TiposDietasId")]
        public int TiposDietasId { get; set; }
        [JsonIgnore]
        public TiposDietas? TiposDietas { get; set; }

        [JsonIgnore]
        public ICollection<Ingestas>? Ingestas { get; set; }

        [JsonIgnore]
        public ICollection<UsuarioDietas>? UsuarioDietas { get; set; }
    }
}
