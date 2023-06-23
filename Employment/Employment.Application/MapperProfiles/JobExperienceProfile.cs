using AutoMapper;
using Employment.Application.Dtos.ApplicationServicesDtos.JobExperienceDtos;
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
            CreateMap<JobExperience, GetJobExperienceDto>()
                .ForMember(dest => dest.Industry, _ => _.MapFrom(src => src.Industry.Name))
                .ForMember(dest => dest.JobCategory, _ => _.MapFrom(src => src.JobCategory.Name))
                .ForMember(dest => dest.City, _ => _.MapFrom(src => src.City.Name))
                .ForMember(dest => dest.Country, _ => _.MapFrom(src => src.Country.Name))
                .ForMember(dest => dest.JobSeniorityLevel, _ => _.MapFrom(src => src.SeniorityLevel.Name));

        }
    }
}
