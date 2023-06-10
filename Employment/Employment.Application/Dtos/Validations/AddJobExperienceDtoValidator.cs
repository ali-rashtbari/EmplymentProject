using Employment.Application.Contracts.PersistanceContracts;
using Employment.Application.Dtos.ApplicationServicesDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Dtos.Validations
{
    public class AddJobExperienceDtoValidator : AbstractValidator<AddJobExperienceDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddJobExperienceDtoValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(je => je.JobTitle)
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .Must(value => value.Length > 3).WithMessage("{PropertyName} باید حداقل دارای 3 حرف باشد.")
                .MaximumLength(100).WithErrorCode("{PropertyName} نمی تواند بیشتر از 100 حرف داشته باشد.");

            RuleFor(je => je.StartDate)
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("{PropertyName} باید مقدار مناسبی داشته باشد.");

            When(je => je.EndDate.HasValue, () =>
            {
                RuleFor(je => je.EndDate)
                    .LessThanOrEqualTo(DateTime.Now).WithMessage("{PropertyName} باید کوچک تر از زمان حال باشد.")
                    .GreaterThan(je => je.StartDate).WithMessage("{PropertyName} باید بزرگتر از زمان شروع کار باشد.");
            });

            RuleFor(je => je.IsCurrentJob)
                .NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد");

            //RuleFor(je => je.CityId)
            //    .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
            //    .NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشد")
            //    .MustAsync(value => _unitOfWork.);

        }
    }
}
