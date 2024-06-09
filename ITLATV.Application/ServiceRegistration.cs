using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TVPlus.Application.Interfaces.Services;
using TVPlus.Application.Services;

namespace TVPlus.Application
{
    public static class ServiceRegistration
    {

        public static void AddApplicationLayer(this IServiceCollection  services, IConfiguration configuration) 
        {

            services.AddTransient<ISerieService, SerieService>();
            services.AddTransient<IGeneroService,GeneroService>();
            services.AddTransient<IProductoraService,ProductoraService>();

        }
    }
}
