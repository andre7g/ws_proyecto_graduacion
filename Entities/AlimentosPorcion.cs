using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ws_proyecto.Entities
{
    public class AlimentosPorcion
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Código es obligatorio")]
        [Precision(6)]
        public int CodigoAlimento { get; set; }
        [MaxLength(300, ErrorMessage = "El máximo de caracteres permitidos es de 300")]
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string Nombre { get; set; }

        [MaxLength(100, ErrorMessage = "El máximo de caracteres permitidos es de 100")]
        [Required(ErrorMessage = "El campo Porcion es obligatorio")]
        public string Porcion { get; set; }

        [Precision(4, 2)]
        [Required(ErrorMessage = "El campo PesoGramos es obligatorio")]
        public decimal PesoGramos { get; set; }


        [Precision(4, 2)]
        public decimal? Proteina_g { get; set; }

        [Precision(4, 2)]
        public decimal? GrasaTotal_g { get; set; }

        [Precision(4, 2)]
        public decimal? Carbohidratos_g { get; set; }

        [Precision(4, 2)]
        public decimal? Energia_KcaL { get; set; }

        [Range(1, 2, ErrorMessage = "El campo Estado es obligatorio")]
        [ForeignKey("EstadosId")]
        public int EstadosId { get; set; }
        [JsonIgnore]
        public Estados? Estados { get; set; }

        [Range(1, 9999, ErrorMessage = "El campo Grupos Alimenticios es obligatorio")]
        [ForeignKey("GruposAlimenticiosId")]
        public int GruposAlimenticiosId { get; set; }
        [JsonIgnore]
        public GruposAlimenticios? GruposAlimenticios { get; set; }
        [JsonIgnore]
        public ICollection<IngestaAlimentos>? IngestaAlimentos { get; set; }
        
    }
}
