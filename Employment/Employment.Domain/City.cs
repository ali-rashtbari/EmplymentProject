using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Domain
{
    public class City : DomainBaseEntity<int>
    {


        #region Relations 
        public String Name { get; set; }
        public virtual Province Province { get; set; }
        public int ProvinceId { get; set; }

        public virtual ICollection<JobExperience> JobExperience { get; set; }


        #endregion
    }
}
