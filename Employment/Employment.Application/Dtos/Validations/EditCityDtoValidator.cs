using Employment.Application.Contracts.PersistanceContracts;
using Employment.Application.Dtos.ApplicationServicesDtos.CityDtos;
using Employment.Common;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Dtos.Validations
{
    public class EditCityDtoValidator : AbstractValidator<EditCityDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditCityDtoValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد");

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .MaximumLength(50).WithErrorCode("{PropertyName} نمی تواند بیشتر از 50 حرف داشته باشد.");

            RuleFor(c => c.ProvinceId)
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .Must(value => _isExistsProvince(value)).WithMessage(ApplicationMessages.ProvinceNotFound);
        }

        private bool _isExistsProvince(int provinceId)
        {
            return _unitOfWork.ProvinceRepository.Get(provinceId) != null;
        }
    }
}
