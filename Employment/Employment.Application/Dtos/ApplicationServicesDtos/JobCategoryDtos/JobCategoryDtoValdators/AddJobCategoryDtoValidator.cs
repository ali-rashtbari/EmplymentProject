using Employment.Application.Contracts.PersistanceContracts;
using Employment.Common;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Dtos.ApplicationServicesDtos.JobCategoryDtos.JobCategoryDtoValdators
{
    public class AddJobCategoryDtoValidator : AbstractValidator<AddJobCategoryDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddJobCategoryDtoValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(jc => jc.Name)
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .Must(value => !_isJobCategoryNameExists(value)).WithMessage(ApplicationMessages.DuplicateJobCategory);
        }

        private bool _isJobCategoryNameExists(string name)
        {
            return _unitOfWork.IJobCategoryRepository.IsExists(name.ToLower());
        }
    }
}
