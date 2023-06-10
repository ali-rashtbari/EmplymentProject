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
    public class JobCategoryController : ControllerBase
    {
        private readonly IServicesPool _servicesPool;
        public JobCategoryController(IServicesPool servicesPool)
        {
            _servicesPool = servicesPool;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] AddJobCategoryDto addJobCategoryDto)
        {
            var addJobCategoryResult = await _servicesPool.JobCategoryService.AddAsync(addJobCategoryDto);
            return Ok(addJobCategoryResult);
        }
    }
}
