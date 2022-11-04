using Microsoft.EntityFrameworkCore;
using ws_proyecto.Entities;

namespace ws_proyecto.Helpers
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var MysqlConnectionStr = Configuration.GetConnectionString("DefaultConnection");
            options.UseMySql(MysqlConnectionStr, ServerVersion.AutoDetect(MysqlConnectionStr));
        }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Estados> Estados { get; set; }
        public DbSet<HistorialUsuarios> HistorialUsuarios { get; set; }
        public DbSet<Alimentos> Alimentos { get; set; }
        public DbSet<GruposAlimenticios> GruposAlimenticios { get; set; }
        public DbSet<Ejercicios> Ejercicios { get; set; }
        public DbSet<HistorialPagos> HistorialPagos { get; set; }
        public DbSet<MetodoEjercicio> MetodoEjercicio { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Rutina> Rutina { get; set; }
        public DbSet<TipoEjercicio> TipoEjercicio { get; set; }
        public DbSet<UsuariosRoles> UsuariosRoles { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<Dietas> Dietas { get; set; }
        public DbSet<TiposDietas> TiposDietas { get; set; }
        public DbSet<Ingestas> Ingestas { get; set; }
        public DbSet<UnidadMedidas> UnidadMedidas { get; set; }
        public DbSet<IngestaAlimentos> IngestaAlimentos { get; set; }
        public DbSet<UsuarioDietas> UsuarioDietas { get; set; }
        public DbSet<SeriesEjercicios> SeriesEjercicios { get; set; }
        public DbSet<UsuarioRutina> UsuarioRutina { get; set; }
        public DbSet<AlimentosPorcion> AlimentosPorcion { get; set; }
    }
}

