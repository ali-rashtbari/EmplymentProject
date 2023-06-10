using AutoMapper;
using Employment.Application.Contracts.ApplicationServicesContracts;
using Employment.Application.Contracts.PersistanceContracts;
using Employment.Application.Dtos.ApplicationServicesDtos;
using Employment.Application.Dtos.Validations;
using Employment.Application.MapperProfiles;
using Employment.Common;
using Employment.Common.Dtos;
using Employment.Common.Exceptions;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Diagnostics;

namespace Employment.Application.Services.ApplicationServices
{
    public class ProfileService : IProfileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProfileService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<CommandResule> EditAsync(EditProfileDto editProfileDto)
        {
            var validationResult = await new EditProfileDtoValidator(_unitOfWork).ValidateAsync(editProfileDto);
            if (!validationResult.IsValid) throw new InvalidModelException(validationResult.Errors.FirstOrDefault().ErrorMessage);

            var profile = _unitOfWork.ProfileRepository.Get(editProfileDto.Id, includes: new List<string>()
            {
                "Resume"
            });
            _mapper.Map(editProfileDto, profile);
            await _unitOfWork.ProfileRepository.UpdateAsync(profile);
            await _unitOfWork.ProfileRepository.CheckCompleteness(profile);
            return new CommandResule()
            {
                IsSuccess = true,
                Message = ApplicationMessages.ProfileEditedSuccessfuly,
            };
        }
    }
}
