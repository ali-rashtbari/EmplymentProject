using Employment.Application.Contracts.ApplicationServicesContracts;
using Employment.Application.Dtos.ApplicationServicesDtos;
using Employment.Application.Dtos.Validations;
using Employment.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employment.Api.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class MajorController : ControllerBase
    {
        private readonly IServicesPool _servicesPool;

        public MajorController(IServicesPool servicesPool)
        {
            _servicesPool = servicesPool;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] AddMajorDto addMajorDto)
        {
            var addResult = await _servicesPool.MajorService.AddAsync(addMajorDto);
            return Ok(addResult);
        }
    }
}
