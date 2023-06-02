using Employment.Application.Dtos.ApplicationServicesDtos;
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
        Task AddToCountry(int countryId, int provinceId);
    }
}
