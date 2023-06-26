using Employment.Domain.BasesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Domain
{
    public class Country : DomainBaseEntity<int>, IAuditable
    {
        public string Name { get; set; }
        public DateTime DateTimeAdded { get; set; }
        public DateTime? DateTimeModified { get; set; }
        public DateTime? DateTimeDeleted { get; set; }

        #region Relations 

        public virtual ICollection<Province> Provinces { get; set; }

        #endregion
    }
}
