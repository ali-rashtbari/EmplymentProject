using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Domain.Common
{
    public abstract class BaseNames
    {
        public string Name { get; set; }
    }

    public abstract class BaseNamesWithId<T> : BaseNames
    {
        public T Id { get; set; }
    }

}
