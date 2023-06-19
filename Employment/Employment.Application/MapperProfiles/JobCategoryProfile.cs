using AutoMapper;
using Employment.Application.Dtos.ApplicationServicesDtos.JobCategoryDtos;
using Employment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Profile = AutoMapper.Profile;

namespace Employment.Application.MapperProfiles
{
    public class JobCategoryProfile : Profile
    {
        public JobCategoryProfile()
        {
            CreateMap<JobCategory, GetJobCategoryDto>();
            CreateMap<JobCategory, GetJobCategoriesListDto>();
        }
    }
}
