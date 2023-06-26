using Employment.Domain.BasesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Domain
{
    public class City : DomainBaseEntity<int>, IAuditable
    {
        public String Name { get; set; }
        public virtual Province Province { get; set; }
        public int ProvinceId { get; set; }
        public DateTime DateTimeAdded { get; set; }
        public DateTime? DateTimeModified { get; set; }
        public DateTime? DateTimeDeleted { get; set; }

        #region Relations 

        public virtual ICollection<JobExperience> JobExperiences { get; set; }
 
        #endregion
    }
}
