using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Common.Exceptions
{
    public class ApiResultAsJson
    {
        public int? Code { get; private set; }
        public string Message { get; private set; }
        public HttpStatusCode StatusCode { get; private set; }

        public ApiResultAsJson(string message, HttpStatusCode statusCode, int? code = null)
        {
            Code = code;
            Message = message;
            StatusCode = statusCode;
        }
    }


    public class ApiResultAsJson<T>
    {
        public int? Code { get; private set; }
        public string Message { get; private set; }
        public HttpStatusCode StatusCode { get; private set; }
        public T Data { get; private set; }

        public ApiResultAsJson(string message, HttpStatusCode statusCode, T data, int? code = null)
        {
            Code = code;
            Message = message;
            StatusCode = statusCode;
            Data = data;
        }
    }

}
