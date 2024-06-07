
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TVPlus.Application.Interfaces.Repositories;
using TVPlus.Infrastructure.Context;
using TVPlus.Infrastructure.Core;
using TVPlus.Infrastructure.Repositories;

namespace TVPlus.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructurePersLayer(this IServiceCollection services, IConfiguration configuration) 
        {
            if (configuration.GetValue<bool>("InMemoryDatabase"))
            {
                services.AddDbContext<TVPlusContext>(options => options.UseInMemoryDatabase("TVPlusDB"));
            }
            else
            {
                services.AddDbContext<TVPlusContext>(options => options.UseSqlServer(configuration.GetConnectionString("TVPlusContext"),
                    mig => mig.MigrationsAssembly(typeof(TVPlusContext).Assembly.FullName)));
            }

            #region Repositories
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<Interfaces.ISerieRepository, SeriesRepository>();
            services.AddTransient<Interfaces.IProductoraRepository,ProductoraRepository>();
            services.AddTransient<Interfaces.IGeneroRepository, GeneroRepository>();
            #endregion

        }


    }
}
