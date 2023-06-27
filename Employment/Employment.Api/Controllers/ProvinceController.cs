using AutoMapper;
using Employment.Api.Models.ProvinceViewModels;
using Employment.Application.Contracts.ApplicationServicesContracts;
using Employment.Application.Dtos.ApplicationServicesDtos.ProvinceDtos;
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
        private readonly IMapper _mapper;

        public ProvinceController(IServicesPool servicesPool, IMapper mapper)
        {
            _servicesPool = servicesPool;
            _mapper = mapper;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] AddProvinceDto addProvinceDto)
        {
            var addResult = await _servicesPool.ProvinceService.AddAsync(addProvinceDto);
            return CreatedAtAction(actionName: "Get", routeValues: new { id = addResult.Data }, addResult);
        }

        [HttpGet("GetList")]
        public IActionResult GetList(int countryId)
        {
            IEnumerable<GetProvincesListDto> provinces = _servicesPool.ProvinceService.GetList(countryId);
            return Ok(_mapper.Map<GetProvincesListToShowInResume>(provinces));
        }

    }
}
