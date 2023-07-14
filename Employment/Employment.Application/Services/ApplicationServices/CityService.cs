using AutoMapper;
using Employment.Application.Contracts.ApplicationServicesContracts;
using Employment.Application.Contracts.PersistanceContracts;
using Employment.Application.Dtos.ApplicationServicesDtos.CityDtos;
using Employment.Application.Dtos.ApplicationServicesDtos.CityDtos.CityDtoValidators;
using Employment.Application.Dtos.Validations;
using Employment.Common;
using Employment.Common.Constants;
using Employment.Common.Contracts;
using Employment.Common.Dtos;
using Employment.Common.Exceptions;
using Employment.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Services.ApplicationServices
{
    public class CityService : ICityService, IService
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
                ProvinceId = addCityDto.ProvinceId.Value,
            };
            await _unitOfWork.CityRepository.AddAsync(city);
            return new CommandResule<int>()
            {
                IsSuccess = true,
                Message = ApplicationMessages.CityAdded,
                Data = city.Id
            };
        }
        public async Task<CommandResule<int>> UpdateAsync(UpdateCityDto updateCityDto)
        {
            var validationResult = await new UpdateCityDtoValidator(_unitOfWork).ValidateAsync(updateCityDto);
            if (!validationResult.IsValid) throw new InvalidModelException(validationResult.Errors.FirstOrDefault().ErrorMessage);
            var city = _unitOfWork.CityRepository.Get(updateCityDto.Id, includes: new List<string>()
            {
                "Province"
            });
            _mapper.Map(updateCityDto, city);
            await _unitOfWork.CityRepository.UpdateAsync(city);
            return new CommandResule<int>()
            {
                IsSuccess = true,
                Message = ApplicationMessages.CityUpdated,
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
            if (city == null) throw new NotFoundException(msg: ApplicationMessages.CityNotFound, entity: nameof(city), id: id.ToString());
            var cityDto = _mapper.Map<GetCityDto>(city);
            return cityDto;
        }
        public GetListResultDto<GetCitiesListDto> GetList(GetCitiesListRequestDto getCitiesListDto)
        {
            var includes = new List<string>()
            {
                "Province.Country"
            };
            var allCities = _unitOfWork.CityRepository.GetAllAsQueryable(includes: includes);
            #region Filters
            if (getCitiesListDto.CountryId.HasValue) allCities = allCities.Where(c => c.Province.CountryId == getCitiesListDto.CountryId.Value);
            if (getCitiesListDto.ProvinceId.HasValue) allCities = allCities.Where(c => c.ProvinceId == getCitiesListDto.ProvinceId.Value);
            #endregion
            #region Ordering
            allCities = allCities.SystemOrderBy(orderBy: getCitiesListDto.OrderBy,
                                                direction: getCitiesListDto.OrderDirection);
            #endregion
            #region Paging
            var pagedList = PagedList<City>.Create(source: allCities,
                                                   pageNumber: getCitiesListDto.PageNumber,
                                                   pageSize: getCitiesListDto.PageSize,
                                                   search: getCitiesListDto.Search);
            #endregion
            var values = _mapper.Map<IReadOnlyList<GetCitiesListDto>>(pagedList);
            var citiesList = new GetListResultDto<GetCitiesListDto>()
            {
                Values = values,
                MetaValues = pagedList.MetaData
            };
            return citiesList;
        }
    }
}
