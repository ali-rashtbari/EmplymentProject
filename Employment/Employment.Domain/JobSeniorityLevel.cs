using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Domain
{
    public class JobSeniorityLevel : DomainBaseEntity<int>
    {
        #region Relations 
        public string Name { get; set; }
        public virtual ICollection<JobExperience> JobExperiences { get; set; }


        #endregion
    }
}
