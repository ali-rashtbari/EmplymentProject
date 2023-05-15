using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Common.Exceptions
{
    public class MainException : Exception
    {
        public ApiResultAsJson Data { get; private set; }

        public MainException(string message, HttpStatusCode statusCode, int? code = null)
        {
            Data = new ApiResultAsJson(message: message, statusCode: statusCode, code: code);
        }
    }
}
