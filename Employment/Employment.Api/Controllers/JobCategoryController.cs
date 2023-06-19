using Employment.Application.Contracts.ApplicationServicesContracts;
using Employment.Application.Dtos.ApplicationServicesDtos.JobCategoryDtos;
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

        [HttpGet("Get/{id}")]
        public IActionResult Get(int id)
        {
            GetJobCategoryDto jobCategory = _servicesPool.JobCategoryService.Get(id);
            return Ok(jobCategory);
        }

        [HttpGet("GetList")]
        public IActionResult GetList([FromQuery] GetJobCategoriesListRequetsDto request)
        {
            GetListResultDto<GetJobCategoriesListDto> jobCategories = _servicesPool.JobCategoryService.GetList(request);
            Response.Headers.Add(ReponseHeaderValues.PaginationValues, Newtonsoft.Json.JsonConvert.SerializeObject(jobCategories.MetaValues));
            return Ok(jobCategories.Values);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateJobCategoryDto request)
        {
            CommandResule<int> updateResult = await _servicesPool.JobCategoryService.UpdateAsync(request);
            return Ok(updateResult);
        }
    }
}
