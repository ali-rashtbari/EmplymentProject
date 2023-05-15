using Employment.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
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
    }
}
