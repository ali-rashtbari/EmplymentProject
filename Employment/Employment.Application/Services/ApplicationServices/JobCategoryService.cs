using Employment.Application.Contracts.ApplicationServicesContracts;
using Employment.Application.Contracts.PersistanceContracts;
using Employment.Application.Dtos.ApplicationServicesDtos;
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
    public class JobCategoryService : IJobCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public JobCategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CommandResule<int>> AddAsync(AddJobCategoryDto addJobCategoryDto)
        {
            var validationResult = await new AddJobCategoryDtoValidator(_unitOfWork).ValidateAsync(addJobCategoryDto);
            if (!validationResult.IsValid) throw new InvalidModelException(validationResult.Errors.FirstOrDefault().ErrorMessage);

            var jobCategory = new JobCategory()
            {
                Name = addJobCategoryDto.Name,
            };
            await _unitOfWork.IJobCategoryRepository.AddAsync(jobCategory);
            return new CommandResule<int>()
            {
                IsSuccess = true,
                Message = ApplicationMessages.JobCategoryAdded,
                Data = jobCategory.Id
            };
        }
    }
}
