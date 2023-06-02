using Employment.Application.Contracts.ApplicationServicesContracts;
using Employment.Application.Contracts.PersistanceContracts;
using Employment.Application.Dtos.ApplicationServicesDtos;
using Employment.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Services.ApplicationServices
{
    public class ProvinceService : IProvinceService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProvinceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<CommandResule<int>> AddAsync(AddProvinceDto addProvinceDto)
        {
            throw new NotImplementedException();
        }

        public Task AddToCountry(int countryId, int provinceId)
        {
            throw new NotImplementedException();
        }
    }
}
