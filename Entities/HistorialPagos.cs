using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ws_proyecto.Entities
{
    public class HistorialPagos
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaPago { get; set; }

        [MaxLength(20, ErrorMessage = "El máximo de caracteres permitidos es de 20")]
        [Required(ErrorMessage = "El campo Mes es obligatorio")]
        public string Mes { get; set; }
        public int Anio { get; set; }
        public int Numero_mes { get; set; }

        [Range(1, 2, ErrorMessage = "El campo EstadosId es obligatorio")]
        [ForeignKey("EstadosId")]
        public int EstadosId { get; set; }
        [JsonIgnore]
        public Estados? Estados { get; set; }

        [Range(1, 9999, ErrorMessage = "El campo Usuarios es obligatorio")]
        [ForeignKey("UsuariosId")]
        public int UsuariosId { get; set; }
        [JsonIgnore]
        public Usuarios? Usuarios { get; set; }
    }
}
