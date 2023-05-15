using Microsoft.AspNetCore.Authorization;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Employment.Api.Models.AuthModels
{
    public class SignInViewModel
    {
        [Required(ErrorMessage = "نام کاربری نمیتواند خالی باشد.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "رمز نمیتواند خالی باشد.")]
        public string Password { get; set; }
        [DefaultValue(false)]
        public bool IsRemember { get; set; }
    }
}
