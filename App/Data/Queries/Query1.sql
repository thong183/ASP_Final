INSERT INTO dbo.Admins(Username,Password,Email)
VALUES ('pthyst','phuongdung','pthyst@gmail.com'),('sangnt43','sangnt43','sangnt43@gmail.com');

INSERT INTO dbo.BookCategory(Name,Description)
VALUES (N'Truyện thiếu nhi',N'Truyện dành cho thiếu nhi từ 6 đến 12 tuổi'),
(N'Truyện tranh',N'Truyện tranh dành mọi lứa tuổi'),
(N'Tiểu thuyết',N'Tác phẩm văn học dành cho lứa tuổi từ 16 trở lên'),
(N'Truyện kinh dị',N'Sản phẩm giải trí dành cho lứa tuổi từ 12 trở lên'),
(N'Văn học Việt Nam',N'Tác phẩm văn học Việt Nam'),
(N'Văn học nước ngoài',N'Tác phẩm văn học nước ngoài tổng hợp');

INSERT INTO dbo.Books(Title,Author,DatePublish,Publisher,Size,Pages,Cover,CategoryId,NSeen,NLove,Price,Saleoff)
VALUES (N'Dế mèn phiêu lưu ký',N'Tô Hoài','20191224 00:00:00 AM',N'NXB Kim Đồng','35x15',150,'#',1,0,0,100000,0),
(N'Dế Choắt và Jombie',N'Lục Lăng','20191224 00:00:00 AM',N'NXB G5R','35x15',150,'#',1,0,0,100000,0),
(N'Tầng thượng 102',N'Cá Hồi Hoang','20191224 00:00:00 AM',N'NXB Kén Người Nghe','35x15',150,'#',3,0,0,100000,0),
(N'5AM',N'Cá Hồi Hoang','20191224 00:00:00 AM',N'NXB Kén Người Nghe','35x15',150,'#',3,0,0,100000,0),
(N'Khói thuốc đợi chờ',N'Jimmy Nguyễn','20191224 00:00:00 AM',N'NXB Âm nhạc cổ điển','35x15',150,'#',3,0,0,100000,0),
(N'Tiết diên 2013',N'Trần Dần','20191224 00:00:00 AM',N'NXB Người Điên Khu Bolsa','35x15',150,'#',3,0,0,100000,0);

