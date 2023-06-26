using Employment.Common.Enums;
using Employment.Domain.BasesModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Domain
{
    public class EducationHistory : DomainBaseEntity, IAuditable
    {

        public string University { get; set; }
        public Degree Degree { get; set; }
        public double GradePointAverage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime DateTimeAdded { get; set; }
        public DateTime? DateTimeModified { get; set; }
        public DateTime? DateTimeDeleted { get; set; }

        #region Relations 

        public virtual Resume Resume { get; set; }
        public int ResumeId { get; set; }

        public virtual Major Major { get; set; }
        public int MajorId { get; set; }    

        #endregion
    }
}
