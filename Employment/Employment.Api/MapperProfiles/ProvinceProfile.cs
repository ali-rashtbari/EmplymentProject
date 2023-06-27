using AutoMapper;
using Employment.Api.Models.ProvinceViewModels;
using Employment.Application.Dtos.ApplicationServicesDtos.ProvinceDtos;

namespace Employment.Api.MapperProfiles
{
    public class ProvinceProfile : Profile
    {
        public ProvinceProfile()
        {
            CreateMap<GetProvincesListDto, GetProvincesListToShowInResume>();
        }
    }
}
