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
        public decimal? Cantidad { get; set; }

        [Precision(6, 2)]
        public decimal? Calorias { get; set; }

        [Precision(6, 2)]
        public decimal? Total { get; set; }

        [Range(1, 2, ErrorMessage = "El campo Estado es obligatorio")]
        [ForeignKey("EstadosId")]
        public int EstadosId { get; set; }
        [JsonIgnore]
        public Estados Estados { get; set; }

        [Range(1, 9999, ErrorMessage = "El campo Usuarios es obligatorio")]
        [ForeignKey("UsuariosId")]
        public int UsuariosId { get; set; }
        [JsonIgnore]
        public Usuarios Usuarios { get; set; }

        [Range(1, 9999, ErrorMessage = "El campo Alimentos es obligatorio")]
        [ForeignKey("AlimentosId")]
        public int AlimentosId { get; set; }
        [JsonIgnore]
        public Alimentos Alimentos { get; set; }
    }
}
