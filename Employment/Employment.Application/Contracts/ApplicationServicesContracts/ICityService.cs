using Employment.Application.Dtos.ApplicationServicesDtos.CityDtos;
using Employment.Application.Dtos.CommonDto;
using Employment.Common.Dtos;
using Employment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Contracts.ApplicationServicesContracts
{
    public interface ICityService
    {
        Task<CommandResule<int>> AddAsync(AddCityDto addCityDto);
        Task<CommandResule<string>> UpdateAsync(UpdateCityDto editCityDto);
        GetCityDto Get(GetDetailsRequestDto getDetailsRequest);
        GetListResultDto<GetCitiesListDto> GetList(GetCitiesListRequestDto getCitiesListDto);
    }
}
