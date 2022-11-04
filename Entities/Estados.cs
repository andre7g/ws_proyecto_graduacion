using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ws_proyecto.Entities
{
    public class Estados
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(45, ErrorMessage = "El máximo de caracteres permitidos es de 45")]
        [Required(ErrorMessage = "El campo Usuarios es obligatorio")]
        public string Estado { get; set; }

        [JsonIgnore]
        public ICollection<Usuarios> Usuarios { get; set; }

        [JsonIgnore]
        public ICollection<HistorialUsuarios> HistorialUsuarios { get; set; }

        [JsonIgnore]
        public ICollection<Alimentos> Alimentos { get; set; }

        [JsonIgnore]
        public ICollection<GruposAlimenticios> GruposAlimenticios { get; set; }

        [JsonIgnore]
        public ICollection<Ejercicios> Ejercicio { get; set; }

        [JsonIgnore]
        public ICollection<HistorialPagos> HistorialPagos { get; set; }

        [JsonIgnore]
        public ICollection<MetodoEjercicio> MetodoEjercicio { get; set; }

        [JsonIgnore]
        public ICollection<Rutina> Rutina { get; set; }

        [JsonIgnore]
        public ICollection<TipoEjercicio> TipoEjercicio { get; set; }

        [JsonIgnore]
        public ICollection<UsuariosRoles> UsuariosRoles { get; set; }

        [JsonIgnore]
        public ICollection<Series> Series { get; set; }

        [JsonIgnore]
        public ICollection<UsuariosAlimentos> UsuariosAlimentos { get; set; }

        [JsonIgnore]
        public ICollection<Dietas> Dietas { get; set; }

        [JsonIgnore]
        public ICollection<TiposDietas> TiposDieta { get; set; }

        [JsonIgnore]
        public ICollection<Ingestas> Ingestas { get; set; }

        [JsonIgnore]
        public ICollection<UnidadMedidas> UnidadMedidas { get; set; }

        [JsonIgnore]
        public ICollection<IngestaAlimentos> IngestaAlimentos { get; set; }

        [JsonIgnore]
        public ICollection<UsuarioDietas> UsuarioDietas { get; set; }

        [JsonIgnore]
        public ICollection<SeriesEjercicios>? SeriesEjercicios { get; set; }
        [JsonIgnore]
        public ICollection<UsuarioRutina>? UsuarioRutina { get; set; }
        [JsonIgnore]
        public ICollection<AlimentosPorcion> AlimentosPorcion { get; set; }
    }
}
