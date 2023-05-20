using Employment.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Domain
{
    public class EducationHistory : DomainBaseEntity
    {
        public string University { get; set; }
        public Degree Degree { get; set; }
        public double GradePointAverage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        

        #region Relations 

        public virtual Resume Resume { get; set; }
        [ForeignKey(nameof(Resume))]
        public int ResumeId { get; set; }

        public virtual Major Major { get; set; }
        [ForeignKey(nameof(Major))]
        public int MajorId { get; set; }    





        #endregion
    }
}
