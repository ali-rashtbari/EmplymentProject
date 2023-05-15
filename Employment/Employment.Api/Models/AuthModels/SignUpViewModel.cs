using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Employment.Api.Models.AuthModels
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage = "ایمیل الزامی است.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "نام کاربری نمی تواند خالی باشد.")]
        [StringLength(maximumLength: 10, MinimumLength = 3, ErrorMessage = "نام کاربری باید بیت 3 تا 10 کاراکتر باشد.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "نام الزامی است.")]
        [StringLength(maximumLength: 10, MinimumLength = 3, ErrorMessage = "تعداد کاراکتر های نام باید بین 3 تا 10 تا باشد.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "نام خانوادگی الزامی است.")]
        [StringLength(maximumLength: 15, ErrorMessage = "تعداد کاراکتر های نام خانوادگی باید کمتر از 15 کاراکتر باشد.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "شماره مبایل الزامی است.")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(maximumLength: 11, ErrorMessage = "شماره مبایل نمیتواند بیشتر از 11 کاراکتر داشته باشد.")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "رمز الزامی است.")]
        [StringLength(maximumLength: 15, MinimumLength = 8, ErrorMessage = "تعداد کاراکتر های رمز باید بین 8 تا 15 عدد باشد.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "تایید رمز الزامی است.")]
        [Compare(nameof(Password), ErrorMessage = "رمز به درستی تایید نشده است.")]
        public string ConfirmPassword { get; set; }
    }
}
