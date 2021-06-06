using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IVG.Web.Mvc.Models
{
    public class Login
    {
        //[MaxLength(50,ErrorMessage ="Tên đăng nhập không quá 50 ký tự")]
        //[MinLength(6,ErrorMessage ="Tên đăng nhập phải từ 6 ký tự trở lên")]
        [Required (ErrorMessage ="Login ID is required.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "User type is required.")]
        public AppEnum.Role UserType { get; set; }
        public string Remember { get; set; }
        public string ReturnUrl { get; set; }

    }
    public class Register
    {
        [Required]
        public string UserName { get; set; }
        //public string Password { get; set; }
        //public string RePassword { get; set; }
        [Required]
        public string FullName { get; set; }
        public string BirthDate { get; set; }
        public string Age { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        public string Address { get; set; }
        //....
    }

    public class ForgotPassword
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Captcha { get; set; }
    }

    public class ChangePassword
    {
        //[Required(ErrorMessage ="Mật khẩu cũ là bắt buộc nhập.")]
        //[MinLength(6,ErrorMessage ="Mật khẩu cũ phải chứa ít nhất 6 ký tự")]
        //[MaxLength(12, ErrorMessage = "Mật khẩu cũ không được quá 12 ký tự")]
        public string CurrentPassword { get; set; }

        //[Required(ErrorMessage = "Mật khẩu mới là bắt buộc nhập.")]
        //[MinLength(6, ErrorMessage = "Mật khẩu mới phải chứa ít nhất 6 ký tự")]
        //[MaxLength(12, ErrorMessage = "Mật khẩu mới không được quá 12 ký tự")]
        public string NewPassword { get; set; }

        //[Required(ErrorMessage = "Bạn phải xác nhận mật khẩu mới")]
        public string ConfirmNewPassword { get; set; }
    }

    public class MyProfile
    {
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string MobilePhone{ get; set; }
        public string ExtNo { get; set; }
    }
}