using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Common.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string message, string resourceName, string resourceIdentifier) : base($"Resource not Found with Message : {message} - Resource Name : {resourceName} - wiht Identifier : {resourceIdentifier}")
        {
            
        }
    }
}
