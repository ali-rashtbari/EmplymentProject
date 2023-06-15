using Employment.Api.Models.CityViewModels;
using Employment.Application.Dtos.ApplicationServicesDtos.CityDtos;

namespace Employment.Api.MapperProfiles
{
    public class CityProfile : AutoMapper.Profile
    {
        public CityProfile()
        {
            CreateMap<GetCityDto, GetCityToShowModel>();
        }
    }
}
