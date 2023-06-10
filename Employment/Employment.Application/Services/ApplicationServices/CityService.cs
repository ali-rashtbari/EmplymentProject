using Employment.Application.Contracts.ApplicationServicesContracts;
using Employment.Application.Contracts.PersistanceContracts;
using Employment.Application.Dtos.ApplicationServicesDtos;
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
    public class CityService : ICityService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<CommandResule<int>> AddAsync(AddCityDto addCityDto)
        {
            var validationResult = await new AddCityDtoValidator(_unitOfWork).ValidateAsync(addCityDto);
            if (!validationResult.IsValid) throw new InvalidModelException(validationResult.Errors.FirstOrDefault().ErrorMessage);
            var city = new City()
            {
                Name = addCityDto.Name,
                ProvinceId = addCityDto.ProvinceId,
            };
            await _unitOfWork.CityRepository.AddAsync(city);
            return new CommandResule<int>()
            {
                IsSuccess = true,
                Message = ApplicationMessages.CityAdded,
                Data = city.Id
            };
        }
    }
}
