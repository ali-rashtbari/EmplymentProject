using Employment.Application.Contracts.PersistanceContracts;
using Employment.Domain;
using Employment.Persistance.Context;
using Employment.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Employment.Persistance
{
    public static class ServiceRegistration
    {
        public static IServiceCollection PersistanceServiceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"));
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;

        }
    }
}
