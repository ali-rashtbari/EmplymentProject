using Employment.Application.Contracts.ApplicationServicesContracts;
using Employment.Application.Dtos.ApplicationServicesDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employment.Api.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class JobExperienceController : ControllerBase
    {
        private readonly IServicesPool _servicesPool;
        public JobExperienceController(IServicesPool servicesPool)
        {
            _servicesPool = servicesPool;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] AddJobExperienceDto addJobExperienceDto)
        {
            var addJobExperienceResult = await _servicesPool.JobExperienceService.AddAsync(addJobExperienceDto);
            return Ok(addJobExperienceResult);
        }
    }
}
