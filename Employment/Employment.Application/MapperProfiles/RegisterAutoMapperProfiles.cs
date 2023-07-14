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
                cfg.AddProfile(new CityProfile(/*provider.GetService<IIntIdHahser>()*/));
                cfg.AddProfile(new CountryProfile());
                cfg.AddProfile(new EducationHistoryProfile());
                cfg.AddProfile(new IndustryProfile());
                cfg.AddProfile(new JobCategoryProfile());
                cfg.AddProfile(new JobExperienceProfile());
                cfg.AddProfile(new LanguageProfile());
                cfg.AddProfile(new LinkProfile());
                cfg.AddProfile(new ProfileProfile());
            }).CreateMapper());

            return services;
        }
    }
}
