using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ws_proyecto.Entities
{
    public class Roles
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(45, ErrorMessage = "El máximo de caracteres permitidos es de 45")]
        [Required(ErrorMessage = "El campo Rol es obligatorio")]
        public string Rol { get; set; }

        [JsonIgnore]
        public ICollection<UsuariosRoles> UsuariosRoles { get; set; }
    }
}
