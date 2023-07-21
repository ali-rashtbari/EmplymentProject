using Employment.Application.Contracts.ApplicationServicesContracts;
using Employment.Common;
using Employment.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Services.ApplicationServices
{
    public class CommonService : ICommonService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UserManager<User> _userManager;

        public CommonService(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            _contextAccessor = httpContextAccessor;
            _userManager = userManager;
        }
        public async Task<User> GetCurrentUserAsync()
        {
            var userIdCliam = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdCliam is null) throw new Exception(ApplicationMessages.YouAreNotAuthenticated);
            var user = await _userManager.FindByIdAsync(userIdCliam.Value);
            return user;
        }
    }
}
