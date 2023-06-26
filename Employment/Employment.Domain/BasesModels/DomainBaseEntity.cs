using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Domain.BasesModels
{
    public class DomainBaseEntity<T>
    {
        public T Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsActive { get; set; } = true;
    }

    public class DomainBaseEntity : DomainBaseEntity<int>
    { }

}
