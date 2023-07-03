using AutoMapper;
using Employment.Common.Constants;
using Employment.Common.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.MapperProfiles
{
    public static class RegisterAutoMapperProfiles
    {
        public static IServiceCollection RegisterProfiles(this IServiceCollection services)
        {

            services.AddSingleton(provider => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CityProfile(provider.GetService<IIntIdHahser>()));
            }).CreateMapper());

            return services;
        }
    }
}
