using AutoMapper;
using Employment.Application.Dtos.ApplicationServicesDtos.LanguageDtos;
using Employment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Profile = AutoMapper.Profile;

namespace Employment.Application.MapperProfiles
{
    public class LanguageProfile : Profile
    {
        public LanguageProfile()
        {
            CreateMap<AddLanguageDto, Language>();
            CreateMap<Language, GetLanguageDto>()
                .ForMember(dest => dest.ResumesCount, _ => _.MapFrom(src => src.ResumeLanguages.Count()));
        }
    }
}
