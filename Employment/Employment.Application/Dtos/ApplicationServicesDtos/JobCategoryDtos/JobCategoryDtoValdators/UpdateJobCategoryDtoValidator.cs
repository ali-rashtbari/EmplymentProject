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
    public class UpdateJobCategoryDtoValidator : AbstractValidator<UpdateJobCategoryDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateJobCategoryDtoValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(jc => jc.Id)
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .Must(value => _isJobCategoryExists(value)).WithMessage(ApplicationMessages.JobCategoryNotFound);

            RuleFor(jc => jc.Name)
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .MaximumLength(50).WithErrorCode("{PropertyName} نمی تواند بیشتر از 50 حرف داشته باشد.")
                .MinimumLength(3).WithErrorCode("{PropertyName} باید حداقل دارای 3 حرف باشد.");;
        }

        private bool _isJobCategoryExists(int id)
        {
            return _unitOfWork.IJobCategoryRepository.Get(id) != null;
        }
    }
}
