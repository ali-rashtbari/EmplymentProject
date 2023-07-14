using AutoMapper;
using Employment.Application.Contracts.ApplicationServicesContracts;
using Employment.Application.Contracts.PersistanceContracts;
using Employment.Application.Dtos.ApplicationServicesDtos;
using Employment.Application.Dtos.Validations;
using Employment.Application.MapperProfiles;
using Employment.Common;
using Employment.Common.Contracts;
using Employment.Common.Dtos;
using Employment.Common.Exceptions;
using Employment.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Diagnostics;

namespace Employment.Application.Services.ApplicationServices
{
    public class ProfileService : IProfileService, IService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public ProfileService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }


        public async Task<CommandResule> UpdateAsync(EditProfileDto editProfileDto, string userName)
        {
            var validationResult = await new EditProfileDtoValidator(_unitOfWork).ValidateAsync(editProfileDto);
            if (!validationResult.IsValid) throw new InvalidModelException(validationResult.Errors.FirstOrDefault().ErrorMessage);

            var user = await _userManager.FindByNameAsync(userName);
            if (user is null) throw new NotFoundException(msg: ApplicationMessages.UserNameNotFound,
                                                          entity: nameof(User),
                                                          id: userName);
            var userProfile = _unitOfWork.ProfileRepository.GetByUserId(user.Id);
            if (userProfile is null) throw new NotFoundException(msg: ApplicationMessages.ActiveProfileNotFound, entity: nameof(Employment.Domain.Profile), id: user.Id); 
            _mapper.Map(editProfileDto, user.Profile);
            
            using var transaction = await _unitOfWork.BeginTransactionAsync();
            await _unitOfWork.ProfileRepository.UpdateAsync(userProfile);
            await _unitOfWork.ProfileRepository.CheckCompleteness(userProfile);
            await _unitOfWork.CommitAsync();

            return new CommandResule()
            {
                IsSuccess = true,
                Message = ApplicationMessages.ProfileEditedSuccessfuly,
            };
        }
    }
}
