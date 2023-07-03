using Employment.Api.Models.AuthModels;
using Employment.Api.Services.JWTServices;
using Employment.Application.MapperProfiles;
using Employment.Domain;
using Employment.Persistance.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Runtime;
using System.Text;

namespace Employment.Api
{
    public static class ServiceRegistration
    {
        public static IServiceCollection EndPointServiceRegistration(this IServiceCollection services, IConfiguration configuration)
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

            var section = configuration.GetSection("JwtOptions");
            services.Configure<JwtOptions>(section);

            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = true;
                options.SaveToken = false;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JwtOptions:Issuer"],
                    ValidAudience = configuration["JwtOptions:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtOptions:Key"]))
                };
            });


            // --- action filters --- //
            services.AddScoped<IJwtService, JwtService>();

            // --- logger --- //
            services.AddSingleton<ILoggerFactory, LoggerFactory>();
            services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));


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

            // auto mapper ---
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
