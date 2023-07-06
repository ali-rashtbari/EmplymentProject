using Employment.Api;
using Employment.Application;
using Employment.Persistance;
using Employment.Persistance.Context;
using Employment.Persistance.ExtensionMethods;
using Microsoft.OpenApi.Models;
using FluentValidation.AspNetCore;
using Serilog.AspNetCore;
using Serilog;
using Serilog.Extensions;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Employment.Common.Constants;
using Employment.Common.Services;
using Employment.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

#region AddSerilog
var logger = new LoggerConfiguration()
    //.WriteTo.File($"../Logs/EmploymentLogs-{DateTime.Now.Year}/{DateTime.Now.Month}/{DateTime.Now.Day}  {DateTime.Now.Hour}:{DateTime.Now.Minute}.txt",
    //               Serilog.Events.LogEventLevel.Information,
    //               outputTemplate: "{Timestamp} [{Level}] {Message}{NewLine}{Exception}")
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
#endregion


// Add services to the container.
ConfigureServices(builder.Services, builder.Configuration);


// add services to autofac ioc container ---
ConfigureContainer(builder);

var app = builder.Build();


// Configure the HTTP request pipeline.
Configure(app);


void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.PersistanceServiceRegistration(configuration);
    services.EndPointServiceRegistration(configuration);
    services.ApplicationServiceRegistration();
    services.InfrastructureServiceRegisteration();

    services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });
    services.AddSingleton<IIntIdHahser, IntIdHahser>();

    //services.AddSignalR(options =>
    //{
    //    options.EnableDetailedErrors = true;
    //});

    services.AddEndpointsApiExplorer();

    // --- swagger --- //
    services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Employment App",
            Version = "v1",
            Contact = new OpenApiContact()
            {
                Email = "dev.alirashtbari@gmail.com",
                Name = "ali",
            },
        });

        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        {
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
        });



    });

    // --- cors --- //
    services.AddCors(options =>
    {
        options.AddPolicy("CorsPolicy", bulder =>
        {
            bulder.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
    });
}


void Configure(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Employment v1");
            options.DocExpansion(docExpansion: Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
        });
        app.UseDeveloperExceptionPage();

    }

    app.ConfigureCustomeMiddlewares();

    app.UseHttpsRedirection();

    app.UseAuthentication();
    app.UseAuthorization();


    app.UseCors("CorsPolicy");


    app.MapControllers();

    using (IServiceScope scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetService<AppDbContext>();
        //await context.Database.MigrateAsync();
        context.Seed();
    }

    app.Run();
}

void ConfigureContainer(WebApplicationBuilder builder)
{

    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

    builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
    {

        builder.PersistanceAutoFacServiceRegisteration();

    });

}