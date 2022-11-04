namespace ws_proyecto.Models.Auth
{
    public class AutenticarResponse
    {
        public int id { get; set; }
        public string Usuario { get; set; }
        public string Token { get; set; }

        public List<RolesUsuarioList> Roles { get; set; }
    }
}
