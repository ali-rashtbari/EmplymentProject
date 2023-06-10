namespace Employment.Api.MIddleWares
{
    public class ValidationMiddleWare
    {
        private readonly RequestDelegate _next;

        public ValidationMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var request = httpContext.Request;
            var requestPath = request.Path;

            //var descriptor = GetValidatorDescriptor();
        }
    }
}
