using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Domain
{
    public class JobExperience : DomainBaseEntity
    {
        public string JobTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsCurrentJob { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }


        #region Relatipons 

        public virtual JobCategory JobCategory { get; set; }
        public int JobCategoryId { get; set; }

        public virtual JobSeniorityLevel SeniorityLevel { get; set; }
        public int JobSeniorityLevelId { get; set; }

        public virtual Industry Inductry { get; set; }
        public int InductryId { get; set; }

        public virtual Country Country { get; set; }
        public int CountryId { get; set; } 

        public virtual City City { get; set; }
        public int CityId { get; set; }

        #endregion
    }
}
