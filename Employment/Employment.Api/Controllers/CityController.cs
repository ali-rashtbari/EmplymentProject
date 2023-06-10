using Employment.Application.Contracts.ApplicationServicesContracts;
using Employment.Application.Dtos.ApplicationServicesDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employment.Api.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IServicesPool _servicesPool;
        public CityController(IServicesPool servicesPool)
        {
            _servicesPool = servicesPool;   
        }


        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] AddCityDto addCityDto)
        {
            var addResult = await _servicesPool.CityService.AddAsync(addCityDto);
            return Ok(addResult);
        }
    }
}
