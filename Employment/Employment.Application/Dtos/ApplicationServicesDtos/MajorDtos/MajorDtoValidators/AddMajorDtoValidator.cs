using Employment.Application.Contracts.PersistanceContracts;
using Employment.Application.Dtos.ApplicationServicesDtos.MajorDtos;
using Employment.Common;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Dtos.ApplicationServicesDtos.MajorDtos.MajorDtoValidators
{
    public class AddMajorDtoValidator : AbstractValidator<AddMajorDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddMajorDtoValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(m => m.DisplayName)
                .NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .MaximumLength(50).WithMessage("{PropertyName} نمی تواند بیشتر از 50 حرف باشد.")
                .Must(value => value.Length > 3).WithMessage("{PropertyName} باید بیشتر از 3 حرف داشته باشد.")
                .Must(value => !_isMajorNameExists(value)).WithMessage(ApplicationMessages.DuplicateMajor);
        }

        private bool _isMajorNameExists(string name)
        {
            return _unitOfWork.MajorRepository.IsExists(name.ToLower());
        }
    }
}
