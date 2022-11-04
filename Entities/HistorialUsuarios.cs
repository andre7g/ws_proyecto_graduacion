using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ws_proyecto.Entities
{
    public class HistorialUsuarios
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El campo Peso es obligatorio")]
        [Precision(6, 2)]
        public decimal Peso { get; set; }

        [Required(ErrorMessage = "El campo Altura es obligatorio")]
        [Precision(6, 2)]
        public decimal Altura { get; set; }

        [Required(ErrorMessage = "El campo IMC es obligatorio")]
        [Precision(6, 2)]
        public decimal IMC { get; set; }

        [Required(ErrorMessage = "El campo Espalda es obligatorio")]
        [Precision(6, 2)]
        public decimal Espalda { get; set; }

        [Required(ErrorMessage = "El campo Pecho es obligatorio")]
        [Precision(6, 2)]
        public decimal Pecho { get; set; }

        [Required(ErrorMessage = "El campo Brazo es obligatorio")]
        [Precision(6, 2)]
        public decimal Brazo { get; set; }

        [Required(ErrorMessage = "El campo Antebrazo es obligatorio")]
        [Precision(6, 2)]
        public decimal Antebrazo { get; set; }

        [Required(ErrorMessage = "El campo Abdomen es obligatorio")]
        [Precision(6, 2)]
        public decimal Abdomen { get; set; }

        [Required(ErrorMessage = "El campo Cintura es obligatorio")]
        [Precision(6, 2)]
        public decimal Cintura { get; set; }

        [Required(ErrorMessage = "El campo Cadera es obligatorio")]
        [Precision(6, 2)]
        public decimal Cadera { get; set; }

        [Required(ErrorMessage = "El campo Pierna es obligatorio")]
        [Precision(6, 2)]
        public decimal Pierna { get; set; }

        [Required(ErrorMessage = "El campo Pantorrilla es obligatorio")]
        [Precision(6, 2)]
        public decimal Pantorrilla { get; set; }

        [Required(ErrorMessage = "El campo GrasaCorporal es obligatorio")]
        [Precision(6, 2)]
        public decimal GrasaCorporal { get; set; }

        [Required(ErrorMessage = "El campo CaloriasConsumir es obligatorio")]
        [Precision(6, 2)]
        public decimal CaloriasConsumir { get; set; }
        [MaxLength(200, ErrorMessage = "El máximo de caracteres permitidos es de 200")]
        public string? Enfermedad { get; set; }
        [MaxLength(200, ErrorMessage = "El máximo de caracteres permitidos es de 200")]
        public string? Medicamentos { get; set; }
        [MaxLength(200, ErrorMessage = "El máximo de caracteres permitidos es de 200")]
        public string? Lesiones { get; set; }
        [MaxLength(200, ErrorMessage = "El máximo de caracteres permitidos es de 200")]
        public string? Observaciones { get; set; }

        [Required(ErrorMessage = "El campo Rating es obligatorio")]
        [Precision(6, 2)]
        public decimal Rating { get; set; }

        [Range(1, 2, ErrorMessage = "El campo Estado es obligatorio")]
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
