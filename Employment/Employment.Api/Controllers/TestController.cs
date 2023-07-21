using Employment.Application.Contracts.ApplicationServicesContracts;
using Employment.Application.Contracts.InfrastructureContracts;
using Employment.Application.Contracts.PersistanceContracts;
using Employment.Application.Dtos.ApplicationServicesDtos.CityDtos;
using Employment.Application.Dtos.CommonDto;
using Employment.Common.Constants;
using Employment.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employment.Api.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IServicesPool _servicesPool;
        private readonly IFileUploader _fileUploader;

        public TestController(IServicesPool servicesPool, IFileUploader fileUploader)
        {
            _servicesPool = servicesPool;
            _fileUploader = fileUploader;
        }


        [HttpGet("AddLanuage")]
        public IActionResult SomeData()
        {
            var cityList = new List<City>()
            {
                new City() { Id = 1, Name = "first" },
                new City() { Id = 2, Name = "second" },
                new City() { Id = 3, Name = "third" },
                new City() { Id = 4, Name = "forth" }
            };

            var lookuped = cityList.ToLookup(c => c.Name);

            return Ok(6);
        }

        [HttpPost("UploadResumeFileAsync")]
        public async Task<IActionResult> UploadFile()
        {
            var user = User;
            var currentUserEmail = await _servicesPool.CommonService.GetCurrentUserAsync();
            return Ok(currentUserEmail);
        }
    }
}
