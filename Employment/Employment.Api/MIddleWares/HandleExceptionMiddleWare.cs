using System.Net;
using System.Text.Json;

namespace Employment.Api.MIddleWares
{
    public class HandleExceptionMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<HandleExceptionMiddleWare> _logger;

        public HandleExceptionMiddleWare(RequestDelegate next, ILogger<HandleExceptionMiddleWare> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContent)
        {
            try
            {
                await _next(httpContent);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something was Wrong : {ex}");
                await HandleExceptionAsync(httpContent, ex);
            }
        }


        private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            await httpContext.Response.WriteAsync(new ExceptionDetails()
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = exception.Message
            }.ToString());

        }


    }

    public class ExceptionDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }

}
