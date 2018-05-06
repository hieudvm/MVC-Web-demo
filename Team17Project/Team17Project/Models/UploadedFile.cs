using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Team17Project.Models
{
    public class UploadedFile
    {
        [Required(ErrorMessage = "Bạn chưa chọn file")]
        [RegularExpression(@"^([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.PNG|.JPG|)$", ErrorMessage = "Định dạng file không hợp lệ")]
        public HttpPostedFileBase FileInput { get; set; }

        [Required(ErrorMessage ="Chưa chọn địa điểm")]
        public int LocationId { get; set; }
    }
}