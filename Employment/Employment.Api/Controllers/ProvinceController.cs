﻿using Employment.Application.Contracts.ApplicationServicesContracts;
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
            var addResult = await _servicesPool.ProvinceService.AddAsync(addProvinceDto);
            return CreatedAtAction(actionName: "Get", routeValues: new { id = addResult.Data }, addResult);
        }

    }
}
