using AutoMapper;
using Employment.Application.Dtos.ApplicationServicesDtos.IndustryDtos;
using Employment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Profile = AutoMapper.Profile;

namespace Employment.Application.MapperProfiles
{
    public class IndustryProfile : Profile
    {
        public IndustryProfile()
        {
            CreateMap<Industry, GetIndustryDto>();
            CreateMap<Industry, GetIndustriesListDto>();
            CreateMap<UpdateIndustryDto, Industry>();
        }
    }
}
