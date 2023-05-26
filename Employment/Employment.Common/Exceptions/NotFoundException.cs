using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string msg, string entity, string id) : base($"Resource '{entity}' with Identifier '{id}' not Found. Message : '{msg}'")
        {  
        }
    }
}
