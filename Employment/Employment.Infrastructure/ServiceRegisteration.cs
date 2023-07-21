using Employment.Application.Contracts.InfrastructureContracts;
using Employment.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Infrastructure
{
    public static class ServiceRegisteration
    {
        public static IServiceCollection InfrastructureServiceRegisteration(this IServiceCollection services)
        {
            services.AddTransient<IEmailSender>(sp => new EmailSender("localHost", 25, "no-reply@employment.com"));
            services.AddTransient<IFileUploader, FileUploader>();
            return services;
        }
    }
}
