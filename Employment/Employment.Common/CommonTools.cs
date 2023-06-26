using Employment.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Net;

namespace Employment.Common
{
    public static class CommonTools
    {
        private static string _message { get; set; }
        private static int _code { get; set; }

        /// <summary>
        /// create and return api action result as new json result.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="statusCode"></param>
        /// <returns>a new Instance of ApiResultAsJson</returns>
        public static IActionResult ReturnResultAsJson(string message, HttpStatusCode statusCode)
        {
            _splitMessage(message);
            var result = new ApiResultAsJson(message: _message, statusCode: statusCode, code: _code);
            return new JsonResult(result);
        }
        public static IActionResult ReturnResultAsJson<T>(string message, HttpStatusCode statusCode, T data)
        {
            _splitMessage(message);
            var result = new ApiResultAsJson(message: _message, statusCode: statusCode, code: _code);
            return new JsonResult(new { Value = result, Data = data });
        }
        /// <summary>
        /// split api result message and seprate the message and the message code.
        /// </summary>
        /// <param name="message"></param>
        private static void _splitMessage(string message)
        {
            var splitedMessage = message.Split("-").ToList();
            splitedMessage.ForEach(sm =>
            {
                var parseResult = int.TryParse(sm, out int code);
                if (parseResult is false)
                {
                    _message = sm;
                }
                else
                {
                    _code = code;
                }
            });
        }
        public static Expression<Func<T, bool>> GetLambdaExpression<T, Param>(string leftParam, Param rightParam)
        {
            // This expression is lambad : e => e.Id == id
            var parameter = Expression.Parameter(typeof(T));
            var left = Expression.Property(parameter, leftParam);
            var right = Expression.Constant(rightParam);
            var equal = Expression.Equal(left, right);
            var lambdaExpression = Expression.Lambda<Func<T, bool>>(equal, parameter);

            return lambdaExpression;
        }
        public static IQueryable<T> SystemOrderBy<T>(this IQueryable<T> source, string? orderBy = "Id", string? direction = "asc")
        {
            //if (orderBy == null) orderBy = "Id";
            //if (direction == null) direction = "asc";
            ParameterExpression parameter = Expression.Parameter(source.ElementType, "");
            MemberExpression property = Expression.Property(parameter, orderBy);
            LambdaExpression lambda = Expression.Lambda(property, parameter);
            var methodName = direction.ToLower() == "asc" ? "OrderBy" : "OrderByDescending";
            Expression methodCallExpression = Expression.Call(typeof(Queryable), methodName,
                                  new Type[] { source.ElementType, property.Type },
                                  source.Expression, Expression.Quote(lambda));
            return source.Provider.CreateQuery<T>(methodCallExpression);
        }
        public static string GetDashSepratedStr(DateTime dateTime)
        {
            var year = dateTime.Year;
            var month = dateTime.Month;
            var day = dateTime.Day;
            return $"{year}-{month}-{day}";
        }
    }
}
