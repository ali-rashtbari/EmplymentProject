using AutoMapper;
using Employment.Application.Contracts.ApplicationServicesContracts;
using Employment.Application.Contracts.PersistanceContracts;
using Employment.Application.Dtos.ApplicationServicesDtos.LanguageDtos;
using Employment.Application.Dtos.ApplicationServicesDtos.LanguageDtos.LanguageDtoValiators;
using Employment.Common;
using Employment.Common.Contracts;
using Employment.Common.Dtos;
using Employment.Common.Exceptions;
using Employment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Services.ApplicationServices
{
    public class LanguageService : ILanguageService, IService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public LanguageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommandResule<int>> AddAsync(AddLanguageDto addLanguageDto)
        {
            var validationResult = await new AddLanguageDtoValidator(_unitOfWork).ValidateAsync(addLanguageDto);
            if (!validationResult.IsValid) throw new InvalidModelException(validationResult.Errors.FirstOrDefault().ErrorMessage);
            var language = _mapper.Map<Language>(addLanguageDto);
            await _unitOfWork.LanguageRepository.AddAsync(language);
            return new CommandResule<int>()
            {
                IsSuccess = true,
                Message = ApplicationMessages.LanguageAdded,
                Data = language.Id
            };
        }

        public async Task<CommandResule<int>> AddToResume(AddLanguageToResumeDto addLanguageToResumeDto)
        {
            var validationResult = await new AddLanguageToResumeDtoValidator(_unitOfWork).ValidateAsync(addLanguageToResumeDto);
            if (!validationResult.IsValid) throw new InvalidModelException(validationResult.Errors.FirstOrDefault().ErrorMessage);
            var resume = _unitOfWork.ResumeRepository.Get(addLanguageToResumeDto.ResumeId, includes: new List<string>()
            {
                "ResumeLanguages"
            });
            resume.ResumeLanguages.Add(new ResumeLanguage()
            {
                LanguageId = addLanguageToResumeDto.LanguageId,
                ResumeId = resume.Id
            });
            await _unitOfWork.SaveChangesAsync();
            return new CommandResule<int>()
            {
                IsSuccess = true,
                Message = ApplicationMessages.LanguageAddedToResume,
                Data = resume.Id
            };
        }

        public GetLanguageDto Get(int id)
        {
            var language = _unitOfWork.LanguageRepository.Get(id, includes: new List<string>()
            {
                "ResumeLanguages"
            });
            if (language is null) throw new NotFoundException(msg: ApplicationMessages.LanguageNotFound,
                                                              entity: nameof(Language),
                                                              id: id.ToString());
            return _mapper.Map<GetLanguageDto>(language);
        }
    }
}
