using AutoMapper;
using Employment.Application.Dtos.ApplicationServicesDtos;
using Employment.Application.Dtos.ApplicationServicesDtos.LinkDtos;
using Employment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Profile = AutoMapper.Profile;

namespace Employment.Application.MapperProfiles
{
    public class LinkProfile : Profile
    {
        public LinkProfile()
        {
            CreateMap<AddLinkDto, Link>()
                .ForMember(dest => dest.DisplayName, _ => _.MapFrom(src => src.DisplayName))
                .ForMember(dest => dest.Url, _ => _.MapFrom(src => src.Url));

            CreateMap<Link, GetLinkDto>();
        }
    }
}
