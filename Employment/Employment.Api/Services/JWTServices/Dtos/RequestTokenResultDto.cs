namespace Employment.Api.Services.JWTServices.Dtos
{
    public class RequestTokenResultDto
    {
        public string UserName { get; set; }
        public string UserToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime TokenExpiration { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
    }
}
