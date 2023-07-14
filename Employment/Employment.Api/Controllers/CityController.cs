using AutoMapper;
using Employment.Api.Models.CityViewModels;
using Employment.Application.Contracts.ApplicationServicesContracts;
using Employment.Application.Dtos.ApplicationServicesDtos.CityDtos;
using Employment.Common.Constants;
using Employment.Common.Dtos;
using Employment.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Employment.Api.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IServicesPool _servicesPool;
        private readonly IMapper _mapper;

        public CityController(IServicesPool servicesPool, IMapper mapper)
        {
            _servicesPool = servicesPool;
            _mapper = mapper;
        }


        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] AddCityDto addCityDto)
        {
            CommandResule<int> addResult = await _servicesPool.CityService.AddAsync(addCityDto);
            return CreatedAtAction(actionName: "Get", new { id = addResult.Data }, addResult);
        }

        [HttpGet("Get/{id}")]
        public IActionResult Get(int id)
        {
            var city = _servicesPool.CityService.Get(id);
            return Ok(city);
        }

        [HttpGet("GetList")]
        public IActionResult GetList([FromQuery] GetCitiesListRequestDto getCitiesListRequest)
        {
            GetListResultDto<GetCitiesListDto> pagedCities = _servicesPool.CityService.GetList(getCitiesListRequest);
            Response.Headers.Add(ReponseHeaderValues.PaginationValues, Newtonsoft.Json.JsonConvert.SerializeObject(pagedCities.MetaValues));
            return Ok(pagedCities.Values);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateCityDto editCityDto)
        {
            CommandResule<int> editCityResult = await _servicesPool.CityService.UpdateAsync(editCityDto);
            return Ok(editCityResult);
        }


    }
}
