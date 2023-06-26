using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Domain.BasesModels
{
    public interface IAuditable
    {
        DateTime DateTimeAdded { get; set; }
        DateTime? DateTimeModified { get; set; }
        DateTime? DateTimeDeleted { get; set; }
    }
}
