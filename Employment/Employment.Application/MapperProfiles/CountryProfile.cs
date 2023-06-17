using AutoMapper;
using Employment.Application.Dtos.ApplicationServicesDtos.CountryDtos;
using Employment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Profile = AutoMapper.Profile;

namespace Employment.Application.MapperProfiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<UpdateCountryDto, Country>();

            CreateMap<Country, GetCountryDto>()
                .ForMember(dest => dest.ProvincesCount, _ => _.MapFrom(src => src.Provinces.Count))
                .ForMember(dest => dest.CitiesCount, _ => _.MapFrom(src => src.Provinces.SelectMany(p => p.Cities).Count()));

            CreateMap<Country, GetCountriesListDto>()
                .ForMember(dest => dest.ProvincesCount, _ => _.MapFrom(src => src.Provinces.Count()))
                .ForMember(dest => dest.ProvincesCount, _ => _.MapFrom(src => src.Provinces.SelectMany(p => p.Cities).Count()));
        }
    }
}
