using AutoMapper;
using Employment.Application.Contracts.ApplicationServicesContracts;
using Employment.Application.Contracts.PersistanceContracts;
using Employment.Application.Dtos.ApplicationServicesDtos;
using Employment.Application.Dtos.Validations;
using Employment.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employment.Api.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class ResumeController : ControllerBase
    {

        private readonly IServicesPool _servicesPool;
        private readonly IMapper _mapper;

        public ResumeController(IMapper mapper, IServicesPool servicesPool)
        {
            _mapper = mapper;
            _servicesPool = servicesPool;
        }

        [HttpPost("AddLink")]
        public async Task<IActionResult> AddLink([FromBody] AddLinkDto addLinkDto)
        {
            var addLinkResult = await _servicesPool.LinkService.AddAsync(addLinkDto);
            return Ok(addLinkResult);
        }

        [HttpPost("AddEducationHistory")]
        public async Task<IActionResult> AddEducationHistory([FromBody] AddEducationHistoryDto addEducationHistoryDto)
        {
            var addResult = await _servicesPool.EducationHistoryService.AddAsync(addEducationHistoryDto);
            return Ok(addResult);
        }

   

    }
}
