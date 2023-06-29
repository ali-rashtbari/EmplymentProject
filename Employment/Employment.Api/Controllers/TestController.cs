using Employment.Application.Contracts.ApplicationServicesContracts;
using Employment.Application.Contracts.PersistanceContracts;
using Employment.Application.Dtos.ApplicationServicesDtos.CityDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employment.Api.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IServicesPool _servicesPool;

        public TestController(IServicesPool servicesPool)
        {
            _servicesPool = servicesPool;
        }


        [HttpGet("AddLanuage")]
        public IActionResult SomeData([FromBody] AddCityDto addCityDto)
        {
            return Ok(6);
        }
    }
}
