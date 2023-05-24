using Employment.Application.Contracts.ApplicationServicesContracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection ApplicationServiceRegistration(this IServiceCollection services)
        {
            services.AddScoped<IServicesPool, ServicesPool>();
            services.AddAutoMapper(assemblies: Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
