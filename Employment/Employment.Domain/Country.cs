using Employment.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Domain
{
    public class Country : BaseNamesWithId<int>
    {


        #region Relations 

        public virtual ICollection<Province> Provinces { get; set; }
        public virtual ICollection<JobExperience> JobExperience { get; set; }

        #endregion
    }
}
