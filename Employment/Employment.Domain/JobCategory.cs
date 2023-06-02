using Employment.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Domain
{
    public class JobCategory : BaseNamesWithId<int>
    {
        #region Relations 

        public virtual List<JobExperience> JobExperience { get; set; }

        #endregion
    }
}
