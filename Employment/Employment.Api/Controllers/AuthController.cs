using Employment.Api.ActionFilters;
using Employment.Api.Models.AuthModels;
using Employment.Api.Services.JWTServices;
using Employment.Api.Services.JWTServices.Dtos;
using Employment.Common;
using Employment.Common.Constants;
using Employment.Common.Exceptions;
using Employment.Domain;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IJwtService _jwtService;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, IJwtService jwtService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;
        }

        [HttpPost("SignIn")]
        [ServiceFilter(typeof(ModelValidationFilterAttribute))]
        public async Task<IActionResult> SignIn([FromBody] SignInViewModel signinViewModel)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(signinViewModel.Email);
                if (user == null) ExceptionHelper.ThrowException(ApplicationMessages.UserNameNotFound, statusCode: HttpStatusCode.BadRequest);

                var isPasswordCurrect = await _userManager.CheckPasswordAsync(user, signinViewModel.Password);
                if (!isPasswordCurrect) ExceptionHelper.ThrowException(ApplicationMessages.PasswordIsInCurrect, statusCode: HttpStatusCode.BadRequest);

                await _signInManager.SignInAsync(user, signinViewModel.IsRemember);

                var token = await _jwtService.GetTokenAsync(new RequestTokenRequestDto()
                {
                    Email = signinViewModel.Email,
                    Password = signinViewModel.Password,
                });

                return CommonTools.ReturnResultAsJson(ApplicationMessages.YouSignInSuccessfuly, HttpStatusCode.OK, data: token);
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
                if(await _userManager.FindByNameAsync(signUpViewModel.Email) != null)
                {
                    ExceptionHelper.ThrowException(ApplicationMessages.UserNameExistInDataBase, HttpStatusCode.BadRequest);
                }

                var user = new User()
                {
                    Email = signUpViewModel.Email,
                    NormalizedEmail = signUpViewModel.Email.ToUpper(),
                    UserName = signUpViewModel.Email,
                    FirstName = signUpViewModel.FirstName,
                    LastName = signUpViewModel.LastName,
                    Mobile = signUpViewModel.Mobile,
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    NormalizedUserName = signUpViewModel.Email.ToUpper(),
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

                var token = await _jwtService.GetTokenAsync(new RequestTokenRequestDto()
                {
                    Email = signUpViewModel.Email,
                    Password = signUpViewModel.Password
                });

                return CommonTools.ReturnResultAsJson(ApplicationMessages.YouSignedUpSuccessfuly, HttpStatusCode.OK, data: token);
            }
            catch (MainException ex)
            {
                return ExceptionHelper.CatchException(ex);
            }
        }

        [HttpPost("GetToken")]
        [ServiceFilter(typeof(ModelValidationFilterAttribute))]
        public async Task<IActionResult> GetToken(RequestTokenRequestDto requestTokenDto)
        {
            try
            {
                var token = await _jwtService.GetTokenAsync(requestTokenDto);

                var result = new RequestTokenResultDto()
                {
                    UserName = requestTokenDto.Email,
                    UserToken = token.UserToken,
                    RefreshToken = token.RefreshToken,
                    RefreshTokenExpiration = token.RefreshTokenExpiration,
                    TokenExpiration = token.TokenExpiration
                };

                return CommonTools.ReturnResultAsJson<RequestTokenResultDto>(ApplicationMessages.TokenCreatedSuccessfuly, HttpStatusCode.OK, data: result);

            }
            catch (MainException ex)
            {
                return ExceptionHelper.CatchException(ex);
            }
        }

        [Authorize]
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

        [Authorize]
        [HttpGet("SignOut")]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return Ok();
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
