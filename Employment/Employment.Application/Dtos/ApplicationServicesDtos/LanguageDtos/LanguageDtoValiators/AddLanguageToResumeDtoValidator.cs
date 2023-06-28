using Employment.Application.Contracts.PersistanceContracts;
using Employment.Common;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Dtos.ApplicationServicesDtos.LanguageDtos.LanguageDtoValiators
{
    public class AddLanguageToResumeDtoValidator : AbstractValidator<AddLanguageToResumeDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddLanguageToResumeDtoValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(alr => alr.ResumeId)
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .Must(value => _isResumeExists(value)).WithMessage(ApplicationMessages.ResumeNotFound);

            RuleFor(alr => alr.LanguageId)
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .Must(value => _isLanguageExists(value)).WithMessage(ApplicationMessages.LanguageNotFound);

            RuleFor(alr => alr.Level)
                .IsInEnum().WithMessage("{PropertyName} مقدار مناسبی ندارد.");
        }

        private bool _isResumeExists(int resumeId)
        {
            return _unitOfWork.ResumeRepository.Get(resumeId) != null;
        }

        private bool _isLanguageExists(int languageId)
        {
            return _unitOfWork.LanguageRepository.Get(languageId) != null;
        }
    }
}
