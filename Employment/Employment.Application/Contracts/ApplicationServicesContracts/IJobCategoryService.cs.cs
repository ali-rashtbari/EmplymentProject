using Employment.Application.Dtos.ApplicationServicesDtos.JobCategoryDtos;
using Employment.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Contracts.ApplicationServicesContracts
{
    public interface IJobCategoryService
    {
        Task<CommandResule<int>> AddAsync(AddJobCategoryDto addJobCategoryDto);
        GetJobCategoryDto Get(int id);
        GetListResultDto<GetJobCategoriesListDto> GetList(GetJobCategoriesListRequetsDto request);
        Task<CommandResule<int>> UpdateAsync(UpdateJobCategoryDto request);
    }
}
