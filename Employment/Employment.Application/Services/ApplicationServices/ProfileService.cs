using AutoMapper;
using Employment.Application.Contracts.ApplicationServicesContracts;
using Employment.Application.Contracts.PersistanceContracts;
using Employment.Application.Dtos.ApplicationServicesDtos;
using Employment.Application.Dtos.Validations;
using Employment.Application.MapperProfiles;
using Employment.Common;
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


        public async Task EditAsync(EditProfileDto request)
        {
            var validator = new EditProfileDtoValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid) ExceptionHelper.ThrowException(validationResult.Errors.FirstOrDefault().ErrorMessage, System.Net.HttpStatusCode.BadRequest);
            
            var profile = _unitOfWork.ProfileRepository.Get(request.Id, includes: new List<string>()
            {
                "Resume"
            });

            //if (profile is null) throw new ArgumentNullException(nameof(profile));
            if (profile is null) ExceptionHelper.ThrowException(ApplicationMessages.ProfileNotFound, System.Net.HttpStatusCode.NotFound);
            _mapper.Map(request, profile);
            await _unitOfWork.ProfileRepository.UpdateAsync(profile);

            // check completeness ---
            await _unitOfWork.ProfileRepository.CheckCompleteness(profile);

            await Task.CompletedTask;

        }
    }
}
