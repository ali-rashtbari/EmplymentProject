using Employment.Application.Contracts.ApplicationServicesContracts;
using Employment.Application.Dtos.ApplicationServicesDtos.CountryDtos;
using Employment.Application.Dtos.Validations;
using Employment.Common.Constants;
using Employment.Common.Dtos;
using Employment.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employment.Api.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IServicesPool _servicesPool;

        public CountryController(IServicesPool servicesPool)
        {
            _servicesPool = servicesPool;
        }


        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] AddCountryDto addCountryDto)
        {
            var addResult = await _servicesPool.CountryService.AddAsync(addCountryDto);
            return CreatedAtAction(actionName: "Get", routeValues: new { id = addResult.Data }, addResult);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateCountryDto updateCountryDto)
        {
            CommandResule<int> updateCountryResult = await _servicesPool.CountryService.UpdateAsync(updateCountryDto);
            return Ok(updateCountryResult);
        }

        [HttpGet("Get/{id}")]
        public IActionResult Get(int id)
        {
            GetCountryDto getCountryResult = _servicesPool.CountryService.Get(id);
            return Ok(getCountryResult);
        }

        [HttpGet("GetList")]
        public IActionResult GetList([FromQuery] GetCountriesListRequestDto getCountriesListRequestDtos)
        {
            GetListResultDto<GetCountriesListDto> countriesList = _servicesPool.CountryService.GetList(getCountriesListRequestDtos);
            Response.Headers.Add(ReponseHeaderValues.PaginationValues, Newtonsoft.Json.JsonConvert.SerializeObject(countriesList.MetaValues));
            return Ok(countriesList.Values);
        }
    }
}
