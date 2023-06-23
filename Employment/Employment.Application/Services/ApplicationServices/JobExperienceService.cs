using AutoMapper;
using Employment.Application.Contracts.ApplicationServicesContracts;
using Employment.Application.Contracts.PersistanceContracts;
using Employment.Application.Dtos.ApplicationServicesDtos.JobExperienceDtos;
using Employment.Application.Dtos.ApplicationServicesDtos.JobExperienceDtos.JobExperienceDtoValidators;
using Employment.Application.Dtos.Validations;
using Employment.Common;
using Employment.Common.Dtos;
using Employment.Common.Exceptions;
using Employment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Services.ApplicationServices
{
    public class JobExperienceService : IJobExperienceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public JobExperienceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommandResule<int>> AddAsync(AddJobExperienceDto addJobExperienceDto)
        {
            var validationResult = await new AddJobExperienceDtoValidator(_unitOfWork).ValidateAsync(addJobExperienceDto);
            if (!validationResult.IsValid) throw new InvalidModelException(validationResult.Errors.FirstOrDefault().ErrorMessage);
            var jobExperience = _mapper.Map<JobExperience>(addJobExperienceDto);
            bool isCurrentJob = addJobExperienceDto.EndDate.HasValue ? false : true;
            jobExperience.IsCurrentJob = isCurrentJob;
            await _unitOfWork.JobExperienceRepository.AddAsync(jobExperience);
            return new CommandResule<int>()
            {
                IsSuccess = true,
                Message = ApplicationMessages.JobExperienceAdded,
                Data = jobExperience.Id
            };
        }

        public GetJobExperienceDto Get(int id)
        {
            var jobExperienceIncludes = new List<string>()
            {
                "JobCategory",
                "City",
                "SeniorityLevel",
                "Industry",
                "Country"
            };
            var jobExperience = _unitOfWork.JobExperienceRepository.Get(id, includes: jobExperienceIncludes);
            if (jobExperience == null) throw new NotFoundException(msg: ApplicationMessages.JobExperienceNotFound,
                                                                   entity: nameof(JobExperience),
                                                                   id: id.ToString());
            var jobExperienceDto = _mapper.Map<GetJobExperienceDto>(jobExperience);
            return jobExperienceDto;
        }
    }
}
