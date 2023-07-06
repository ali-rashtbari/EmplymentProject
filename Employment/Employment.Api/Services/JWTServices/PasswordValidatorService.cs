using Employment.Domain;
using Microsoft.AspNetCore.Identity;

namespace Employment.Api.Services.JWTServices
{
    public class PasswordValidatorService : IPasswordValidator<User>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user, string? password)
        {
            var errors = new List<IdentityError>();
            if(password.Contains(user.Email))
            {
                errors.Add(new IdentityError()
                {
                    Code = "Weak Password",
                    Description = "Password should not contain you Email address."
                });
            }
            if(password.Contains(user.FirstName) || password.Contains(user.LastName))
            {
                errors.Add(new IdentityError()
                {
                    Code = "Weak Password",
                    Description = "Password should not contain you name."
                });
            }
            if(password.Contains(user.Mobile))
            {
                errors.Add(new IdentityError()
                {
                    Code = "Weak Password",
                    Description = "Password should not contain you Mobile number."
                });
            }
            if(errors.Count > 0)
            {
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
            }
            return Task.FromResult(IdentityResult.Success);
        }
    }
}
