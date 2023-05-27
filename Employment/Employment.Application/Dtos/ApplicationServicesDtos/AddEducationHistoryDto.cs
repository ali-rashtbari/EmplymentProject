using Employment.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Dtos.ApplicationServicesDtos
{
    public class AddEducationHistoryDto
    {
        public int ResumeId { get; set; }
        public string University { get; set; }
        public Degree Degree { get; set; }
        public double GradePointAverage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int MajorId { get; set; }
    }
}
