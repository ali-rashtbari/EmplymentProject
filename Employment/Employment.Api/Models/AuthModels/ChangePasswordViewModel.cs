using System.ComponentModel.DataAnnotations;

namespace Employment.Api.Models.AuthModels
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "ایمیل کاربری نمی تواند خالی باشد.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "شماره مبایل الزامی است.")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(maximumLength: 11, ErrorMessage = "شماره مبایل نمیتواند بیشتر از 11 کاراکتر داشته باشد.")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "رمز قدیمی را وارد کنید.")]
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "رمز الزامی است.")]
        [StringLength(maximumLength: 15, MinimumLength = 8, ErrorMessage = "تعداد کاراکتر های رمز باید بین 8 تا 15 عدد باشد.")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "تایید رمز نمی تواند خالی باشد.")]
        [Compare(nameof(NewPassword), ErrorMessage = "رمز را به درستی تایید کنید.")]
        public string ConfirmPassword { get; set; }
    }
}
