using Employment.Application.Dtos.ApplicationServicesDtos;
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
        public AddProvinceDtoValidator()
        {
            RuleFor(p => p.Name)
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .Must(value => value.Length > 3).WithMessage("{PropertyName} باید حداقل دارای 3 حرف باشد.")
                .MaximumLength(50).WithErrorCode("{PropertyName} نمی تواند بیشتر از 50 حرف داشته باشد.");

           
        }
    }
}
