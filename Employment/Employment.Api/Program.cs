using Employment.Api;
using Employment.Api.ActionFilters;
using Employment.Domain;
using Employment.Persistance;
using Employment.Persistance.Context;
using Employment.Persistance.ExtensionMethods;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigureServices(builder.Services, builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
Configure(app);


void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.PersistanceServiceRegistration(configuration);
    services.EndPointServiceRegistration();

    services.AddControllers()
        .AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        });

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