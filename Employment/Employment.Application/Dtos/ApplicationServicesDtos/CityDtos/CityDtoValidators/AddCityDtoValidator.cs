using Employment.Application.Contracts.PersistanceContracts;
using Employment.Common;
using Employment.Common.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Dtos.ApplicationServicesDtos.CityDtos.CityDtoValidators
{
    public class AddCityDtoValidator : AbstractValidator<AddCityDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IIntIdHahser _intIdHasher;

        public AddCityDtoValidator(IUnitOfWork unitOfWork, IIntIdHahser intIdHahser)
        {
            _intIdHasher = intIdHahser;
            _unitOfWork = unitOfWork;

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .MaximumLength(50).WithErrorCode("{PropertyName} نمی تواند بیشتر از 50 حرف داشته باشد.");

            RuleFor(c => c.EncodedProvinceId)
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .Must(value => _isExistsProvince(value)).WithMessage(ApplicationMessages.ProvinceNotFound);
        }

        private bool _isExistsProvince(string provinceEncodedId)
        {
            return _unitOfWork.ProvinceRepository.Get(_intIdHasher.DeCode(provinceEncodedId)) != null;
        }
    }
}
