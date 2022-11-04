using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ws_proyecto.Entities
{
    public class UsuarioRutina
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(45, ErrorMessage = "El máximo de caracteres permitidos es de 45")]
        [Required(ErrorMessage = "El campo Dia es obligatorio")]
        public string Dia { get; set; }

        [Required(ErrorMessage = "El campo OrdenDia es obligatorio")]
        public int OrdenDia { get; set; }


        [Range(1, 10000, ErrorMessage = "El campo RutinaId es obligatorio")]
        [ForeignKey("RutinaId")]
        public int RutinaId { get; set; }
        [JsonIgnore]
        public Rutina? Rutina { get; set; }



        [Range(1, 9999, ErrorMessage = "El campo UsuariosId es obligatorio")]
        [ForeignKey("UsuariosId")]
        public int UsuariosId { get; set; }
        [JsonIgnore]
        public Usuarios? Usuarios { get; set; }



        [Range(1, 9999, ErrorMessage = "El campo EstadosId es obligatorio")]
        [ForeignKey("EstadosId")]
        public int EstadosId { get; set; }
        [JsonIgnore]
        public Estados? Estados { get; set; }
    }
}
