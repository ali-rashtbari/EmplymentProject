using Employment.Api.ActionFilters;
using Employment.Domain;
using Employment.Persistance.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime;

namespace Employment.Api
{
    public static class ServiceRegistration
    {
        public static IServiceCollection EndPointServiceRegistration(this IServiceCollection services)
        {

            services.AddIdentity<User, Role>(options =>
            {
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
                options.Lockout.MaxFailedAccessAttempts = 3;
            }).AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();


            // --- action filters --- //
            services.AddScoped<ModelValidationFilterAttribute>();

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.SlidingExpiration = false;
                options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                options.ExpireTimeSpan = TimeSpan.FromHours(1);

                options.LoginPath = new PathString("/api/auth/signIn");
                options.AccessDeniedPath = new PathString("/api/auth/accessDenied");
                options.LogoutPath = new PathString("/api/auth/signOut");
                options.Cookie.Name = "EmploymentCookies";  
            });

            return services;
        }
    }
}
