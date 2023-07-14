using Employment.Application.Contracts.ApplicationServicesContracts;
using Employment.Common.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employment.Api.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IServicesPool _servicesPool;
        public CategoryController(IServicesPool servicesPool)
        {
            _servicesPool = servicesPool;
        }


        [HttpPost("Add")]
        public async Task<IActionResult> Add(string name, int? parentId = null)
        {
            CommandResule<int> addCategoryResult = await _servicesPool.CategoryService.AddAsync(name = name, parentId = parentId);
            return Ok(addCategoryResult);
        }
    }
}
