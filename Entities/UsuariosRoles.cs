using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ws_proyecto.Entities
{
    public class UsuariosRoles
    {
        [Key]
        public int Id { get; set; }

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

        [Range(1, 9999, ErrorMessage = "El campo Roles es obligatorio")]
        [ForeignKey("RolesId")]
        public int RolesId { get; set; }
        [JsonIgnore]
        public Roles Roles { get; set; }
    }
}
