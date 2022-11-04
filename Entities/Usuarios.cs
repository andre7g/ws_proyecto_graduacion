using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ws_proyecto.Entities
{
    public class Usuarios
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100, ErrorMessage = "El máximo de caracteres permitidos es de 100")]
        [Required(ErrorMessage = "El campo PrimerNombre es obligatorio")]
        public string Nombres { get; set; }

        [MaxLength(100, ErrorMessage = "El máximo de caracteres permitidos es de 100")]
        [Required(ErrorMessage = "El campo PrimerApellido es obligatorio")]
        public string Apellidos { get; set; }
        public Int64? Dpi { get; set; }

        [MaxLength(10, ErrorMessage = "El máximo de caracteres permitidos es de 10")]
        [Required(ErrorMessage = "El campo Telefono es obligatorio")]
        public string Telefono { get; set; }

        [MaxLength(500, ErrorMessage = "El máximo de caracteres permitidos es de 500")]
        [Required(ErrorMessage = "El campo Direccion es obligatorio")]
        public string Direccion { get; set; }

        [MaxLength(100, ErrorMessage = "El máximo de caracteres permitidos es de 100")]
        public string? Email { get; set; }

        public decimal? Codigo { get; set; }

        [MaxLength(500, ErrorMessage = "El máximo de caracteres permitidos es de 500")]
        public string? Pass { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "El campo Fecha_Nacimiento es obligatorio")]
        public DateTime Fecha_Nacimiento { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "El campo Fecha_Inicio es obligatorio")]
        public DateTime Fecha_Inicio { get; set; }


        //[MaxLength(50, ErrorMessage = "El máximo de caracteres permitidos es de 50")]
        //[Required(ErrorMessage = "El campo Usuario Creación es obligatorio")]
        //public string Usuario_Creacion { get; set; }

        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        //[Required(ErrorMessage = "El campo Fecha Creación es obligatorio")]
        //public DateTime Fecha_Creacion { get; set; }

        //[MaxLength(50, ErrorMessage = "El máximo de caracteres permitidos es de 50")]
        //public string? Usuario_Actualizacion { get; set; }
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        //public DateTime? Fecha_Actualizacion { get; set; }

        [MaxLength(1, ErrorMessage = "El máximo de caracteres permitidos es de 1")]
        [Required(ErrorMessage = "El campo Genero es obligatorio")]
        public string Genero { get; set; }
        
        [Range(1, 2, ErrorMessage = "El campo Estado es obligatorio")]
        [ForeignKey("EstadosId")]
        public int EstadosId { get; set; }
        [JsonIgnore]
        public Estados? Estados { get; set; }
       
        [JsonIgnore]
        public ICollection<HistorialUsuarios>? HistorialUsuarios { get; set; }

        [JsonIgnore]
        public ICollection<HistorialPagos>? HistorialPagos { get; set; }

        [JsonIgnore]
        public ICollection<UsuariosRoles>? UsuariosRoles { get; set; }

        [JsonIgnore]
        public ICollection<UsuariosAlimentos>? UsuariosAlimentos { get; set; }

        [JsonIgnore]
        public ICollection<UsuarioDietas>? UsuarioDietas { get; set; }
        public ICollection<UsuarioRutina>? UsuarioRutina { get; set; }
    }
}
