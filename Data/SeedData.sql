CREATE DATABASE QLNH

USE QLNH


SET DATEFORMAT DMY



--Thêm Food Category
INSERT INTO FoodCategory (name, isHidden) 
VALUES 
(N'Hải sản/Seafood', 0),
(N'Gỏi/Salad', 0),
(N'Mì/Noodle', 0),
(N'Cơm/Rice', 0),
(N'Nước giải khát/Drinks',0),
(N'Nước ép', 0)


SELECT * FROM FoodCategory;

--Thêm Food 
INSERT INTO Food (name, idCategory, price, isHidden) 
VALUES 
(N'Hàu sữa nướng muối ớt', 1 , 150000, 0 ),
(N'Sò huyết hấp', 1 , 150000, 0 ),
(N'Mực hấp bia', 1 , 150000, 0 ),
(N'Canh ngao chua', 1 , 150000, 0 ),
(N'Cơm trắng', 4, 20000, 0),
(N'Coca Cola', 5, 15000, 0),
(N'Sữa đậu nành', 5, 12000, 0),
(N'Fanta', 5, 15000, 0),
(N'7Up', 5, 15000, 0),
(N'Nước lọc', 5, 10000, 0),
(N'Chanh dây', 6, 15000, 0)


-- Thêm tài khoản
INSERT INTO Account (UserName, DisplayName, PassWord, Type) 
VALUES 
(N'Admin', N'Trương Văn Bình', '225130235188221091155411012113412958127197241', 524287), --MK: AD
(N'Phuoc', N'Phan Ngọc Phước', '4229125024382100611251781583929172146215', 0), --MK: ST1
(N'Manh', N'Hoàng Đức Mạnh', '4229125024382100611251781583929172146215', 0),
(N'Duy', N'Trường Hoàng Bảo Duy', '4229125024382100611251781583929172146215', 0),
(N'Anh', N'Nguyễn Văn Hoàng Anh', '4229125024382100611251781583929172146215', 0),
(N'Duong', N'Nguyễn Quốc Thái Dương', '4229125024382100611251781583929172146215', 0),
(N'Den', N'Đen Vâu', '4229125024382100611251781583929172146215', 0),
(N'Vu', N'Hoàng Thái Vũ', '4229125024382100611251781583929172146215', 0),
(N'Tung', N'Sơn Tùng MTP', '4229125024382100611251781583929172146215', 0),
(N'Dinh', N'Thái Đinh', '4229125024382100611251781583929172146215', 0),
(N'Quynh', N'Phan Mạnh Quỳnh', '4229125024382100611251781583929172146215', 0),
(N'Linh', N'Bùi Trường Linh', '4229125024382100611251781583929172146215', 0)

delete from Account;
delete from Food;
delete from FoodCategory;



