using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employment.Domain.BasesModels;

namespace Employment.Domain
{
    public class JobSeniorityLevel : DomainBaseEntity<int>, IAuditable
    {
        public DateTime DateTimeAdded { get; set; }
        public DateTime? DateTimeModified { get; set; }
        public DateTime? DateTimeDeleted { get; set; }

        #region Relations 
        public string Name { get; set; }
        public virtual ICollection<JobExperience> JobExperiences { get; set; }


        #endregion
    }
}
