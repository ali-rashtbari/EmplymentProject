using AutoMapper;
using Employment.Api.Models.CityViewModels;
using Employment.Application.Contracts.ApplicationServicesContracts;
using Employment.Application.Dtos.ApplicationServicesDtos.CityDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employment.Api.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IServicesPool _servicesPool;
        private readonly IMapper _mapper;
        private readonly ILogger<CityController> _logger;

        public CityController(IServicesPool servicesPool, IMapper mapper, ILogger<CityController> logger = null)
        {
            _servicesPool = servicesPool;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] AddCityDto addCityDto)
        {
            var addResult = await _servicesPool.CityService.AddAsync(addCityDto);
            return Ok(addResult);
        }

        [HttpGet("Get/{id}")]
        public ActionResult<GetCityToShowModel> Get(int id)
        {
            var city = _servicesPool.CityService.Get(id);
            var toShow = _mapper.Map<GetCityToShowModel>(city);
            return Ok(toShow);
        }


        //[HttpPost("Edit")]
        //public async Task<IActionResult> Edit([FromBody] EditCityDto editCityDto)
        //{

        //}
    }
}
