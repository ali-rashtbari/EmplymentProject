using Autofac;
using Autofac.Extras.DynamicProxy;
using Employment.Application.Contracts.ApplicationServicesContracts;
using Employment.Application.Contracts.PersistanceContracts;
using Employment.Application.Services;
using Employment.Application.Services.ApplicationServices;
using Employment.Domain;
using Employment.Persistance.Context;
using Employment.Persistance.Interceptors;
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

            services.AddSingleton<UpdateAuditableEntitiesDateTimeInterceptor>();

            services.AddDbContext<AppDbContext>((serviceProvider, options) =>
            {
                var updateAuditableEntitiesInterceptor = serviceProvider.GetService<UpdateAuditableEntitiesDateTimeInterceptor>();

                options.UseSqlServer(configuration.GetConnectionString("Default"), o =>
                {
                    o.UseQuerySplittingBehavior(querySplittingBehavior: QuerySplittingBehavior.SplitQuery);
                })/*.AddInterceptors(updateAuditableEntitiesInterceptor)*/;
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;

        }

        //public static ContainerBuilder PersistanceAutoFacServiceRegisteration(this ContainerBuilder builder)
        //{

        //    builder.RegisterType<ServicesInterceptor>()
        //        .AsSelf()
        //        .InstancePerLifetimeScope();

        //    builder.RegisterType<ServicesPool>()
        //        .As<IServicesPool>()
        //        .InstancePerLifetimeScope();

        //    builder.RegisterType<CityService>()
        //        .As<ICityService>()
        //        .EnableInterfaceInterceptors()
        //        .InterceptedBy(typeof(ServicesInterceptor))
        //        .InstancePerDependency();

        //    return builder;
        //}
    }
}
