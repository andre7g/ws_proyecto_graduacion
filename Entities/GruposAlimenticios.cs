using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ws_proyecto.Entities
{
    public class GruposAlimenticios
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100, ErrorMessage = "El máximo de caracteres permitidos es de 100")]
        [Required(ErrorMessage = "El campo Grupo es obligatorio")]
        public string Grupo { get; set; }

        [Range(1, 2, ErrorMessage = "El campo Estado es obligatorio")]
        [ForeignKey("EstadosId")]
        public int EstadosId { get; set; }
        [JsonIgnore]
        public Estados Estados { get; set; }

        [JsonIgnore]
        public ICollection<Alimentos> Alimentos { get; set; }
        [JsonIgnore]
        public ICollection<AlimentosPorcion> AlimentosPorcion { get; set; }
    }
}
