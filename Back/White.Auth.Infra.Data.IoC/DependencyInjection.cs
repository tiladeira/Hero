using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using VaiDeEscolar.Domain.Interfaces.Repositories;

using White.Auth.Core.Interfaces.Repositories;
using White.Auth.Core.Interfaces.Services;
using White.Auth.Core.Services;
using White.Auth.Infra.Data.Context;
using White.Auth.Infra.Data.Repository;

namespace White.Auth.Infra.Data.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUnitOfWorkRepository, UnitOfWorkRepository>();

            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IHeroRepository, HeroRepository>();


            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IHeroService, HeroService>();

            return services;
        }
    }
}
