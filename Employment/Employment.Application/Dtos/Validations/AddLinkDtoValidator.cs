using Employment.Application.Contracts.PersistanceContracts;
using Employment.Application.Dtos.ApplicationServicesDtos;
using Employment.Common;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Dtos.Validations
{
    public class AddLinkDtoValidator : AbstractValidator<AddLinkDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddLinkDtoValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(al => al.ResumeId)
                .NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .GreaterThan(0).WithErrorCode("{PropertyName} مقدار درستی دریافت نکرده است.")
                .Must(value => _isResumeExists(value)).WithMessage(ApplicationMessages.ResumeNotFound)
                .Must(value => _hasValidLinksCount(value)).WithMessage(ApplicationMessages.CantAddMoreLinks);

            RuleFor(al => al.DisplayName)
                .NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .MaximumLength(50).WithMessage("{PropertyName} نمی تواند بیشتر از 50 حرف باشد");

            RuleFor(al => al.Url)
                .NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .MaximumLength(50).WithMessage("{PropertyName} نمی تواند بیشتر از 50 حرف باشد");
        }

        private bool _isResumeExists(int resumeId)
        {
            return _unitOfWork.ResumeRepository.Get(resumeId) != null;
        }

        private bool _hasValidLinksCount(int resumeId)
        {
            return _unitOfWork.ResumeRepository.GetLinksCount(resumeId) <= 5;
        }
    }
}
