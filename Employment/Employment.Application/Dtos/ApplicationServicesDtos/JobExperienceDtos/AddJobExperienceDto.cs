using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Dtos.ApplicationServicesDtos.JobExperienceDtos
{
    public class AddJobExperienceDto
    {
        public int ResumeId { get; set; }
        public string JobTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public int JobCategoryId { get; set; }
        public int JobSeniorityLevelId { get; set; }
        public int InductryId { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
    }
}
