using Employment.Api.MIddleWares;

namespace Employment.Api
{
    public static class ConfigureMIddlewares
    {
        public static void ConfigureExceptionHandlerMiddleware(this WebApplication app)
        {
            app.UseMiddleware<HandleExceptionMiddleWare>();
        }
    }
}
