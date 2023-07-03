using Employment.Api.Models.AuthModels;
using Employment.Api.Services.JWTServices.Dtos;
using Employment.Common;
using Employment.Common.Exceptions;
using Employment.Domain;
using Employment.Persistance.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Employment.Api.Services.JWTServices
{
    public class JwtService : IJwtService
    {

        private readonly UserManager<User> _userManager;
        private readonly IOptions<JwtOptions> _jwtOptions;
        private readonly AppDbContext _dbContext;

        public JwtService(UserManager<User> userManager, IOptions<JwtOptions> jwtOptions, AppDbContext dbContext)
        {
            _userManager = userManager;
            _jwtOptions = jwtOptions;
            _dbContext = dbContext;
        }

        public async Task<RequestTokenResultDto> GetTokenAsync(RequestTokenRequestDto requestTokenRequestDto)
        {
            var user = await _userManager.FindByNameAsync(requestTokenRequestDto.Email);
            if (user == null) throw new NotFoundException(ApplicationMessages.UserNameNotFound, entity: nameof(User), id: requestTokenRequestDto.Email);

            if (!await _userManager.CheckPasswordAsync(user, requestTokenRequestDto.Password))
                throw new Exception(ApplicationMessages.InvalidSignInInformation);

            return new RequestTokenResultDto()
            {
                RefreshToken = null,
                TokenExpiration = DateTime.Now.AddMinutes(_jwtOptions.Value.TokenExpirationMinutes),
                RefreshTokenExpiration = DateTime.Now.AddMinutes(_jwtOptions.Value.RefreshTokenExpirationMinutes),
                UserName = user.UserName, // --- same as email --- //
                UserToken = await _createTokenAsync(user, DateTime.Now) 
            };
        }

        public Task<RequestTokenResultDto> GetTokenAsync(string refereshToken)
        {
            throw new NotImplementedException();
        }


        private async Task<string> _createTokenAsync(User user, DateTime dateTime)
        {

            var userRolesIds = _dbContext.UserRoles
                                        .AsNoTracking()
                                        .Where(ur => ur.UserId == user.Id)
                                        .Select(ur => ur.RoleId)
                                        .AsQueryable();

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("FullName", user.FullName),
                new Claim("RolesId", string.Join(" , ", userRolesIds))
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Value.Key));
            var signInCredentials = new SigningCredentials(securityKey, algorithm: SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtOptions.Value.Issuer,
                audience: _jwtOptions.Value.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwtOptions.Value.TokenExpirationMinutes),
                signingCredentials: signInCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
