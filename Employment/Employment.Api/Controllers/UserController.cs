using Azure.Core;
using Employment.Application.Contracts.ApplicationServicesContracts;
using Employment.Application.Contracts.PersistanceContracts;
using Employment.Application.Dtos.ApplicationServicesDtos;
using Employment.Application.Dtos.Validations;
using Employment.Application.MapperProfiles;
using Employment.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Employment.Api.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IServicesPool _servicesPool;

        public UserController(IServicesPool servicesPool)
        {
            _servicesPool = servicesPool;
        }

        [HttpPost("EditProfile")]
        public async Task<IActionResult> EditProfile([FromBody] EditProfileDto editProfileDto)
        {
            var validator = new EditProfileDtoValidator();
            var validationResult = await validator.ValidateAsync(editProfileDto);
            if (!validationResult.IsValid) throw new InvalidModelException(validationResult.Errors.FirstOrDefault().ErrorMessage);
            var editResult = await _servicesPool.ProfileService.EditAsync(editProfileDto);
            return Ok(editResult.ToString());
        }

    }
}
