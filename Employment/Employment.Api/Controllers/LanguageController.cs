using Employment.Application.Contracts.ApplicationServicesContracts;
using Employment.Application.Contracts.PersistanceContracts;
using Employment.Application.Dtos.ApplicationServicesDtos.LanguageDtos;
using Employment.Common.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employment.Api.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly IServicesPool _servicesPool;
        public LanguageController(IServicesPool servicesPool)
        {
            _servicesPool = servicesPool;   
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] AddLanguageDto addLanguageDto)
        {
            CommandResule<int> addLanguageResult = await _servicesPool.LanguageService.AddAsync(addLanguageDto);
            return CreatedAtAction(actionName: "Get",
                                   controllerName: ControllerContext.ActionDescriptor.ControllerName,
                                   routeValues: new { id = addLanguageResult.Data },
                                   addLanguageResult);
        }

        [HttpGet("Get/{id}")]
        public IActionResult Get(int id)
        {
            GetLanguageDto languateDto = _servicesPool.LanguageService.Get(id);
            return Ok(languateDto);
        }

    }
}
