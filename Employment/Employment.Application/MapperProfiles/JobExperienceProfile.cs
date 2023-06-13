using AutoMapper;
using Employment.Application.Dtos.ApplicationServicesDtos;
using Employment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Profile = AutoMapper.Profile;

namespace Employment.Application.MapperProfiles
{
    public class JobExperienceProfile : Profile
    {
        public JobExperienceProfile()
        {
            CreateMap<AddJobExperienceDto, JobExperience>();
        }
    }
}
