using Azure.Core;
using Employment.Application.Contracts.ApplicationServicesContracts;
using Employment.Application.Contracts.InfrastructureContracts;
using Employment.Application.Contracts.PersistanceContracts;
using Employment.Application.Dtos.ApplicationServicesDtos;
using Employment.Application.Dtos.CommonDto;
using Employment.Application.Dtos.Validations;
using Employment.Application.MapperProfiles;
using Employment.Common;
using Employment.Common.Constants;
using Employment.Common.Exceptions;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IFileUploader _fileUploader;

        public UserController(IServicesPool servicesPool, IFileUploader fileUploader)
        {
            _servicesPool = servicesPool;
            _fileUploader = fileUploader;
        }

        [Authorize(Roles = RoleNames.User)]
        [HttpPost("UpdateProfile")]
        public async Task<IActionResult> EditProfile([FromBody] EditProfileDto editProfileDto, string userName)
        {
            var editResult = await _servicesPool.ProfileService.UpdateAsync(editProfileDto, userName);
            return Ok(editResult);
        }

        [Authorize(Roles = RoleNames.User)]
        [HttpPost("UploadResume")]
        public async Task<IActionResult> UploadResume(IFormFile file)
        {
            var currentUser = await _servicesPool.CommonService.GetCurrentUserAsync();
            var uploadDto = new UploadFileDto()
            {
                File = file
            };
            string uploadResumeResult = await _fileUploader.UploadResumeFileAsync(uploadDto, currentUser.Mobile);
            return new JsonResult(uploadResumeResult);
        }
    }
}
