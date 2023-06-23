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
    public class JobSeniorityLevelController : ControllerBase
    {
        private readonly IServicesPool _servicesPool;
        public JobSeniorityLevelController(IServicesPool servicesPool)
        {
            _servicesPool = servicesPool;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] AddJobSeniorityLevelDto addJobSeniorityLevelDto)
        {
            var addJobSeniorityLevelResult = await _servicesPool.JobSeniorityLevelService.AddAsync(addJobSeniorityLevelDto);
            return CreatedAtAction(actionName: "Get", routeValues: new { id = addJobSeniorityLevelResult.Data }, addJobSeniorityLevelResult);
        }
    }
}
