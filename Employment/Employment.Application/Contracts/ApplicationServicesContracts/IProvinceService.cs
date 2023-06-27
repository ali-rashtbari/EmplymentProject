using Employment.Application.Dtos.ApplicationServicesDtos.ProvinceDtos;
using Employment.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Contracts.ApplicationServicesContracts
{
    public interface IProvinceService
    {
        Task<CommandResule<int>> AddAsync(AddProvinceDto addProvinceDto);
        IEnumerable<GetProvincesListDto> GetList(int countryId);
    }
}
