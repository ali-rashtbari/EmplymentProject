using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Common.Exceptions
{
    public static class ExceptionHelper
    {
        private static string _message { get; set; }
        private static int? _code { get; set; }
        private static HttpStatusCode _statusCode { get; set; }

        public static void ThrowException(string message, HttpStatusCode statusCode)
        {
            _splitMessage(message);
            _statusCode = statusCode;

            throw new MainException(_message, statusCode: _statusCode, code: _code);
        }

        public static IActionResult CatchException(MainException ex)
        {
            return new BadRequestObjectResult(new JsonResult(ex.Data));
        }

        private static void _splitMessage(string message)
        {
            var splitedMessage = message.Split("-").ToList();
            splitedMessage.ForEach(sm =>
            {
                var parseResult = int.TryParse(sm, out int code);
                if(parseResult is false)
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
