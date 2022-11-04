using ws_proyecto.Interfaces;
using ws_proyecto.Services;

namespace ws_proyecto.Helpers
{
    public static class ServiceExtensions
    {
        public static void AddCustomServices(this IServiceCollection _services)
        {
            _services.AddScoped<IUsuarios, UsuariosService>();
            _services.AddScoped<IHistorialUsuarios, HistorialUsuariosService>();
            _services.AddScoped<ITipoEjercicio, TipoEjercicioService>();
            _services.AddScoped<IEjercicios, EjerciciosService>();
            _services.AddScoped<IMetodoEjercicio, MetodoEjercicioService>();
            _services.AddScoped<IRutina, RutinaService>();
            _services.AddScoped<ISeries, SeriesService>();
            _services.AddScoped<IDietas, DietasService>();
            _services.AddScoped<ITiposDieta, TiposDietaService>();
            _services.AddScoped<IIngestas, IngestasService>();
            _services.AddScoped<ISeriesEjercicios, SeriesEjerciciosService>();
            _services.AddScoped<IAlimentos, AlimentosService>();
            _services.AddScoped<IUsuarioRutina, UsuarioRutinaService>();
            _services.AddScoped<IAlimentosPorcion, AlimentosPorcionService>();
            _services.AddScoped<IGruposAlimenticios, GruposAlimenticiosService>();
            _services.AddScoped<IIngestaAlimentos, IngestaAlimentosService>();
            _services.AddScoped<IUsuarioDietas, UsuarioDietasService>();
            _services.AddScoped<IHistorialPagos, HistorialPagosService>();
            _services.AddScoped<IDashboard, DashboardService>();
        }
    }
}
