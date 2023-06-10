using Employment.Application.Contracts.ApplicationServicesContracts;
using Employment.Application.Contracts.PersistanceContracts;
using Employment.Application.Dtos.ApplicationServicesDtos;
using Employment.Application.Dtos.Validations;
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
            var validationResult = await new AddProvinceDtoValidator(_unitOfWork).ValidateAsync(addProvinceDto);
            if (!validationResult.IsValid) throw new InvalidModelException(validationResult.Errors.FirstOrDefault().ErrorMessage);

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
