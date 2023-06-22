using AutoMapper;
using Employment.Application.Contracts.ApplicationServicesContracts;
using Employment.Application.Contracts.PersistanceContracts;
using Employment.Application.Dtos.ApplicationServicesDtos.JobCategoryDtos;
using Employment.Application.Dtos.ApplicationServicesDtos.JobCategoryDtos.JobCategoryDtoValdators;
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
        private readonly IMapper _mapper;

        public JobCategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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

        public GetJobCategoryDto Get(int id)
        {
            var jobCategory = _unitOfWork.IJobCategoryRepository.Get(id);
            if (jobCategory == null) throw new NotFoundException(msg: ApplicationMessages.JobCategoryNotFound,
                                                                 entity: nameof(JobCategory),
                                                                 id: id.ToString());
            var jobCategoryDto = _mapper.Map<GetJobCategoryDto>(jobCategory);
            return jobCategoryDto;
        }

        public GetListResultDto<GetJobCategoriesListDto> GetList(GetJobCategoriesListRequetsDto request)
        {
            var jobCategories = _unitOfWork.IJobCategoryRepository.GetAllAsQueryable();
            #region Filters
            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                jobCategories = jobCategories.Where(c => c.Name.ToLower().Contains(request.Search.ToLower()));
            }
            #endregion

            #region Ordering
            jobCategories = jobCategories.SystemOrderBy(orderBy: request.OrderBy,
                                                direction: request.OrderDirection);
            #endregion

            #region Paging
            PagedList<JobCategory> pagedList = PagedList<JobCategory>.Create(source: jobCategories,
                                                                             pageSize: request.PageSize,
                                                                             pageNumber: request.PageNumber,
                                                                             search: request.Search);
            #endregion

            var values = _mapper.Map<IReadOnlyList<GetJobCategoriesListDto>>(pagedList);
            var result = new GetListResultDto<GetJobCategoriesListDto>()
            {
                Values = values,
                MetaValues = pagedList.MetaData
            };
            return result;
        }

        public async Task<CommandResule<int>> UpdateAsync(UpdateJobCategoryDto request)
        {
            var validationResult = await new UpdateJobCategoryDtoValidator(_unitOfWork).ValidateAsync(request);
            if (!validationResult.IsValid) throw new InvalidModelException(validationResult.Errors.FirstOrDefault().ErrorMessage);
            var jobCategory = _unitOfWork.IJobCategoryRepository.Get(request.Id);
            _mapper.Map(request, jobCategory);
            await _unitOfWork.IJobCategoryRepository.UpdateAsync(jobCategory);
            return new CommandResule<int>()
            {
                IsSuccess = true,
                Message = ApplicationMessages.JobCategoryUpdated,
                Data = jobCategory.Id
            };
        }
    }
}
