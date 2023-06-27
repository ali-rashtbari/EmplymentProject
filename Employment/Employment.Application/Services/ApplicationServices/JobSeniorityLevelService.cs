using AutoMapper;
using Employment.Application.Contracts.ApplicationServicesContracts;
using Employment.Application.Contracts.PersistanceContracts;
using Employment.Application.Dtos.ApplicationServicesDtos.JobSeriorityLeveDtos;
using Employment.Application.Dtos.ApplicationServicesDtos.JobSeriorityLeveDtos.JobSeniorityLevelDtoValidators;
using Employment.Application.Dtos.Validations;
using Employment.Common;
using Employment.Common.Dtos;
using Employment.Common.Exceptions;
using Employment.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Services.ApplicationServices
{
    public class JobSeniorityLevelService : IJobSeniorityLevelService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public JobSeniorityLevelService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommandResule<int>> AddAsync(AddJobSeniorityLevelDto addJobSeniorityLevelDto)
        {
            var validationResult = await new AddJobSeniorityLevelDtoValidator(_unitOfWork).ValidateAsync(addJobSeniorityLevelDto);
            if (!validationResult.IsValid) throw new InvalidModelException(validationResult.Errors.FirstOrDefault().ErrorMessage);

            var jobSenioirtyLevel = new JobSeniorityLevel()
            {
                Name = addJobSeniorityLevelDto.Name
            };
            await _unitOfWork.JobSeniorityLevelRepository.AddAsync(jobSenioirtyLevel);
            return new CommandResule<int>()
            {
                IsSuccess = true,
                Message = ApplicationMessages.JobSeniorityLevelAdded,
                Data = jobSenioirtyLevel.Id
            };
        }

        public IEnumerable<GetJobSeniorityLevelsListDto> GetList()
        {
            var jobSeniorities = _unitOfWork.JobSeniorityLevelRepository.GetAllAsQueryable().AsNoTracking();
            return jobSeniorities.Select(js => new GetJobSeniorityLevelsListDto()
            {
                Id = js.Id,
                Name = js.Name
            });
        }
    }
}
