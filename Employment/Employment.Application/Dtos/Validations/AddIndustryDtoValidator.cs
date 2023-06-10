using Employment.Application.Contracts.PersistanceContracts;
using Employment.Application.Dtos.ApplicationServicesDtos;
using Employment.Common;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Dtos.Validations
{
    public class AddIndustryDtoValidator : AbstractValidator<AddIndustryDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddIndustryDtoValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(i => i.Name)
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .Must(value => !_isIndustryNameExists(value)).WithMessage(ApplicationMessages.DuplicateIndustry);
        }

        private bool _isIndustryNameExists(string name)
        {
            return _unitOfWork.IndustryRepository.IsExists(name.ToLower());
        }
    }
}
