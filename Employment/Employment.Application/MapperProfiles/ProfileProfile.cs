using AutoMapper;
using Employment.Application.Dtos.ApplicationServicesDtos;

namespace Employment.Application.MapperProfiles
{
    public class ProfileProfile : AutoMapper.Profile
    {
        public ProfileProfile()
        {
            CreateMap<EditProfileDto, Employment.Domain.Profile>()
                .ForMember(des => des.Id, _ => _.MapFrom(src => src.Id))
                .ForMember(des => des.Address, _ => _.MapFrom(src => src.Address))
                .ForMember(des => des.Gender, _ => _.MapFrom(src => src.Gender))
                .ForMember(des => des.Biography, _ => _.MapFrom(src => src.Biography))
                .ForMember(des => des.BirthDate, _ => _.MapFrom(src => src.BirthDate))
                .ForMember(des => des.MaritalStatus, _ => _.MapFrom(src => src.MaritalStatus));

        }
    }

}
