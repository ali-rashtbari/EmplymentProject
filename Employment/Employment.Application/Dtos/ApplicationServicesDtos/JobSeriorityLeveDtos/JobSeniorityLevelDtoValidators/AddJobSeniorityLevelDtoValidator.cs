using Employment.Application.Contracts.PersistanceContracts;
using Employment.Application.Dtos.ApplicationServicesDtos.JobSeriorityLeveDtos;
using Employment.Common;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Dtos.ApplicationServicesDtos.JobSeriorityLeveDtos.JobSeniorityLevelDtoValidators
{
    public class AddJobSeniorityLevelDtoValidator : AbstractValidator<AddJobSeniorityLevelDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddJobSeniorityLevelDtoValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(jsl => jsl.Name)
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .Must(value => !_isJobSeniorityLeveNameExists(value)).WithMessage(ApplicationMessages.DuplicateJobSeniorityLevel);
        }

        private bool _isJobSeniorityLeveNameExists(string name)
        {
            return _unitOfWork.JobSeniorityLevelRepository.IsExists(name.ToLower());
        }
    }
}
