using Castle.Core.Smtp;
using Employment.Api.Models.AuthModels;
using Employment.Api.Services.JWTServices;
using Employment.Api.Services.JWTServices.Dtos;
using Employment.Application.Contracts.PersistanceContracts;
using Employment.Common;
using Employment.Common.Constants;
using Employment.Common.Exceptions;
using Employment.Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Data;
using System.Net;
using IEmailSender = Employment.Application.Contracts.InfrastructureContracts.IEmailSender;

namespace Employment.Api.Controllers
{

    [Route("api/[controller]/")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IJwtService _jwtService;
        private readonly IEmailSender _emailSender;
        private readonly IUnitOfWork _unitOfWork;

        public AuthController(UserManager<User> userManager, 
                              SignInManager<User> signInManager, 
                              IJwtService jwtService, 
                              IEmailSender emailSender,
                              IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;
            _emailSender = emailSender;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] SignInViewModel signinViewModel)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(signinViewModel.Email);
                if (user == null) ExceptionHelper.ThrowException(ApplicationMessages.UserNameNotFound, statusCode: HttpStatusCode.BadRequest);

                if(await _userManager.IsEmailConfirmedAsync(user))
                {
                    var isPasswordCurrect = await _userManager.CheckPasswordAsync(user, signinViewModel.Password);
                    if (!isPasswordCurrect) ExceptionHelper.ThrowException(ApplicationMessages.PasswordIsInCurrect, statusCode: HttpStatusCode.BadRequest);

                    await _signInManager.SignInAsync(user, signinViewModel.IsRemember);

                    var token = await _jwtService.GetTokenAsync(new RequestTokenRequestDto()
                    {
                        Email = signinViewModel.Email,
                        Password = signinViewModel.Password,
                    });

                    return new JsonResult(token);
                }
                else
                {
                    throw new Exception("First you need to confirm your email.");
                }
                
            }
            catch (MainException ex)
            {
                return ExceptionHelper.CatchException(ex);
            }


        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] SignUpViewModel signUpViewModel)
        {
            await _isUserDuplciate(signUpViewModel);
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
                Profile = new Profile()
                {
                    Biography = null
                }
            };

            var passwordHasher = new PasswordHasher<User>();
            user.PasswordHash = passwordHasher.HashPassword(user, signUpViewModel.Password);

            var createResult = await _userManager.CreateAsync(user, signUpViewModel.Password);
            if (!createResult.Succeeded)
            {
                var errorMessage = createResult.Errors.FirstOrDefault().Description + "-" + createResult.Errors.FirstOrDefault().Code;
                throw new Exception(errorMessage);
            }

            await _userManager.AddToRoleAsync(user, RoleNames.User);

            // send confirmation email ---
            await _sendConfirmationEmail(user);

            if (_signInManager.Options.SignIn.RequireConfirmedAccount)
            {
                if(await _userManager.IsEmailConfirmedAsync(user))
                {
                    var token = await _signInAfterSignUp(user, signUpViewModel.Password, signUpViewModel.UserName, user.Email);
                    return new JsonResult(token);
                }
                else
                {
                    throw new Exception("First you need to confirm your email.");
                }
            }
            else
            {
                var token = await _signInAfterSignUp(user, signUpViewModel.Password, signUpViewModel.UserName, user.Email);
                return new JsonResult(token);
            }

        }

        [HttpPost("GetToken")]
        public async Task<IActionResult> GetToken(RequestTokenRequestDto requestTokenDto)
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
            //return CommonTools.ReturnResultAsJson<RequestTokenResultDto>(ApplicationMessages.TokenCreatedSuccessfuly, HttpStatusCode.OK, data: result);
            return Ok(token);
        }

        [HttpPut("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordViewModel changePasswordViewModel)
        {
            await _validateUserInfo(changePasswordViewModel);
            return Ok(ApplicationMessages.PasswordChanged);
        }

        [HttpGet("SignOut")]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

        [HttpGet("ResendConfirmationEmail")]
        public async Task<IActionResult> ResendConfirmationEmail(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user is null) throw new NotFoundException(msg: ApplicationMessages.UserNameNotFound, entity: nameof(user), id: userName.ToString());
            var lastSentConfirmationEmail = await _unitOfWork.ConfirmationEmailRepository.GetUserLastActiveConfirmationEmail(user.Id);
            if (lastSentConfirmationEmail == null)
            {
                await _sendConfirmationEmail(user);
                return Ok("Email sent. :)");
            }
            else
            {
                await _sendConfirmationEmail(user);
                return Ok("confirmation email sent. :)");
            }
        }

        [HttpGet("ConfirmRegisteration")]
        public async Task<IActionResult> ConfirmRegisteration(string userId, string code)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null) throw new NotFoundException(msg: ApplicationMessages.UserNameNotFound, entity: nameof(User), id: userId.ToString());
            var confirmResult = await _userManager.ConfirmEmailAsync(user, code);
            if(confirmResult.Succeeded)
            {
                var lastSentConfirmationEmail = await _unitOfWork.ConfirmationEmailRepository.GetUserLastActiveConfirmationEmail(user.Id);
                if(lastSentConfirmationEmail != null)
                {
                    lastSentConfirmationEmail.IsConfirmed = true;
                    lastSentConfirmationEmail.DateTimeConfirmed = DateTime.UtcNow;
                    _unitOfWork.ConfirmationEmailRepository.Update(lastSentConfirmationEmail);
                }
                return RedirectToAction(actionName: "SignIn", controllerName: "Auth");
            }
            else
            {
                throw new Exception("Email Confirmation proccess faild. :( try again later.");
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
            if (user == null) throw new NotFoundException(ApplicationMessages.UserNameNotFound, entity: nameof(User), id: infos.Email);
            if (user.Mobile != infos.Mobile.ToLower()) throw new Exception(ApplicationMessages.InvalidMobileNumber);
            var changePasswordResult = await _userManager.ChangePasswordAsync(user, infos.OldPassword, infos.NewPassword);
            if (!changePasswordResult.Succeeded)
            {
                var error = changePasswordResult.Errors.FirstOrDefault().Description + "-400";
                ExceptionHelper.ThrowException(error, HttpStatusCode.BadRequest);
            }
            await _userManager.UpdateAsync(user);
            await Task.CompletedTask;
        }

        private async Task<RequestTokenResultDto> _signInAfterSignUp(User user, string password, string userName, string email)
        {
            var signInResult = await _signInManager.PasswordSignInAsync(user, password: password, isPersistent: false, false);
            if (!signInResult.Succeeded)
            {
                throw new NotFoundException(msg: ApplicationMessages.UserNameNotFound, entity: nameof(User), userName);
            }

            var token = await _jwtService.GetTokenAsync(new RequestTokenRequestDto()
            {
                Email = email,
                Password = password
            });
            return token;
        }

        private async Task _sendConfirmationEmail(User user)
        {
            // arrange ---
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var callBackUrl = Url.Action("ConfirmRegisteration", controller: "Auth", values: new { userId = user.Id, code = code }, protocol: Request.Scheme);
            var subject = "Employment Confirmation Email.";
            var message = $"Hello Mrs./Mr. '{user.FullName}'\nBefore sign in to the employment site, plz confirm your Account. :)\nConfirm : {callBackUrl}";
            // act --
            await _emailSender.SendEmailAsync(user.Email, subject, message);
            var confirmationEmail = new ConfirmationEmail()
            {
                Id = Guid.NewGuid(),
                DateTimeConfirmed = null,
                Email = user.Email,
                DateTimeSent = DateTime.UtcNow,
                IsConfirmed = false,
                UserId = user.Id,
            };
            await _unitOfWork.ConfirmationEmailRepository.AddAsync(confirmationEmail);
            await Task.CompletedTask;
        }

        private async Task _isUserDuplciate(SignUpViewModel signUpViewModel)
        {

            if (await _userManager.FindByNameAsync(signUpViewModel.Email) != null)
            {
                throw new DuplicateNameException(ApplicationMessages.UserNameExistInDataBase);
            }
            if(await _userManager.Users.AnyAsync(u => u.Mobile == signUpViewModel.Mobile))
            {
                throw new DuplicateNameException(ApplicationMessages.UserNameExistInDataBase);
            }
        }
    }


}
