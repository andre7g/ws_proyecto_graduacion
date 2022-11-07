using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ws_proyecto.Entities
{
    public class Alimentos
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Código es obligatorio")]
        [Precision(6)]
        public int Codigo { get; set; }

        [MaxLength(100, ErrorMessage = "El máximo de caracteres permitidos es de 100")]
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string Nombre { get; set; }

        [Precision(4, 2)]
        public decimal? AguaPorcentaje { get; set; }

        [Precision(4, 2)]
        public decimal? Energia_KcaL { get; set; }

        [Precision(4, 2)]
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public decimal Proteina_g { get; set; }

        [Precision(4, 2)]
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public decimal GrasaTotal_g { get; set; }

        [Precision(4, 2)]
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public decimal Carbohidratos_g { get; set; }

        [Precision(4, 2)]
        public decimal? FibraDietTotal_g { get; set; }

        [Precision(4, 2)]
        public decimal? Ceniza_g { get; set; }

        [Precision(4, 2)]
        public decimal? Calcio_mg { get; set; }

        [Precision(4, 2)]
        public decimal? Fosforo_mg { get; set; }

        [Precision(4, 2)]
        public decimal? Hierro_mg { get; set; }

        [Precision(4, 2)]
        public decimal? Tiamina_mg { get; set; }

        [Precision(4, 2)]
        public decimal? Riboflavina_mg { get; set; }

        [Precision(4, 2)]
        public decimal? Niacina_mg { get; set; }

        [Precision(4, 2)]
        public decimal? VitC_mg { get; set; }

        [Precision(4, 2)]
        public decimal? VitAEquivRetinol_mcg { get; set; }

        [Precision(4, 2)]
        public decimal? AcGrasasMonoInsat_g { get; set; }

        [Precision(4, 2)]
        public decimal? AcGrasasPoliInsat_g { get; set; }

        [Precision(4, 2)]
        public decimal? AcGrasasSaturadas_g { get; set; }

        [Precision(4, 2)]
        public decimal? Colesterol_mg { get; set; }

        [Precision(4, 2)]
        public decimal? Potasio_mg { get; set; }

        [Precision(4, 2)]
        public decimal? Sodio_mg { get; set; }

        [Precision(4, 2)]
        public decimal? Zinc_mg { get; set; }

        [Precision(4, 2)]
        public decimal? Magnecio_mg { get; set; }

        [Precision(4, 2)]
        public decimal? VitB6_mg { get; set; }

        [Precision(4, 2)]
        public decimal? VitB12_mcg { get; set; }

        [Precision(4, 2)]
        public decimal? AcFolico_mcg { get; set; }

        [Precision(4, 2)]
        public decimal? FolatoEquivFD_mcg { get; set; }

        [Precision(4, 2)]
        public decimal? FraccionComestible { get; set; }

        [Range(1, 2, ErrorMessage = "El campo Estado es obligatorio")]
        [ForeignKey("EstadosId")]
        public int EstadosId { get; set; }
        [JsonIgnore]
        public Estados Estados { get; set; }

        [Range(1, 9999, ErrorMessage = "El campo Grupos Alimenticios es obligatorio")]
        [ForeignKey("GruposAlimenticiosId")]
        public int GruposAlimenticiosId { get; set; }
        [JsonIgnore]
        public GruposAlimenticios GruposAlimenticios { get; set; }


    }
}
