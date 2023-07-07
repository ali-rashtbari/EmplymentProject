using Employment.Application.Contracts.ApplicationServicesContracts;
using Employment.Application.Dtos.ApplicationServicesDtos.LinkDtos;
using Employment.Common.Constants;
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
            if(User.IsInRole(RoleNames.Admin))
            {
                var roleName = User.Identity.Name;
            }
            IEnumerable<GetLinksListDto> links = _servicesPool.LinkService.GetList(resumeId);
            return Ok(links);
        }

    }
}
