using Employment.Application.Dtos.ApplicationServicesDtos.CountryDtos;
using Employment.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Contracts.ApplicationServicesContracts
{
    public interface ICountryService
    {
        Task<CommandResule<int>> AddAsync(AddCountryDto addCountryDto);
        Task<CommandResule<int>> UpdateAsync(UpdateCountryDto updateCountryDto);
        GetCountryDto Get(int id);
        GetListResultDto<GetCountriesListDto> GetList(GetCountriesListRequestDto getCountriesListRequestDtos);
    }
}
