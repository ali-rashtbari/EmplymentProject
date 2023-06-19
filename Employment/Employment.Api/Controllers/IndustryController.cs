using Employment.Application.Contracts.ApplicationServicesContracts;
using Employment.Application.Dtos.ApplicationServicesDtos.IndustryDtos;
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
    public class IndustryController : ControllerBase
    {
        private readonly IServicesPool _servicesPool;
        public IndustryController(IServicesPool servicesPool)
        {
            _servicesPool = servicesPool;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] AddIndustryDto addIndustryDto)
        {
            var addIndustryResult = await _servicesPool.IndustryService.AddAsync(addIndustryDto);
            return Ok(addIndustryResult);
        }

        [HttpGet("Get/{id}")]
        public IActionResult Get(int id)
        {
            GetIndustryDto industry = _servicesPool.IndustryService.Get(id);
            return Ok(industry);
        }

        [HttpGet("GetList")]
        public IActionResult GetList([FromQuery] GetIndustriesListRequestDto request)
        {
            GetListResultDto<GetIndustriesListDto> industries = _servicesPool.IndustryService.GetList(request);
            Response.Headers.Add(ReponseHeaderValues.PaginationValues, Newtonsoft.Json.JsonConvert.SerializeObject(industries.MetaValues));
            return Ok(industries.Values);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateIndustryDto request)
        {
            CommandResule<int> updateResult = await _servicesPool.IndustryService.UpdateAsync(request);
            return Ok(updateResult);
        }
    }
}
