using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employment.Domain.BasesModels;

namespace Employment.Domain
{
    public class Province : DomainBaseEntity<int>, IAuditable
    {
        public string Name { get; set; }
        public virtual Country Country { get; set; }
        public int CountryId { get; set; }
        public DateTime DateTimeAdded { get; set; }
        public DateTime? DateTimeModified { get; set; }
        public DateTime? DateTimeDeleted { get; set; }

        #region Relations 

        public virtual ICollection<City> Cities { get; set; }

        #endregion
    }
}
