using Employment.Application.Contracts.PersistanceContracts;
using Employment.Common;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Dtos.ApplicationServicesDtos.IndustryDtos.IndustryDtoValidators
{
    public class UpdateIndustryDtoValidator : AbstractValidator<UpdateIndustryDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateIndustryDtoValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(ind => ind.Id)
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .Must(value => _isIndustryExists(value)).WithMessage(ApplicationMessages.IndustryNotFound);

            RuleFor(ind => ind.Name)
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .MaximumLength(50).WithErrorCode("{PropertyName} نمی تواند بیشتر از 50 حرف داشته باشد.")
                .MinimumLength(3).WithErrorCode("{PropertyName} باید حداقل دارای 3 حرف باشد.");;
        }

        private bool _isIndustryExists(int id)
        {
            return _unitOfWork.IndustryRepository.Get(id) != null; 
        }
    }
}
