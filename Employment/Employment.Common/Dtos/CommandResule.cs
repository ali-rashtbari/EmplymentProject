using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Employment.Common.Dtos
{
    public class CommandResule
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }

    }

    public class CommandResule<T> : CommandResule
    {
        public T Data { get; set; } 
    }
}
