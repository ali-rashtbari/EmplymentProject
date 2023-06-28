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
    public class EditProfileDtoValidator : AbstractValidator<EditProfileDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditProfileDtoValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            When(e => !string.IsNullOrWhiteSpace(e.Address), () =>
            {
                RuleFor(e => e.Address).Cascade(cascadeMode: CascadeMode.StopOnFirstFailure)
                                       .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                                       .NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشد")
                                       .MaximumLength(400).WithMessage("{PropertyName} نمی تواند بیشتر از 400 حرف باشد.")
                                       .Must(value => value.Length > 10).WithMessage("{PropertyName} باید بیشتر از 10 حرف باشد.");
            });

            When(e => !string.IsNullOrWhiteSpace(e.Biography), () =>
            {
                RuleFor(e => e.Biography).NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                                         .NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشد")
                                         .MaximumLength(200).WithMessage("{PropertyName} نمی تواند بیشتر از 400 حرف باشد.")
                                         .Must(value => value.Length > 20).WithMessage("{PropertyName} باید بیشتر از 20 حرف باشد.");
            });

            When(e => e.BirthDate is not null, () =>
            {
                RuleFor(e => e.BirthDate).NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                                       .NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشد")
                                       .LessThanOrEqualTo(DateTime.Today.AddYears(-18)).WithMessage("{PropertyName} باید بیشار از 18 سال باشد.");
            });


        }

        private bool _isProfileExists(int profileId)
        {
            return _unitOfWork.ProfileRepository.Get(profileId) != null;
        }

    }
}
