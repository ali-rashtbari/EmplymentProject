using Employment.Application.Dtos.ApplicationServicesDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Dtos.Validations
{
    public class AddMajorDtoValidator : AbstractValidator<AddMajorDto>
    {
        public AddMajorDtoValidator()
        {
            RuleFor(m => m.DisplayName)
                .NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .MaximumLength(50).WithMessage("{PropertyName} نمی تواند بیشتر از 50 حرف باشد.")
                .Must(value => value.Length > 3).WithMessage("{PropertyName} باید بیشتر از 3 حرف داشته باشد.");
        }
    }
}
