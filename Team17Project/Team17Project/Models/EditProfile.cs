using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Team17Project.Models
{
    public class EditProfile
    {
        [Display(Name = "Tên đăng nhập")]
        public string Username { get; set; }

        [Required(ErrorMessage ="Chưa nhập địa chỉ email mới")]
        [Display(Name = "Email mới")]
        [DataType(DataType.EmailAddress)]
        public string NewEmail { get; set; }

        [Required(ErrorMessage = "Xác minh mật khẩu để thay đổi thông tin")]
        [Display(Name = "Mật khẩu xác nhận")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}