## Changlog 1.01

[Đã publish phiên bản mới trên](http://team17projectbeta.azurewebsites.net/)

#### Thêm chức năng:
* Đăng ký
* Đăng nhập
* Đăng xuất
* Upload ảnh

#### Một số thay đổi khác:
* Trang chủ đã chỉnh sửa phần link trên navbar đúng với các chức năng
* Partial view cho chức năng login

#### Những thay đổi cần lưu ý cho các thành viên trong nhóm:
* Chuyển các Action như Login, SignUp, Logout sang AuthController
* Thêm thư mục Class
* Class.Crypto dùng để thực hiện việc tạo mã hash dùng cho việc đăng ký và đăng nhập
* Khi đăng ký lưu mật khẩu dưới dạng mã hash SHA256
* Thay đổi thuộc tính Password của User thừ tối đa 25 ký tự thành 100 ký tự để phù hợp với chức năng trên.
* Thêm class RegistrationUser để việc đăng ký dễ chỉnh sửa hơn và thực hiện validation cho dữ liệu người dùng nhập vào.

## Changlog 1.02

[Đã publish phiên bản mới trên](http://team17projectbeta.azurewebsites.net/)

#### Các chức năng đang có:
* Đăng ký
* Đăng nhập
* Đăng xuất
* Upload ảnh
* Chỉnh sửa thông tin
* Thay đổi mật khẩu
* Thay đổi thông tin
* Chi tiết ảnh

#### Thêm chức năng:
* Chỉnh sửa thông tin
* Thay đổi mật khẩu
* Thay đổi thông tin
* Chi tiết ảnh

#### Một số thay đổi khác:
* Không có

#### Những thay đổi cần lưu ý cho các thành viên trong nhóm:
* Thêm class EditPassword, EditProfile dùng cho việc thay đổi password và thông tin tài khoản (sau này có nhiều thông tin thì sẽ thay đổi trong EditProfile hiện tại chỉ có email thay đổi dc ở đây)
* Tên Session chuyển từ "User_Login" -> "Login"
* Các thông tin như username, type, id không được thay đổi
* Chỉnh sủa một chút trong các action về thay đổi thông tin (trước khi thay đổi thông tin thì tạo 1 user mới => sau chỉ cập nhật phần dc thay đổi)

#### Lưu ý về convention C#: theo chuẩn của Microsoft
* Tên Class: PascalCase 
* Tên Property của class: PascalCase
* Tên thuộc tính (private,...): underscorecamelCase
* Tên phương thức (hàm): PascalCase
* Tên tham số của hàm: camelCase
* Tên biến cục bộ dùng trong hàm: camelCase

```cs
class TenClass {
    private string _thuocTinh;
    public string ThuocTinh { get; set;} // Property
    public void PhuongThuc(int thamSo) {
		int tenBienCucBo = 0;
	}
}
```

## Changelog 1.03
[Đã publish phiên bản mới trên](http://team17projectbeta.azurewebsites.net/)

#### Các chức năng đang có:
* Đăng ký
* Đăng nhập
* Đăng xuất
* Upload ảnh
* Chỉnh sửa thông tin
* Thay đổi mật khẩu
* Thay đổi thông tin
* Chi tiết ảnh
* Giao diện trang chủ
* Comment
* Chọn địa điểm cho ảnh tải lên

#### Thêm chức năng:
* Giao diện trang chủ
* Comment
* Chọn địa điểm cho ảnh tải lên

#### Một số thay đổi khác:
* Không có

#### Những thay đổi cần lưu ý cho các thành viên trong nhóm:
* Không có
