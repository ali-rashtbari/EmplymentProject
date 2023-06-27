using AutoMapper;
using Employment.Application.Contracts.ApplicationServicesContracts;
using Employment.Application.Contracts.PersistanceContracts;
using Employment.Application.Dtos.ApplicationServicesDtos.CountryDtos;
using Employment.Application.Dtos.ApplicationServicesDtos.CountryDtos.CountryDtoValidators;
using Employment.Application.Dtos.Validations;
using Employment.Common;
using Employment.Common.Dtos;
using Employment.Common.Exceptions;
using Employment.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Services.ApplicationServices
{
    public class CountryService : ICountryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CountryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommandResule<int>> AddAsync(AddCountryDto addCountryDto)
        {
            var validationResult = await new AddCountryDtoValidator(_unitOfWork).ValidateAsync(addCountryDto);
            var country = new Country()
            {
                Name = addCountryDto.Name,
            };
            await _unitOfWork.CountryRepository.AddAsync(country);
            return new CommandResule<int>()
            {
                IsSuccess = true,
                Message = ApplicationMessages.CountryAdded,
                Data = country.Id
            };
        }
        public GetCountryDto Get(int id)
        {
            var country = _unitOfWork.CountryRepository.Get(id, includes: new List<string>()
            {
                "Provinces.Cities"
            });
            if (country == null) throw new NotFoundException(msg: ApplicationMessages.CountryNotFound,
                                                             entity: nameof(country),
                                                             id: id.ToString());
            var getCountryDto = _mapper.Map<GetCountryDto>(country);
            return getCountryDto;
        }
        public GetListResultDto<GetCountriesListDto> GetList(GetCountriesListRequestDto getCountriesListRequestDtos)
        {
            var countries = _unitOfWork.CountryRepository.GetAllAsQueryable(includes: new List<string>()
            {
                "Provinces.Cities"
            }).AsNoTracking();
            #region Filters
            if(!string.IsNullOrWhiteSpace(getCountriesListRequestDtos.Search))
            {
                countries = countries.Where(c => c.Name.ToLower().Contains(getCountriesListRequestDtos.Search.ToLower()));
            }
            #endregion
            #region Ordering
            countries = countries.SystemOrderBy(orderBy: getCountriesListRequestDtos.OrderBy,
                                                direction: getCountriesListRequestDtos.OrderDirection);
            #endregion
            #region Paging
            PagedList<Country> pagedList = PagedList<Country>.Create(source: countries,
                                                                     pageSize: getCountriesListRequestDtos.PageSize,
                                                                     pageNumber: getCountriesListRequestDtos.PageNumber,
                                                                     search: getCountriesListRequestDtos.Search);
            #endregion
            var values = _mapper.Map<IReadOnlyList<GetCountriesListDto>>(pagedList);
            var countriesList = new GetListResultDto<GetCountriesListDto>()
            {
                Values = values,
                MetaValues = pagedList.MetaData
            };
            return countriesList;
        }
        public async Task<CommandResule<int>> UpdateAsync(UpdateCountryDto updateCountryDto)
        {
            var validationResult = await new UpdateCountryDtoValidator(_unitOfWork).ValidateAsync(updateCountryDto);
            if (!validationResult.IsValid) throw new InvalidModelException(validationResult.Errors.FirstOrDefault().ErrorMessage);
            Country country = _unitOfWork.CountryRepository.Get(updateCountryDto.Id);
            _mapper.Map(updateCountryDto, country);
            await _unitOfWork.CountryRepository.UpdateAsync(country);
            return new CommandResule<int>()
            {
                IsSuccess = true,
                Message = ApplicationMessages.CountryUpdated,
                Data = country.Id
            };
        }

    }
}
