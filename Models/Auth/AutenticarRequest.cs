using System.ComponentModel.DataAnnotations;

namespace ws_proyecto.Models.Auth
{
    public class AutenticarRequest
    {
        [Required]
        public decimal Codigo { get; set; }
        [Required]
        public string Pass { get; set; }
    }
}
