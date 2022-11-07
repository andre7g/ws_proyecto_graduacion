using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ws_proyecto.Entities
{
    public class UsuariosAlimentos
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha_Consumo { get; set; }

        [Precision(6, 2)]
        public int Cantidad { get; set; }

        [Precision(6, 2)]
        public decimal Calorias { get; set; }

        [Precision(8, 2)]
        public decimal Proteina_g { get; set; }
        [Precision(8, 2)]
        public decimal GrasaTotal_g { get; set; }
        [Precision(8, 2)]
        public decimal Carbohidratos_g { get; set; }
        public int? Total { get; set; }

        [Range(1, 9999, ErrorMessage = "El campo Usuarios es obligatorio")]
        [ForeignKey("UsuariosId")]
        public int UsuariosId { get; set; }
        [JsonIgnore]
        public Usuarios? Usuarios { get; set; }

        [Range(1, 10000, ErrorMessage = "El campo AlimentosPorcion es obligatorio")]
        [ForeignKey("EstadAlimentosPorcionIdosId")]
        public int AlimentosPorcionId { get; set; }
        [JsonIgnore]
        public AlimentosPorcion? AlimentosPorcion { get; set; }


        [Range(1, 9999, ErrorMessage = "El campo EstadosId es obligatorio")]
        [ForeignKey("EstadosId")]
        public int EstadosId { get; set; }
        [JsonIgnore]
        public Estados? Estados { get; set; }
    }
}
