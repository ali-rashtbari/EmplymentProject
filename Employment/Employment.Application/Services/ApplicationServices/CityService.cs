using AutoMapper;
using Employment.Application.Contracts.ApplicationServicesContracts;
using Employment.Application.Contracts.PersistanceContracts;
using Employment.Application.Dtos.ApplicationServicesDtos.CityDtos;
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
        private readonly IMapper _mapper;

        public CityService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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
        public GetCityDto Get(int id)
        {
            var includes = new List<string>()
            {
                "Province.Country"
            };
            var city = _unitOfWork.CityRepository.Get(id, includes);
            if (city is null) throw new NotFoundException(msg: ApplicationMessages.CityNotFound, entity: nameof(city), id: id.ToString());
            var cityDto = _mapper.Map<GetCityDto>(city);
            return cityDto;
        }
    }
}
