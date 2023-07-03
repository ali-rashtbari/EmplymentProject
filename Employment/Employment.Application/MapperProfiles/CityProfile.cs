using AutoMapper;
using Employment.Application.Dtos.ApplicationServicesDtos.CityDtos;
using Employment.Common.Constants;
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
        private readonly IIntIdHahser _intIdHasher;
        public CityProfile(IIntIdHahser intIdHahser)
        {
            _intIdHasher = intIdHahser;
            CreateMap<City, GetCityDto>()
                .ForMember(dest => dest.ProvinceName, _ => _.MapFrom(src => src.Province.Name))
                .ForMember(dest => dest.CountryName, _ => _.MapFrom(src => src.Province.Country.Name))
                .ForMember(dest => dest.Id, _ => _.MapFrom(src => _intIdHasher.Code(src.Id)));

            CreateMap<City, GetCitiesListDto>()
                .ForMember(dest => dest.ProvinceName, _ => _.MapFrom(src => src.Province.Name))
                .ForMember(dest => dest.CountryName, _ => _.MapFrom(src => src.Province.Country.Name))
                .ForMember(dest => dest.Id, _ => _.MapFrom(src => _intIdHasher.Code(src.Id)));

            CreateMap<UpdateCityDto, City>()
                .ForMember(dest => dest.Id, _ => _.MapFrom(src => _intIdHasher.DeCode(src.EncodedID)))
                .ForMember(dest => dest.ProvinceId, _ => _.MapFrom(src => _intIdHasher.DeCode(src.EncodedProvinceId)))
                .ForAllMembers(dto => dto.Condition(c => c.DecodedProvinceId != null));
        }
    }
}
