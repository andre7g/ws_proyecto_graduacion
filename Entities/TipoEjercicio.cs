using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ws_proyecto.Entities
{
    public class TipoEjercicio
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "El máximo de caracteres permitidos es de 50")]
        [Required(ErrorMessage = "El campo Tipo es obligatorio")]
        public string Tipo { get; set; }

        [Range(1, 2, ErrorMessage = "El campo Estado es obligatorio")]
        [ForeignKey("EstadosId")]
        public int EstadosId { get; set; }
        [JsonIgnore]
        public Estados Estados { get; set; }

        [JsonIgnore]
        public ICollection<Series> Series { get; set; }
    }
}
