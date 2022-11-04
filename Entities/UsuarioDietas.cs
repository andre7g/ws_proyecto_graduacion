using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ws_proyecto.Entities
{
    public class UsuarioDietas
    {
        [Key]
        public int Id { get; set; }

        [Range(1, 2, ErrorMessage = "El campo Estado es obligatorio")]
        [ForeignKey("EstadosId")]
        public int EstadosId { get; set; }
        [JsonIgnore]
        public Estados? Estados { get; set; }

        [Range(1, 9999, ErrorMessage = "El campo Dietas es obligatorio")]
        [ForeignKey("DietasId")]
        public int DietasId { get; set; }
        [JsonIgnore]
        public Dietas? Dietas { get; set; }

        [Range(1, 9999, ErrorMessage = "El campo Usuarios es obligatorio")]
        [ForeignKey("UsuariosId")]
        public int UsuariosId { get; set; }
        [JsonIgnore]
        public Usuarios? Usuarios { get; set; }
    }
}
