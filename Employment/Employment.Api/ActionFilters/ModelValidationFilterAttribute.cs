using Employment.Api.Models.AuthModels;
using Employment.Common.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Employment.Api.ActionFilters
{
    public class ModelValidationFilterAttribute : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errorMessage = context.ModelState.Values.SelectMany(v => v.Errors).FirstOrDefault().ErrorMessage;
                ExceptionHelper.ThrowException(message: errorMessage, statusCode: System.Net.HttpStatusCode.BadRequest);
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {}
    }
}
