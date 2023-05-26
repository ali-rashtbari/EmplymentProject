using Employment.Common.Exceptions;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Net.Http;

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

        public async Task InvokeAsync(HttpContext httpContext)
        {
            Exception exception = null;

            try
            {
                await _next(httpContext);
            }
            catch (NotFoundException ex)
            {
                httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                exception = ex;
            }
            catch (Exception ex)
            {
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                exception = ex;
            }
            finally
            {
                if(exception is not null)
                {
                    await LogThenHandleException(exception, httpContext);
                }
            }
        }


        private async Task LogThenHandleException(Exception ex, HttpContext httpContext)
        {

            //httpContext.Response.StatusCode = ex switch
            //{
            //    NotFoundException => StatusCodes.Status404NotFound,
            //    InvalidModelException => StatusCodes.Status400BadRequest,
            //    _ => StatusCodes.Status500InternalServerError
            //};

            _logger.LogError($"Something was Wrong : {ex}");
            await HandleExceptionAsync(httpContext, ex);
            await Task.CompletedTask;
        }


        private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "application/json";
            //httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            await httpContext.Response.WriteAsync(new ExceptionDetails()
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = exception.Message
            }.ToString());

        }


    }

}
