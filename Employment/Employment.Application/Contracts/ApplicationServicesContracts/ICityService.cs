﻿using Employment.Application.Dtos.ApplicationServicesDtos.CityDtos;
using Employment.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Contracts.ApplicationServicesContracts
{
    public interface ICityService
    {
        Task<CommandResule<int>> AddAsync(AddCityDto addCityDto);
        Task<CommandResule<int>> UpdateAsync(UpdateCityDto editCityDto);
        GetCityDto Get(int id);
        GetListResultDto<GetCitiesListDto> GetList(GetCitiesListRequestDto getCitiesListDto);
    }
}
