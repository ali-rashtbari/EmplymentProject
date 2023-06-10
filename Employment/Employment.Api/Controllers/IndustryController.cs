using Employment.Application.Contracts.ApplicationServicesContracts;
using Employment.Application.Dtos.ApplicationServicesDtos;
using Employment.Application.Dtos.Validations;
using Employment.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndustryController : ControllerBase
    {
        private readonly IServicesPool _servicesPool;
        public IndustryController(IServicesPool servicesPool)
        {
            _servicesPool = servicesPool;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddIndustryDto addIndustryDto)
        {
            var addIndustryResult = await _servicesPool.IndustryService.AddAsync(addIndustryDto);
            return Ok(addIndustryResult);
        }

    }
}
