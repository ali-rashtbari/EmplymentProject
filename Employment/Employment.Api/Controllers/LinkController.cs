using Employment.Application.Contracts.ApplicationServicesContracts;
using Employment.Application.Dtos.ApplicationServicesDtos.LinkDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employment.Api.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class LinkController : ControllerBase
    {
        private readonly IServicesPool _servicesPool;

        public LinkController(IServicesPool servicesPool)
        {
            _servicesPool = servicesPool;
        }

        [HttpGet("Get/{id}")]
        public IActionResult Get(int id)
        {
            var getLinkDto = _servicesPool.LinkService.Get(id);
            return Ok(getLinkDto);
        }

        [HttpGet("GetList/{resumeId}")]
        public async Task<IActionResult> GetList(int resumeId)
        {
            IEnumerable<GetLinksListDto> links = _servicesPool.LinkService.GetList(resumeId);
            return Ok(links);
        }

    }
}
