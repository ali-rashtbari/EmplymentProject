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
    public class AddCountryDtoValidator : AbstractValidator<AddCountryDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddCountryDtoValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c.Name)
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .Must(value => value.Length > 3).WithMessage("{PropertyName} باید حداقل دارای 3 حرف باشد.")
                .MaximumLength(50).WithErrorCode("{PropertyName} نمی تواند بیشتر از 50 حرف داشته باشد.")
                .Must(value => !_isCountryNameExists(value)).WithMessage(ApplicationMessages.DuplicateCountry);
        }


        private bool _isCountryNameExists(string name)
        {
            return _unitOfWork.CountryRepository.IsExists(name.ToLower());
        }
    }
}
