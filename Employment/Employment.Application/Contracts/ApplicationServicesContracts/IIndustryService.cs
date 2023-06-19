using Employment.Application.Dtos.ApplicationServicesDtos.IndustryDtos;
using Employment.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Contracts.ApplicationServicesContracts
{
    public interface IIndustryService
    {
        Task<CommandResule<int>> AddAsync(AddIndustryDto addIndustryDto);
        GetIndustryDto Get(int id);
        GetListResultDto<GetIndustriesListDto> GetList(GetIndustriesListRequestDto request);
        Task<CommandResule<int>> UpdateAsync(UpdateIndustryDto request);
    }
}
