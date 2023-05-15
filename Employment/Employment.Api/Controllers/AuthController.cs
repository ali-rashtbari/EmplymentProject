using Employment.Api.ActionFilters;
using Employment.Api.Models.AuthModels;
using Employment.Common;
using Employment.Common.Constants;
using Employment.Common.Exceptions;
using Employment.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Employment.Api.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("SignIn")]
        [ServiceFilter(typeof(ModelValidationFilterAttribute))]
        public async Task<IActionResult> SignIn([FromBody] SignInViewModel signinViewModel)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(signinViewModel.Email);
                if (user == null) ExceptionHelper.ThrowException(ApplicationMessages.UserNameNotFound, statusCode: HttpStatusCode.BadRequest);

                var isPasswordCurrect = await _userManager.CheckPasswordAsync(user, signinViewModel.Password);
                if (!isPasswordCurrect) ExceptionHelper.ThrowException(ApplicationMessages.PasswordIsInCurrect, statusCode: HttpStatusCode.BadRequest);

                await _signInManager.SignInAsync(user, signinViewModel.IsRemember);

                return CommonTools.ReturnResultAsJson(ApplicationMessages.YouSignInSuccessfuly, HttpStatusCode.OK);
            }
            catch (MainException ex)
            {
                return ExceptionHelper.CatchException(ex);
            }

         
        }

        [HttpPost("SignUp")]
        [ServiceFilter(typeof(ModelValidationFilterAttribute))]
        public async Task<IActionResult> SignUp([FromBody] SignUpViewModel signUpViewModel)
        {
            try
            {
                var userName = String.IsNullOrWhiteSpace(signUpViewModel.UserName) == true ? signUpViewModel.Email : signUpViewModel.UserName;
                var user = new User()
                {
                    Email = signUpViewModel.Email,
                    NormalizedEmail = signUpViewModel.Email.ToUpper(),
                    UserName = signUpViewModel.Email,
                    FirstName = signUpViewModel.FirstName,
                    LastName = signUpViewModel.LastName,
                    Mobile = signUpViewModel.Mobile,
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    NormalizedUserName = userName.ToUpper(),
                    SecurityStamp = Guid.NewGuid().ToString(),
                };

                var passwordHasher = new PasswordHasher<User>();
                user.PasswordHash = passwordHasher.HashPassword(user, signUpViewModel.Password);

                var createResult = await _userManager.CreateAsync(user, signUpViewModel.Password);
                if(!createResult.Succeeded)
                {
                    var errorMessage = createResult.Errors.FirstOrDefault().Description + "-" + createResult.Errors.FirstOrDefault().Code;
                    ExceptionHelper.ThrowException(errorMessage, HttpStatusCode.BadRequest);
                }

                await _userManager.AddToRoleAsync(user, RoleNames.User);

                var signInResult = await _signInManager.PasswordSignInAsync(user, password: signUpViewModel.Password, isPersistent: false, false);
                if(!signInResult.Succeeded)
                {
                    ExceptionHelper.ThrowException(ApplicationMessages.UserNameNotFound, HttpStatusCode.BadRequest);
                }

                return CommonTools.ReturnResultAsJson(ApplicationMessages.YouSignedUpSuccessfuly, HttpStatusCode.OK);
            }
            catch (MainException ex)
            {
                return ExceptionHelper.CatchException(ex);
            }
        }

        [HttpPut("ChangePassword")]
        [ServiceFilter(typeof(ModelValidationFilterAttribute))]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordViewModel changePasswordViewModel)
        {
            try
            {
                await _validateUserInfo(changePasswordViewModel);

                return CommonTools.ReturnResultAsJson(ApplicationMessages.PasswordChanged, HttpStatusCode.OK);
            }
            catch (MainException ex)
            {
                return ExceptionHelper.CatchException(ex);
            }
        }


        /// <summary>
        /// validate user information.
        /// </summary>
        /// <param name="infos"></param>
        /// <returns></returns>
        private async Task _validateUserInfo(ChangePasswordViewModel infos)
        {
            var user = await _userManager.FindByEmailAsync(infos.Email);
            if (user == null) ExceptionHelper.ThrowException(ApplicationMessages.UserNameNotFound, HttpStatusCode.NotFound);

            if(user.Mobile != infos.Mobile.ToLower())
            {
                ExceptionHelper.ThrowException(ApplicationMessages.InvalidMobileNumber, HttpStatusCode.BadRequest);
            }

            var changePasswordResult = await _userManager.ChangePasswordAsync(user, infos.OldPassword, infos.NewPassword);
            if(!changePasswordResult.Succeeded)
            {
                var error = changePasswordResult.Errors.FirstOrDefault().Description + "-400";
                ExceptionHelper.ThrowException(error, HttpStatusCode.BadRequest);
            }
            await _userManager.UpdateAsync(user);
            await Task.CompletedTask;
        }
    }
}
