using Employment.Application.Contracts.PersistanceContracts;
using Employment.Application.Dtos.ApplicationServicesDtos.JobExperienceDtos;
using Employment.Common;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Dtos.ApplicationServicesDtos.JobExperienceDtos.JobExperienceDtoValidators
{
    public class AddJobExperienceDtoValidator : AbstractValidator<AddJobExperienceDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddJobExperienceDtoValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(je => je.ResumeId)
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .Must(value => _isResumeExists(value)).WithMessage(ApplicationMessages.ResumeNotFound);

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

            RuleFor(je => je.CompanyName)
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .MaximumLength(100).WithErrorCode("{PropertyName} نمی تواند بیشتر از 100 حرف داشته باشد.")
                .MinimumLength(3).WithErrorCode("{PropertyName} باید حداقل دارای 3 حرف باشد.");


            RuleFor(je => je.CityId)
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .Must(value => _isCityExists(value)).WithMessage(ApplicationMessages.CityNotFound);

            RuleFor(je => je.Description)
                .MaximumLength(600).WithErrorCode("{PropertyName} نمی تواند بیشتر از 600 حرف داشته باشد.");

            RuleFor(je => je.InductryId)
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .Must(value => _isIndustryExists(value)).WithMessage(ApplicationMessages.IndustryNotFound);

            RuleFor(je => je.JobCategoryId)
                .NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .Must(value => _isJobCategoryExists(value)).WithMessage(ApplicationMessages.JobCategoryNotFound);

            RuleFor(je => je.JobSeniorityLevelId)
                .NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .Must(value => _isJobSeniorityLevelExists(value)).WithMessage(ApplicationMessages.JobSeniorityLeveNotFound);

        }

        private bool _isCityExists(int cityId)
        {
            return _unitOfWork.CityRepository.Get(cityId) != null;
        }

        private bool _isCountryExists(int countryId)
        {
            return _unitOfWork.CountryRepository.Get(countryId) != null;
        }

        private bool _isIndustryExists(int industryId)
        {
            return _unitOfWork.IndustryRepository.Get(industryId) != null;
        }

        private bool _isJobCategoryExists(int jobCategoryId)
        {
            return _unitOfWork.IJobCategoryRepository.Get(jobCategoryId) != null;
        }

        private bool _isJobSeniorityLevelExists(int jobSeniorityLevelId)
        {
            return _unitOfWork.JobSeniorityLevelRepository.Get(jobSeniorityLevelId) != null;
        }

        private bool _isResumeExists(int resumeId)
        {
            return _unitOfWork.ResumeRepository.Get(resumeId) != null;
        }
    }
}
