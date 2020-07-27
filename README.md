# Môi trường phát triển: Visual Studio 2019, C# Winform Framework
## mô tả solution: có hai project
- Caro: (Winform framework project) tạo giao diện và xử lý các chức năng trong trò chơi cờ caro
- DataTransmission(class library framework) chứa định dạng gói tin và các hàm đóng gói, mở gói hỗ trợ chế độ mạng LAN
<pre>
tại sao định dạng gói tin phải để ra hẳn một project riêng mà không gộp luôn vào project Caro
- do việc Serializable và Deserializable trong C# sẽ có lỗi nếu token của object không khớp, ví 
dụ class Add trong project A1 khác hoàn toàn class Add trong project A2, không thể serializable 
kể cả khi chúng hoàn toàn giống nhau về nội dung
- việc tách thành project riêng lý do chính là để dễ dàng hơn trong việc kiểm thử, debug, hoàn 
toàn có thể gộp DataTransmission vào project Caro
</pre>
## các chế độ chơi
- chơi trên một máy với 2 người chơi
- chơi trên hai máy thông qua mạng LAN(giao tiếp bằng tcp socket)
## khuân dạng gói tin trong chế độ mạng LAN
<pre>
    [Serializable]
    public struct MessageData
    {
        public int odcode;
        public int X;
        public int Y;
        public string data;

        public MessageData(int odcode, int X, int Y, string data)
        {
            this.odcode = odcode;
            this.X = X;
            this.Y = Y;
            this.data = data;
        }
    };
</pre>
#### odcode: định nghĩa chức năng cần thực hiện
- 101: gửi tọa độ quân cờ cho đối thủ
- 110: xử lý undo game
- 111: xử lý redo game
- 112: xử lý new game
- 120: truyền đoạn chat đến đối thủ
## các chức năng của chương trình
- kiểm tra thắng thua
- chức năng phát nhạc
- chức năng thay đổi thông số kích thức, tên người chơi
- chức năng tính giờ
- chức năng undo game, redo game(vẫn còn lỗi chưa sửa)
- chức năng lưu trò chơi
- chương trình có thể lưu một số thông số(số hàng, cột, các cài đặt về nhạc, đếm giờ) ngay cả khi đã tắt trò chơi(lưu vào file)
- thiết lập khung chat trong chế độ mạng LAN
## một số lưu ý
- thêm project DataTransmission vào Caro(bấm chuột phải vào References, chọn Add References/Project)
- thêm thư viện WMPLib vào Caro(bấm chuột phải vào References, chọn Add References, bấm nút Browse ở dưới, tìm đến đường dẫn c:/Windows/System32/wmp.dll)
- tải thêm thư viện Newtonsoft vào Caro
## gợi ý phát triển trong tương lai
- thêm chế độ một người chơi(người chơi với máy)
- đối tượng hóa các form giao diện(thay vì phải vẽ đi vẽ lại các form thì ta sẽ tạo sẵn các class kế thừa từ Form, khi cần chỉ việc gọi)
- tăng tốc độ vẽ bàn cờ
- thêm tính năng thiết lập tài khoản, tính điểm người chơi
- cho tùy chỉnh màu sắc quân cờ, hiệu ứng khi chiến thắng
## Tài liệu tham khảo
- https://stackoverflow.com/questions/10775367/cross-thread-operation-not-valid-control-textbox1-accessed-from-a-thread-othe
- https://codegym.vn/blog/2020/05/27/doc-va-ghi-file-json-su-dung-jsonconvert-trong-c/
