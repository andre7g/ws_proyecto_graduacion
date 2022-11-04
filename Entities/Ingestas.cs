using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ws_proyecto.Entities
{
    public class Ingestas
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "El máximo de caracteres permitidos es de 50")]
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string Nombre { get; set; }

        [MaxLength(1000, ErrorMessage = "El máximo de caracteres permitidos es de 1000")]
        public string? Descripcion { get; set; }
        [Precision(8, 2)]
        public decimal Energia_KcaL { get; set; }

        [Precision(8, 2)]
        public decimal Proteina_g { get; set; }

        [Precision(8, 2)]
        public decimal GrasaTotal_g { get; set; }

        [Precision(8, 2)]
        public decimal Carbohidratos_g { get; set; }

        [Range(1, 2, ErrorMessage = "El campo Estado es obligatorio")]
        [ForeignKey("EstadosId")]
        public int EstadosId { get; set; }
        [JsonIgnore]
        public Estados? Estados { get; set; }

        [Range(1, 9999, ErrorMessage = "El campo Dietas es obligatorio")]
        [ForeignKey("DietasId")]
        public int DietasId { get; set; }
        [JsonIgnore]
        public Dietas? Dietas { get; set; }

        [JsonIgnore]
        public ICollection<IngestaAlimentos>? IngestaAlimentos { get; set; }
    }
}
