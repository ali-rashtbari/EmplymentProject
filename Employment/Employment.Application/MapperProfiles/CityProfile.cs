using AutoMapper;
using Employment.Application.Dtos.ApplicationServicesDtos.CityDtos;
using Employment.Common.Dtos;
using Employment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.MapperProfiles
{
    public class CityProfile : AutoMapper.Profile
    {
        public CityProfile()
        {
            CreateMap<City, GetCityDto>()
                .ForMember(dest => dest.ProvinceName, _ => _.MapFrom(src => src.Province.Name))
                .ForMember(dest => dest.CountryName, _ => _.MapFrom(src => src.Province.Country.Name));

            CreateMap<City, GetCitiesListDto>()
                .ForMember(dest => dest.ProvinceName, _ => _.MapFrom(src => src.Province.Name))
                .ForMember(dest => dest.CountryName, _ => _.MapFrom(src => src.Province.Country.Name));

            CreateMap<UpdateCityDto, City>()
                .ForAllMembers(dto => dto.Condition(c => c.ProvinceId != null));
        }
    }
}
