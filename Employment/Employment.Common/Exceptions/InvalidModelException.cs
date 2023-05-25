using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Common.Exceptions
{
    public class InvalidModelException : ApplicationException
    {
        public InvalidModelException(string message) : base($"Invalid Model Error with Message : {message}")
        {
            
        }
    }
}
