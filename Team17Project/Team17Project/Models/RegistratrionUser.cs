using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Team17Project.Models
{
    public class RegistrationUser
    {
        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        [Display(Name = "Tên đăng nhập")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9._\-]{5,}$", ErrorMessage = "Tên đăng nhập chỉ được dùng ký tự, chữ số, ., -, _ và lón hơn 5 ký tự")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Xác nhận mật khẩu không trùng khớp với mật khẩu")]
        [Display(Name = "Xác nhận mật khẩu")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email không được để trống")]
        [Display(Name = "Địa chỉ Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}