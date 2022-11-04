using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ws_proyecto.Entities
{
    public class IngestaAlimentos
    {
        [Key]
        public int Id { get; set; }

        [Precision(1, 2)]
        [Required(ErrorMessage = "El campo Cantidad es obligatorio")]
        public int Cantidad { get; set; }

        [Precision(8, 2)]
        [Required(ErrorMessage = "El campo Proteina_g es obligatorio")]
        public decimal Proteina_g { get; set; }

        [Precision(8, 2)]
        [Required(ErrorMessage = "El campo GrasaTotal_g es obligatorio")]
        public decimal GrasaTotal_g { get; set; }

        [Precision(8, 2)]
        [Required(ErrorMessage = "El campo Carbohidratos_g es obligatorio")]
        public decimal Carbohidratos_g { get; set; }


        [Required(ErrorMessage = "El campo Vitaminas es obligatorio")]
        public decimal Energia_KcaL { get; set; }

        [Range(1, 2, ErrorMessage = "El campo Estado es obligatorio")]
        [ForeignKey("EstadosId")]
        public int EstadosId { get; set; }
        [JsonIgnore]
        public Estados? Estados { get; set; }

        [Range(1, 9999, ErrorMessage = "El campo Ingestas es obligatorio")]
        [ForeignKey("IngestasId")]
        public int IngestasId { get; set; }
        [JsonIgnore]
        public Ingestas? Ingestas { get; set; }


        [Range(1, 9999, ErrorMessage = "El campo AlimentosPorcionId es obligatorio")]
        [ForeignKey("AlimentosPorcionId")]
        public int AlimentosPorcionId { get; set; }
        [JsonIgnore]
        public AlimentosPorcion? AlimentosPorcion { get; set; }

    }
}
