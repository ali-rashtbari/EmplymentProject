using Employment.Application.Contracts.ApplicationServicesContracts;
using Employment.Application.Contracts.PersistanceContracts;
using Employment.Application.Dtos.ApplicationServicesDtos;
using Employment.Common;
using Employment.Common.Dtos;
using Employment.Common.Exceptions;
using Employment.Domain;
using Microsoft.AspNetCore.Mvc.Formatters;
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

        public async Task<CommandResule<int>> AddAsync(AddProvinceDto addProvinceDto)
        {
            if (_unitOfWork.ProvinceRepository.IsExists(addProvinceDto.Name)) throw new ArgumentException(ApplicationMessages.DuplicateProvince);
            if (_unitOfWork.CountryRepository.Get(addProvinceDto.CountryId) is null) throw new NotFoundException(ApplicationMessages.CountryNotFound,
                                                                                                                  entity: nameof(Country),
                                                                                                                  id: addProvinceDto.CountryId.ToString());
            var province = new Province()
            {
                Name = addProvinceDto.Name,
                CountryId = addProvinceDto.CountryId
            };
            await _unitOfWork.ProvinceRepository.AddAsync(province);
            return new CommandResule<int>()
            {
                IsSuccess = true,
                Message = ApplicationMessages.ProvinceAdded,
                Data = province.Id
            };
        }

    }
}
