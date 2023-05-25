using Employment.Application.Dtos.ApplicationServicesDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Dtos.Validations
{
    public class AddLinkDtoValidator : AbstractValidator<AddLinkDto>
    {
        public AddLinkDtoValidator()
        {
            RuleFor(al => al.ResumeId)
                .NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .GreaterThan(0).WithErrorCode("{PropertyName} مقدار درستی دریافت نکرده است.");


            RuleFor(al => al.DisplayName)
                .NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .MaximumLength(50).WithMessage("{PropertyName} نمی تواند بیشتر از 50 حرف باشد");

            RuleFor(al => al.Url)
                .NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .MaximumLength(50).WithMessage("{PropertyName} نمی تواند بیشتر از 50 حرف باشد");
        }
    }
}
