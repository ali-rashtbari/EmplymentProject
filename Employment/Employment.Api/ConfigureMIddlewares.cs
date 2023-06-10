using Employment.Api.MIddleWares;

namespace Employment.Api
{
    public static class ConfigureMIddlewares
    {
        public static void ConfigureCustomeMiddlewares(this WebApplication app)
        {
            app.UseMiddleware<HandleExceptionMiddleWare>();
            //app.UseMiddleware<ValidationMiddleWare>();
        }
    }
}
