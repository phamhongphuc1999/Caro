# Môi trường phát triển: Visual Studio 2019, C# Winform Framework
## mô tả solution: có hai project
- Caro: (Winform project) tạo giao diện và xử lý các chức năng trong trò chơi cờ caro
- DataTransmission(Console project) chứa định dạng gói tin và các hàm đóng gói, mở gói hỗ trợ chế độ mạng LAN
## các chế độ chơi
- chơi trên một máy với 2 người chơi
- chơi trên hai máy thông qua mạng LAN(giao tiếp bằng tcp socket)
- (thêm chế độ người chơi với máy)
## các chức năng của chương trình
- kiểm tra thắng thua
- chức năng phát nhạc
- chức năng thay đổi thông số kích thức, tên người chơi
- chức năng tính giờ
- chức năng lưu trò chơi
- chương trình có thể lưu một số thông số(số hàng, cột, các cài đặt về nhạc, đếm giờ) ngay cả khi đã tắt trò chơi(lưu vào file)
- thiết lập khung chat trong chế độ mạng LAN
- (tính năng trong tương lai): thiết lập tài khoản, tính điểm người chơi
## Tài liệu tham khảo
- https://stackoverflow.com/questions/10775367/cross-thread-operation-not-valid-control-textbox1-accessed-from-a-thread-othe
- https://codegym.vn/blog/2020/05/27/doc-va-ghi-file-json-su-dung-jsonconvert-trong-c/
