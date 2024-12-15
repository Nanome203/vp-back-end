
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

SELECT * FROM Food;

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

SELECT * FROM Account;

-- Thêm bàn ăn (TableFood)
INSERT INTO TableFood (name, status, isHidden)
VALUES 
(N'Bàn 1', N'Trống', 0),
(N'Bàn 2', N'Trống', 0),
(N'Bàn 3', N'Trống', 0),
(N'Bàn 4', N'Có khách', 0),
(N'Bàn 5', N'Có khách', 0),
(N'Bàn 6', N'Trống', 0),
(N'Bàn 7', N'Có khách', 0),
(N'Bàn 8', N'Có khách', 0),
(N'Bàn 9', N'Trống', 0),
(N'Bàn 10', N'Trống', 0);

SELECT * FROM TableFood;

-- Thêm Bill (50 hóa đơn)
SET DATEFORMAT DMY;
INSERT INTO Bill (DateCheckIn, DateCheckOut, idTable, isServed, status, discount, totalPrice)
VALUES
('01-01-2024 12:00', '01-01-2024 13:30', 4, 1, 1, 10, 300000),
('01-01-2024 12:30', '01-01-2024 14:00', 5, 1, 1, 0, 200000),
('02-01-2024 18:00', '02-01-2024 20:00', 7, 1, 1, 5, 350000),
('03-01-2024 19:00', '03-01-2024 21:00', 8, 1, 1, 0, 400000),
('04-01-2024 11:00', '04-01-2024 12:30', 6, 1, 0, 0, 150000);

-- Tiếp tục tạo 50 hóa đơn lặp lại
DECLARE @counter INT = 1;
WHILE @counter <= 45
BEGIN
    INSERT INTO Bill (DateCheckIn, DateCheckOut, idTable, isServed, status, discount, totalPrice)
    VALUES (
        DATEADD(DAY, @counter, '01-01-2024 12:00'),
        DATEADD(HOUR, 2, DATEADD(DAY, @counter, '01-01-2024 12:00')),
        (@counter % 10) + 1, -- Gán idTable ngẫu nhiên từ 1 đến 10
        1, 1, -- isServed và status luôn 1
        (@counter % 3) * 5, -- Discount 0, 5 hoặc 10%
        200000 + (@counter % 5) * 50000 -- Tổng tiền thay đổi ngẫu nhiên
    );

    SET @counter = @counter + 1;
END;

SELECT * FROM Bill;

-- Thêm BillInfo
DECLARE @counterBill INT = 1;
WHILE @counterBill <= 50
BEGIN
    INSERT INTO BillInfo (idBill, idFood, count)
    VALUES
    (@counterBill, (1 + (@counterBill % 11)), 1 + (@counterBill % 3)), -- Món ăn từ idFood 1 đến 11
    (@counterBill, (2 + (@counterBill % 11)), 2 + (@counterBill % 2)), 
    (@counterBill, (3 + (@counterBill % 11)), 1);

    SET @counterBill = @counterBill + 1;
END;

SELECT * FROM BillInfo;