using Employment.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Domain
{
    public class City : BaseNamesWithId<int>
    {


        #region Relations 

        public virtual Province Province { get; set; }
        public int ProvinceId { get; set; }

        public virtual ICollection<JobExperience> JobExperience { get; set; }


        #endregion
    }
}
