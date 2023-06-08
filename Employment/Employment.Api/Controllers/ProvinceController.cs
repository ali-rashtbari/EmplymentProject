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
    public class ProvinceController : ControllerBase
    {
        private readonly IServicesPool _servicesPool;

        public ProvinceController(IServicesPool servicesPool)
        {
            _servicesPool = servicesPool;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] AddProvinceDto addProvinceDto)
        {
            var validationResult = await new AddProvinceDtoValidator().ValidateAsync(addProvinceDto);
            if (!validationResult.IsValid) throw new InvalidModelException(validationResult.Errors.FirstOrDefault().ErrorMessage);
            var addResult = await _servicesPool.ProvinceService.AddAsync(addProvinceDto);
            return Ok(addResult);
        }

        //[HttpPost]
        //public async Task<IActionResult> AddToCountry([FromBody] AddProvinceToCountryDto addProvinceToCountryDto)
        //{
        //    var validationResult = await new AddProvinceToCountryDtoValidator().ValidateAsync(addProvinceToCountryDto);
        //    if (!validationResult.IsValid) throw new InvalidModelException(validationResult.Errors.FirstOrDefault().ErrorMessage);
        //    var addToCountryResult = await _servicesPool.ProvinceService.AddToCountry(addProvinceToCountryDto.CountryId, addProvinceToCountryDto.ProvinceId);
        //    return Ok(addToCountryResult);
        //}
    }
}
