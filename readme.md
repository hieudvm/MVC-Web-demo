## Team17 Project
#### Nhập môn công nghệ phần mềm

# Quỳ hoa bảo điển - Quyển thượng 

### Muốn luyện thành thần công phải tự cung
[Link trang web trên azure cloud](http://team17projectbeta.azurewebsites.net/)

## Chương 1: Nhập môn tâm pháp
* Project này sử dụng **ASP.NET MVC 5 .NET framework 4.7**.
* Project này sẽ được deploy trên azure cloud 
* Project này dùng mô hình MVC (giải thích sau)

## Chương 2: Những môn võ công cần luyện trước
* [ASP.NET MVC 5 - Quan trọng](https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/introduction/getting-started)
* [HTML - luyện vừa đủ hiểu cơ bản vì vô trong viết code sẽ dùng HtmlHelper của M$](https://www.w3schools.com/html/)
* [Bootraps v3.3.7 - Quan trọng](https://getbootstrap.com/docs/3.3/)
* SQL server trường dạy dư xài
* Entity Framework: tự kiếm sư phụ google xin làm đệ tử
* LINQ khỏi cần cũng được nhưng nên biết cho đời đỡ khổ

## Chương 3: MVC là cái gì? Ăn được không?
**M**odel - **V**iew - **C**ontrol. Model sẽ chứ dữ liệu, View sẽ hiển thị dữ liệu, Control sẽ sử lý các dữ liệu. Điều này quan trọng phải đảm bảo trong quá trình viết code sao cho đúng như vậy, giúp cho mọi thứ trở nên thật ez.

### Model
Model là **dữ liệu** của chương trình. Tưởng tượng đơn giản thì nó giống như 1 bộ trong database. Viết select abc các kiểu thì cái nhận lại là 1 model.

Tự nhiên đẻ ra cái này làm gì? Cái này dùng để truyền dữ liệu đi đến các controller cũng như view chứ không chẳng lẽ tới mỗi chỗ lại query 1 lần.

Một model có 4 thao tác cơ bản (thật ra là code cái nào liên quan tới dữ liệu đều là 4 cái này): Create, Read, Update, Delete (CRUB)
Tùy mỗi controller sẽ cài sao cho hợp lý nhưng cơ bản chỉ có nhiêu đó.

*Trong code đã có các model dự kiến mà dùng entity framework để tự tạo hết code cho 4 chức năng này. Dựa theo mẫu đó mà code lại cho chuẩn theo ý mình*


### View
View là cái sẽ hiển thị -> nó là 1 file html. 

Trong ASP.NET sẽ có định dạng là .cshtml gọi là razor. Có thể nhận dữ liệu và biểu diễn dữ liệu đó theo template định săn trong file .cshtml cực đơn giản. Mọi thức cần làm chỉ cần biết chút html và c# thì sẽ tạo được 1 trang html động tự thay đổi với dữ liệu. Nhưng mới nhìn sẽ thấy nó rất phức tạp vì cái đống HtmlHelpers.

### Controller
Controller là cái sẽ thực hiện việc xử lý. Nói đơn giản thì trong đó có các hàm sẽ sử lý với mỗi cái url trên thanh địa chỉ web. Lúc nào dùng Update, Create, Delete, Read là cái này sẽ thực hiện. Cụ thế đọc tiếp sẽ hiểu.

## Chương 4: Viết thêm 1 chức năng cần làm gì?
**Lưu ý đây là ý kiến cá nhân**

Đầu tiên hãy nghĩ tới đối tượng dữ liệu mà chức năng này hương tới. Nói theo thuật ngữ là Model đó. Ví dụ: Chức năng đăng nhập thì cái model nó tác động tới phải là User.

Tiếp theo nghĩ tới cách nó tác động tới dữ liệu như thế nào. Như đã nói ở trên dữ liệu có 4 thao tác chính (CRUD) nên thường nó không đi đâu xa ngoài cái đống này đâu yên tâm. Ví dụ chức năng đăng nhập thì nó sẽ tìm trong database xem cái thằng nào trùng username thì lôi lên rồi kiểm tra mật khẩu coi cái nhập vô có trùng với cái ở trong bộ vừa lấy lên không. Cái này không hẳng được gọi là Read nhưng gọi cũng đúng vì Read là truy vấn lên giờ mình cũng truy vấn vên nhưng chỉ không hiển thị ra mà làm một số thứ khác.

Cuối cùng là thêm phần giao diện cho các chứ năng đó.

Thêm một chức năng thì sẽ đi qua đầy đủ cả 3 bức M-V-C.

*Chú ý đừng lầm cái đăng nhập là 1 chức năng của user, nó là 1 chức năng của hệ thống. Model chỉ là dữ liệu không xử lý ở đây. Phần xử lý là của Controller, làm sai sẽ tẩu hỏa nhập ma e rằng khó cứu*

## Chương 5: Luận bàn về thư mục Models
**Lưu ý trong quá trình code không được thay đổi bất cứ gì trong thư mục này**

Có 2 thứ cần quan tâm ở đây

Thứ 1 là 4 file User.cs, Image.cs, Comment.cs, Location.cs đây là khai báo cho 4 model sẽ sử dụng trong chương trình.

Thứ 2 là file Team17ProjectDataModel.Context.cs. Hiểu đơn giản thì đây là cái dùng để truy vấn database đó. Trong code mà chương trình generate ra sẽ có dùng nó để thực hiện việc query dữ liệu từ database. (code dùng LINQ nếu ai muốn viết câu truy vấn bình thường thì tự google). Cách sử dụng tham khảo hàm update trong bất các controller để cho dễ hiểu.

Nếu trong quá trình code cần thấy thay đổi thì post lên discord lý do, cách thay đổi để xem xét thay đổi lại database.

## Chương 6: GET và POST method
Đây là 2 cách mà 1 cái trình duyệt web sẽ gửi và nhận dữ liệu từ hệ thống mà mình code. Nói đơn giản là khi mình thực hiện 1 số hành động nào đó trên trình duyệt thì sẽ có 1 cái gì đó xảy ra ở phía server. Đây là cầu nối giữa backend và frontend.
# GET:
GET dùng để gửi dữ liệu cho server nhưng nó sẽ có tính chất là dùng để lấy lại 1 cái dữ liệu gì đó từ server để hiển thị chứ không dùng để cập nhật dữ liệu. Nói chứ dùng để cập nhật dữ liệu cho server cũng được nhưng sẽ bị hack banh ta lông. 

GET sẻ được thực hiện qua thanh địa chỉ trong trình duyệt. Khi dùng GET thì trên thanh đó sẻ được thêm 1 queryString phân cách bằng đâu ?

ví dụ: khi gõ lên trình duyệt abc.xyz/index?name=def thì đồng nghĩa GET method vừa đực dùng để gửi 1 biến tên  là name mang giá trị "def" vào Hàm index.

Nếu nhìn kỹ thì trong UsersController  nó sẽ có mấy chỗ Comment khi là //GET: Users blah, blah là nó đó.
# POST
POST thì nó cũng gửi nhưng mà gửi dữ liệu về server để xử lý chứ mục đích chính không phải là để lấy lại 1 cái gì hết. Lý do là vì POST nó có hiển thị thêm cái gì ở thanh địa chỉ hết chỉ có 1 cái form rồi nhập vô qua một đống bức validation mới tới được server chứ không như GET ai cho gì lấy đó.

Trong ASP.NET thì để viết 1 POST method thì cần có 1 số cái attribute kèm theo 1 action để nó biết đó là POST.

Ví dụ: trong UsersController thì nhìn vô cái hàm Create. Nó có cả GET và POST, GET thì dùng để lấy cái view (sẽ hiển thị giao diện là 1 cái form lên trình duyệt), còn POST thì nó mới thực sự thực hiện việc tạo 1 User mới. Nên chú ý vân để này.

## Chương 7: Làm sao để gọi 1 hàm trong 1 controller
**Lưu ý vấn đề đặt tên trong ASP.NET, convention phải được tuân thủ tuyệt đối. Không sáng tạo, không cẩu thả ở đây được vì đặt lảm nhảm nó không có chạy. Cụ thể đọc tiếp**

Cái này chủ yếu liên quan tới View và Controller vì 2 thằng này hay chơi ~~Gay~~ với nhau nên có nhiều chuyện để nói.

Đầu tiên nhìn vô Create trong UsersController. Cái hàm này trả về View() lúc này tự hỏi là View là là cái nào trong chương trình có 1 đống file .cshtml sao nó biết cái nào mà nó xài. Câu trả lời là do các đặt tên hàm này là Create, nhìn xuống thư mục Views sẽ có 1 Thư mục tên là Users (Users~~Controller~~) trong thư mục này có Create.cshtml. Thấy điều kỳ diệu chưa? nếu thư mục này đặt tên là User thì nó không chạy, đem đi chổ khác nó không chạy. Cái Create đổi thành Cr3at3 nó không chạy. 

Có một vấn để gọi là routing (học mạng nghe quen nhưng nó khác). ASP.NET đã thực hiện sẵn việc này cho mình, mình chỉ cần làm đúng theo convention là routing chuẩn không phải suy nghỉ. Nói chung phải tuân thủ convention 1 cách không não.

Bắt đầu vấn đề chính. Khi 1 chương trình ASP.NET được tạo ra thì lúc nào cũng có cái HomeController. Thì mặc định khi truy cập vô trang web nó sẽ gọi cái controller này đầu tiên. Ví dụ: abc.com thì thật ra đầy đủ thêm 1 chút có thể viết là abc.com/Home. Vậy sau khi vô Home thì nó phải gọi 1 action nào đó và mặc định nó là Index. Đầy đủ hơn thì viết là abc.com/Home/Index nhưng mà không cần abc.com là đủ rồi vì mặc định nó sẽ gọi mấy thằng kia gõ chi mỏi tay.

Xét cái abc.com/Home/Index thì thấy là Home chính là trên của controller (Home~~Controller~~ thật ra nó là tên cái thư mục trong Views đó nhưng nói vậy cho dễ hiểu đằng nào cũng giống nhau) Index là tên của cái hàm trong HomeController. Viết tổng quát lại thì như sau:
linkweb/{ControllerName}/{ActionName} - Đây là đương đã tổng quát, ngoài ra có thể truyền thêm parameter vô bằng cái đường dẫn đó mà không cần dùng GET nữa nhưng nếu muốn biết thì tự tìm hiểu.

Ví dụ muốn gọi Create (GET) của UsersController thì đường dẫn sẽ như sau: abc.com/Users/Create


## Chương 8: Chiêu thức thứ nhất "Đăng ký - Đăng nhập"
Chiêu này khỏi cần tâm pháp, khẩu quyết gì nhìn vô là viết nó là 1 cái Create nguyên thủy không có gì đặc biệt nhưng có vài điều khá hay ho nên biết sau:

**Đây là kinh nghiệm cá nhân và độ "nguy hiểm của người code" tăng dân**

* Khi 1 người đăng ký thì không nên lưu mật khẩu lại, nên lưu 1 thứ khác. Cụ thể ở đây sẽ lưu lại 1 chuỗi hash của mật khẫu. Đây là 1 thuật toán 1 chiều, từ 1 chỉ có thể tạo thành 1 chuỗi hash thôi và không thể tạo ngược lại. Điều này đề phòng có nhiều người thường đặt 1 mật khẩu cho nhiều thứ nếu lỡ 1 cái nào bị hack lộ ra mà không có hash thì sẽ mấy cái khác cũng chuẩn bị tinh thần, còn lưu chuổi hash thì không sao vẫn không biết pass của mình là gì.

* Khi tạo 1 tài khoản thì người ta chỉ tạo 1 mật khẩu và mình cũng chỉ cho tạo 1 cái. Nhưng không ai cấm mình lưu nhiều cái. Cụ thể như sau nếu người dùng tạo 1 mật khẩu là "abcdef" thì mình nên lưu vào database 3 mật khẩu như sau: "Abcdef", "aBCDEF", "abcdef". Lý do: để nó đỡ ngồi chửi mỗi khi quên tắt caplock và mấy thằng dùng điện thoại.

Còn Đăng nhập cũng không khó. Nhưng có 1 số điều cần biết khi làm chức năng này như sau:

* Làm sao biết 1 người đã đăng nhập. Gõ xong username, password, xác nhận đúng rồi sao? Làm sao biết là thằng đó đang đăng nhập cái này không dễ nhưng cũng không khó hỏi google kêu dạy 5 phút đủ xuống núi khuynh đảo võ lâm.

* Giờ đăng nhập xong lỡ tắt rồi mở lại vậy cũng kêu nó đăng nhập tiếp hả?? Giờ làm sao giữ trạng thái đăng nhập, ở lại núi thêm 5 phút học xong cái này từ google rồi hãy xuống, học xong không thèm xài chiêu ở trên luôn.

## Chương 9: Chiêu thứ 2 "Upload ảnh"
Chiêu này nói thằng dễ hơn thằng trên. Có điều phải ngồi đọc 1 chút.

Có 1 cái gọi là API nó sẽ cung cấp cho mình 1 số dịch vụ mình ngồi gọi ra xài thôi là xong không cần làm gì nhiều.

Ở đây cần tìm 1 cái API up ảnh nào đó. Google Picasa chẳng hạn, ngồi đọc cách dùng rồi viết 1 cái form cho người dùng chọn ảnh rồi ghi vài thông tin xong submit thì gọi cái API này hết phim.

## Chương 10: Chiêu thứ 3 "Home/Index"
Ảnh sẽ hiển thị chủ yếu ở chỗ này nên cần viết lại cái View ở chỗ này sao cho đẹp chút rồi mỗi lần vô lại dùng dataContext lấy lên 1 đống Model Image quăng ra là xong. Thêm 1 cái form dạng GET để người dùng nhập vô 1 vài thông tin để lọc ảnh nói chung nặng phần frontend.

## Chương 11: Chiêu thứ 4 "Comment"
Thật ra chương trình này rất đơn giản không có cái gì nằm ngoài CRUD hết. Cái này là read nhưng trong View tạo 1 cái form để người dùng comment vô gửi cái là thực hiện tạo 1 cái Comment. Nó sẽ liên quan 2 cái Controller.

## Nhiêu đó đủ xài luyện hết sẽ có Quỳ Hoa Bảo Điển - Quyển Hạ
*Khỏi cần tự cung cũng luyện được*


# Quỳ hoa bảo điển - Quyển hạ
### Muốn luyện thành thần công ở quyển hạ phải tự cung

## Chương 0: Tổng quan về phần tiếp theo này
* Phần này sẽ giới thiệu về cách deploy project lên azure cloud để mọi người biết đỡ bị tình trạng "Đây là đâu???, tôi là ai???".
* Nói qua về cách sử dụng github và một số quy định
* Nói về các file lấy về được từ github

## Chương 1: Azure cloud và việc đưa project lên mạng
**Phần này chỉ cần đọc để biết không phải làm theo nên về cách tạo tài khoản azure thì xem trên dreamspark nhé**

Azure cloud là một dịch vụ của microsoft giúp mình làm nhiều thứ. Cụ thể ở đây thì chúng ta dùng để host cái trang web này.

Khi host 1 trang web trên azure thì sẽ phải tạo những thứ sau: SQL server, SQL database, App service (ở đây là web appication), App Service Plan. SQL server là cái server sẽ chứa SQL database (giống như trong máy mình thôi có điều nó nằm trên cloud).

Việc Deploy trang web mình sẽ là người thực hiện nên công việc của cần làm ở đây là code là push lên git sau khi chức năng nào đã cập nhật mình sẽ deploy lại lên cloud.

Khi deploy trang web đã được tạo kết nối tới azure SQL server chứ không còn là local SQL server nữa nên có thể việc cập nhật dữ liệu sẽ phải chờ dù đang code thì chạy localhost.

*Lý do phải dùng cloud server là vì mỗi người đều phải code phần của mình mà do máy mỗi người cài phiên bản SQL server khác nhau với nhiều thứ khác nữa nên quyết định là tất cả đều kết nối tới azure SQL server nên khi code có xóa dữ liệu hay thêm bớt gì thì những người khác sẽ thấy được ngay lập tức nên chú ý không phá lung tung dữ liệu người khác thêm vào. Thêm nữa là dung lượng trên cloud khá nhỏ nên dùng tiết kiệm* 

*Lưu ý ở link trang web ở đầu và cái trang web các bạn code rồi Ctrl + f5 nó hiện ra không liên quan gì nhau dù nếu dùng bất cứ trang nào để cập nhật dữ liệu cũng được*

## Chương 2: Github thần công
Những điều cơ bản cần phải biết:
* Repo: là cái thư mục chứa code, có 2 loại, 1 là local repo, 2 là remote repo. Local repo là cái nằm trên máy, remote repo là cái nằm trên git.
* Branch: là 1 nhánh của repo, để đơn giản thì tưởng tượng 1 cái cây có 1 cái gốc thì cái gốc đó là master (cũng là 1 branch). Khi code thì mỗi người sẽ tạo 1 branch riêng để khi code sẽ không ảnh hưởng tới người khác khi nào chức năng đó chạy ổn không lỗi lầm gì nữa thì sẽ có hướng dẫn để merge branch lại.
* Lệnh tạo branch thì cứ google, khuyến cáo google bằng tiếng anh.
* Remote link: đây là link liên kết tới remote repo (cụ thể hướng dẫn sau)

Về sử dụng github có các lệnh đơn giản sau cần phải biết:
* git status: dùng để hiển thị trạng thái nên gõ mỗi lần mở git bash lên.
* git pull: cập nhật những thay đổi trong remote repo về local repo, phải gõ mỗi lần mở git bash lên nếu nhiều người cùng làm chung 1 branch
* git add: dùng để track 1 file nào đó.
* git commit: dùng để thêm một thông điệp cho commit đó (yêu cầu ghi ngắn gọn dễ hiều vd: update AbcController, fix SignUp bug. Không quá cứng nhắt chuyện không commit nội dung linh tinh nếu nhưng luôn phải đảm bảo được là commit phải ngắn và nói được là làm gì, xong hay chưa)
* git push: đẩy nhưng thay đổi lên remote repo

Về cách clone repo về máy
* Bước 1: mở git bash lên
* Bước 2: Cd tới thư mục sẽ chưa local repo ví dụ ở trên desktop tạo 1 thư mục tên nmcnpm thì sau khi mở git bash lên gõ như sau: cd nmcnpm |enter| git clone link |enter| (cái link thì vô trong github lấy, click vô mục clone or download lấy cái link về
* Bước 3: sau khi clone xong thì sẽ có thư mục Team17App

Sau khi code thực hiện commit như sau:
* Bước 1: mở git bash lên ở thư mục local repo (Team17App)
* Bước 2: git add .  (gõ nguyên văn bao gồm cả dấu . và dấu cách)
* Bước 3: git commit -m "Nội dung commit, yêu cầu ở trên"
* Bước 4: git push origin branchname (chỉ thực hiện khi project không có lỗi, nếu có dừng lại ở bước trên và lần sau bắt đầu lại từ bước 1, branchname là branch của người đó)

## Chương 3: Team17Project và Team17ProjectDatabase
Team17ProjectDatabase bỏ qua không dùng tới, nếu có chỉnh sửa gì về cấu trúc data thì đã nói ở trên và mình sẽ chỉnh sửa và public lại trên azure cloud

Team17Project là nơi sẽ code. Lưu ý ai code ở file nào thì chỉ code ở file đó không tự ý thêm thắt ở file khác nếu cần thì liên hệ với người code file đó.

**Cách build project, có thể chưa chính xác cần 1 ngày lên discord nói rõ để build cho chuẩn nếu có lỗi**
* Cài đặt visual studio 2017 bản community là được không nên dùng các bản khác vì không cần. Ai có bản khác thì để củng được không sao nhưng phải là 2017.
* Ctrl + shilf + B
* Nếu có lỗi thì hẹn 1 ngày lên discord giải quyết

*Khỏi cần tự cung cũng làm được project này*
