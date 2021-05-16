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
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UserType { get; set; }
        public bool Remember { get; set; }

    }
    public class Register
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public string FullName { get; set; }
        public string BirthDate { get; set; }
        public string Age { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        //....
    }

    public class ForgotPassword
    {
        public string Email { get; set; }
        public string Capcha { get; set; }
    }
}