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
    public class CountryController : ControllerBase
    {
        private readonly IServicesPool _servicesPool;

        public CountryController(IServicesPool servicesPool)
        {
            _servicesPool = servicesPool;
        }


        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] AddCountryDto addCountryDto)
        {
            var validationResult = await new AddCountryDtoValidator().ValidateAsync(addCountryDto);
            if (!validationResult.IsValid) throw new InvalidModelException(validationResult.Errors.FirstOrDefault().ErrorMessage);
            var addResult = await _servicesPool.CountryService.AddAsync(addCountryDto);
            return Ok(addResult);
        }
    }
}
