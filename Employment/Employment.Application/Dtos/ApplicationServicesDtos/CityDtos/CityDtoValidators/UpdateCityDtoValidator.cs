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

        public UpdateCityDtoValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .Must(value => _isExistsCity(value)).WithMessage(ApplicationMessages.CityNotFound);

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .MaximumLength(50).WithErrorCode("{PropertyName} نمی تواند بیشتر از 50 حرف داشته باشد.");

            When(c => c.ProvinceId.HasValue, () =>
            {
                RuleFor(c => c.ProvinceId)
                .Must(pId => _isExistsProvince(pId.Value)).WithMessage(ApplicationMessages.ProvinceNotFound);
            });

        }

        private bool _isExistsProvince(int provinceId)
        {
            return _unitOfWork.ProvinceRepository.Get(provinceId) != null;
        }

        private bool _isExistsCity(int cityId)
        {
            return _unitOfWork.CityRepository.Get(cityId) != null;
        }
    }
}
