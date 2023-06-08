using Employment.Application.Dtos.ApplicationServicesDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Dtos.Validations
{
    public class AddProvinceToCountryDtoValidator : AbstractValidator<AddProvinceToCountryDto>
    {
        public AddProvinceToCountryDtoValidator()
        {
            RuleFor(pc => pc.CountryId)
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشد");

            RuleFor(pc => pc.ProvinceId)
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشد");
        }
    }
}
