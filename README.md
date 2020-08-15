### Môi trường phát triển: Visual Studio 2019, C# Core
### mô tả solution: có hai project
- CaroGame: (Winform Core Project) tạo giao diện và xử lý các chức năng trong trò chơi cờ caro
- DataTransmission(Class Library Core) chứa định dạng gói tin và các hàm đóng gói, mở gói hỗ trợ chế độ mạng LAN

### các chế độ chơi
- chơi trên một máy với 2 người chơi
- chơi trên hai máy thông qua mạng LAN(giao tiếp bằng tcp socket)

### khuôn dạng gói tin trong chế độ mạng LAN

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


#### odcode: định nghĩa chức năng cần thực hiện
- 101: gửi tọa độ quân cờ cho đối thủ
- 110: xử lý undo game
- 111: xử lý redo game
- 112: xử lý new game
- 120: truyền đoạn chat đến đối thủ

### các chức năng của chương trình
- thiết lập khung chat trong chế độ mạng LAN
- chức năng phát nhạc, tính giờ, lưu trò chơi
- chức năng undo game, redo game(vẫn còn lỗi chưa sửa)
- chức năng tùy chỉnh kích thức, tên người chơi, màu sắc quân cờ(còn lỗi chưa sửa) 
- chương trình có thể lưu một số thông số(số hàng, cột, các cài đặt về nhạc, đếm giờ) ngay cả khi đã tắt trò chơi(lưu vào file theo định dạng json)

### một số lưu ý
- thêm project DataTransmission vào CaroGame(bấm chuột phải vào References, chọn Add References/Project)
- thêm thư viện WMPLib vào CaroGame(bấm chuột phải vào Dependencies, chọn Add Project References, bấm nút Browse ở dưới, tìm đến đường dẫn c:/Windows/System32/wmp.dll và thêm nó vào project CaroGame)
- tải thêm thư viện Newtonsoft vào CaroGame

### gợi ý phát triển trong tương lai
- thêm chế độ một người chơi(người chơi với máy)
- đối tượng hóa các form giao diện(thay vì phải vẽ đi vẽ lại các form thì ta sẽ tạo sẵn các class kế thừa từ Form, khi cần chỉ việc gọi)
- tăng tốc độ vẽ bàn cờ
- thêm tính năng thiết lập tài khoản, tính điểm người chơi
### Tài liệu tham khảo
- https://stackoverflow.com/questions/10775367/cross-thread-operation-not-valid-control-textbox1-accessed-from-a-thread-othe
- https://codegym.vn/blog/2020/05/27/doc-va-ghi-file-json-su-dung-jsonconvert-trong-c/
- https://csharpcanban.com/c-huong-dan-su-dung-color-dialog.html#.XyVUxCgzbSF
