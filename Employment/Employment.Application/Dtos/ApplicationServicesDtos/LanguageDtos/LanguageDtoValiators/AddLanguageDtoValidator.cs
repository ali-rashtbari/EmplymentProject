using Employment.Application.Contracts.PersistanceContracts;
using Employment.Common;
using Employment.Common.Enums;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Dtos.ApplicationServicesDtos.LanguageDtos.LanguageDtoValiators
{
    public class AddLanguageDtoValidator : AbstractValidator<AddLanguageDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddLanguageDtoValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(l => l.Name)
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .MaximumLength(50).WithErrorCode("{PropertyName} نمی تواند بیشتر از 50 حرف داشته باشد.")
                .MinimumLength(3).WithErrorCode("{PropertyName} باید حداقل دارای 3 حرف باشد.");

        }

        private bool _isResumeExists(int resumeId)
        {
            return _unitOfWork.ResumeRepository.Get(resumeId) != null;
        }
    }
}
