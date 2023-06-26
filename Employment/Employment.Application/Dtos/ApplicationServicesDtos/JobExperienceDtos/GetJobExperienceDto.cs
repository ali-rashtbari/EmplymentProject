using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Dtos.ApplicationServicesDtos.JobExperienceDtos
{
    public class GetJobExperienceDto
    {
        public int Id { get; set; }
        public string JobTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsCurrentJob { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string JobCategory { get; set; }
        public int JobCategoryId { get; set; }
        public string JobSeniorityLevel { get; set; }
        public int JobSeniorityLevelId { get; set; }
        public string Industry { get; set; }
        public int IndustryId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int CityId { get; set; }
    }
}
