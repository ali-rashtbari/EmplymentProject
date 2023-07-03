using Employment.Application.Contracts.PersistanceContracts;
using Employment.Application.Dtos.ApplicationServicesDtos.CityDtos;
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
    public class UpdateCityDtoValidator : AbstractValidator<UpdateCityDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IIntIdHahser _intIdHasher;

        public UpdateCityDtoValidator(IUnitOfWork unitOfWork, IIntIdHahser intIdHahser)
        {
            _unitOfWork = unitOfWork;
            _intIdHasher = intIdHahser;

            RuleFor(c => c.EncodedID)
                .NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .Must(value => _isExistsCity(value)).WithMessage(ApplicationMessages.CityNotFound);

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .MaximumLength(50).WithErrorCode("{PropertyName} نمی تواند بیشتر از 50 حرف داشته باشد.");

            When(c => c.DecodedProvinceId.HasValue, () =>
            {
                RuleFor(c => c.EncodedProvinceId)
                .Must(value => _isExistsProvince(value)).WithMessage(ApplicationMessages.ProvinceNotFound);
            });

        }

        private bool _isExistsProvince(string provinceId)
        {
            return _unitOfWork.ProvinceRepository.Get(_intIdHasher.DeCode(provinceId)) != null;
        }

        private bool _isExistsCity(string cityId)
        {
            return _unitOfWork.CityRepository.Get(_intIdHasher.DeCode(cityId)) != null;
        }
    }
}
