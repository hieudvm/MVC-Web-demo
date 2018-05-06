using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Team17Project.Models
{
    public class EditPassword
    {
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [Display(Name = "Mật khẩu hiện tại")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Mật khẩu mới không được để trống")]
        [Display(Name = "Mật khẩu mới")]
        [DataType(DataType.Password)]
        public string  NewPassword { get; set; }

        [Compare("NewPassword", ErrorMessage = "Không trùng khớp với mật khẩu mới")]
        [Display(Name = "Xác nhận mật khẩu")]
        [DataType(DataType.Password)]
        public string  ConfirmPassword { get; set; }
    }
}