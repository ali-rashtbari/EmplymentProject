using AutoMapper;
using Employment.Api.Models.CityViewModels;
using Employment.Application.Contracts.ApplicationServicesContracts;
using Employment.Application.Dtos.ApplicationServicesDtos.CityDtos;
using Employment.Application.Dtos.CommonDto;
using Employment.Common.Constants;
using Employment.Common.Dtos;
using Employment.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Employment.Api.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IServicesPool _servicesPool;
        private readonly IMapper _mapper;
        private readonly IIntIdHahser _intIdHahser;
        private readonly ICityService _cityService;

        public CityController(IServicesPool servicesPool, IMapper mapper, IIntIdHahser intIdHahser, ICityService cityService)
        {
            _servicesPool = servicesPool;
            _mapper = mapper;
            _intIdHahser = intIdHahser;
            _cityService = cityService;
        }


        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] AddCityDto addCityDto)
        {
            var addResult = await _servicesPool.CityService.AddAsync(addCityDto);
            return CreatedAtAction(actionName: "Get", new { id = addResult.Data }, addResult);
        }

        [HttpGet("Get/{id}")]
        public ActionResult<GetCityToShowModel> Get(string id)
        {
            var city = _cityService.Get(new GetDetailsRequestDto()
            {
                EncodedID = id
            });
            return Ok(city);
        }

        [HttpGet("GetList")]
        public IActionResult GetList([FromQuery] GetCitiesListRequestDto getCitiesListRequest)
        {
            GetListResultDto<GetCitiesListDto> pagedCities = _cityService.GetList(getCitiesListRequest);
            Response.Headers.Add(ReponseHeaderValues.PaginationValues, Newtonsoft.Json.JsonConvert.SerializeObject(pagedCities.MetaValues));
            return Ok(pagedCities.Values);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateCityDto editCityDto)
        {
            editCityDto.DecodedProvinceId = _intIdHahser.DeCode(editCityDto.EncodedProvinceId);
            CommandResule<string> editCityResult = await _cityService.UpdateAsync(editCityDto);
            return Ok(editCityResult);
        }


    }
}
