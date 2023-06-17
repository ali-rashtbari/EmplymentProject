using Employment.Application.Contracts.PersistanceContracts;
using Employment.Common;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Dtos.ApplicationServicesDtos.CountryDtos.CountryDtoValidators
{
    public class UpdateCountryDtoValidator : AbstractValidator<UpdateCountryDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCountryDtoValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c.Id)
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .Must(value => _isCountryExists(value)).WithMessage(ApplicationMessages.CountryNotFound);

            RuleFor(c => c.Name)
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .MaximumLength(50).WithErrorCode("{PropertyName} نمی تواند بیشتر از 50 حرف داشته باشد.")
                .MinimumLength(2).WithErrorCode("{PropertyName} باید حداقل دارای23 حرف باشد.");
        }

        private bool _isCountryExists(int countryId)
        {
            return _unitOfWork.CountryRepository.Get(countryId) != null;
        }
    }
}
