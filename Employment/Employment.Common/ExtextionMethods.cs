using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Common
{
    public static class ExtextionMethods
    {
        public static string GetDashSepratedAsString(this DateTime dateTime)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(dateTime.Year.ToString()+"-");
            stringBuilder.Append(dateTime.Month.ToString()+"-");
            stringBuilder.Append(dateTime.Day.ToString());
            return stringBuilder.ToString();
        }
    }
}
