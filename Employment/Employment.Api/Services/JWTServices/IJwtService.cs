using Employment.Api.Services.JWTServices.Dtos;

namespace Employment.Api.Services.JWTServices
{
    public interface IJwtService
    {
        Task<RequestTokenResultDto> GetTokenAsync(RequestTokenRequestDto requestTokenRequestDto);
        Task<RequestTokenResultDto> GetTokenAsync(string refereshToken);
    }
}
