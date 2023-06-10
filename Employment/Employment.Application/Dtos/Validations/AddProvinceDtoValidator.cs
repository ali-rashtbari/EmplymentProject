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
    public class AddProvinceDtoValidator : AbstractValidator<AddProvinceDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddProvinceDtoValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(p => p.Name)
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .Must(value => value.Length > 3).WithMessage("{PropertyName} باید حداقل دارای 3 حرف باشد.")
                .MaximumLength(50).WithErrorCode("{PropertyName} نمی تواند بیشتر از 50 حرف داشته باشد.")
                .Must(value => !_isProvinceNameExixts(value)).WithMessage(ApplicationMessages.DuplicateProvince);

            RuleFor(p => p.CountryId)
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .Must(value => _isCountryExists(value)).WithMessage(ApplicationMessages.CountryNotFound);

        }

        private bool _isCountryExists(int countryId)
        {
            return _unitOfWork.CountryRepository.Get(countryId) != null;
        }

        private bool _isProvinceNameExixts(string name)
        {
            return _unitOfWork.ProvinceRepository.IsExists(name.ToLower());
        }
    }
}
