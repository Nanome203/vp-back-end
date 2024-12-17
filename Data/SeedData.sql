
USE QLNH

SET DATEFORMAT DMY

--Thêm Food Category
INSERT INTO FoodCategory
    (name, isHidden)
VALUES
    (N'Hải sản', 0),
    (N'Gỏi', 0),
    (N'Mì', 0),
    (N'Cơm', 0),
    (N'Nước giải khát', 0),
    (N'Nước ép', 0)



SELECT *
FROM FoodCategory;

--Thêm Food 
INSERT INTO Food
    (name, idCategory, price, isHidden, imageLink)
VALUES
    (N'Hàu sữa nướng muối ớt', 1 , 150000, 0, 'https://toplist.vn/images/800px/hau-nuong-muoi-sot-ot-cay-748971.jpg' ),
    (N'Sò huyết hấp', 1 , 150000, 0, 'https://cdn.tgdd.vn/2021/02/CookRecipe/Avatar/so-huyet-hap-sa-thumbnail.jpg' ),
    (N'Mực hấp bia', 1 , 150000, 0, 'https://cdn.tgdd.vn/2021/12/CookRecipe/Avatar/muc-hap-bia-thumbnail.jpg' ),
    (N'Canh ngao chua', 1 , 150000, 0, 'https://yeutre.vn/cdn/medias/uploads/145/145701-canh-ngao-nau-chua.jpg' ),
    (N'Cơm trắng', 4, 20000, 0, 'https://vnn-imgs-f.vgcloud.vn/2019/09/18/11/an-com-trang-dung-cach.jpg'),
    (N'Coca Cola', 5, 15000, 0, 'https://th.bing.com/th/id/R.564ab3fd051aa10256c402a55a4732ab?rik=zqf02KqpCc4HkQ&pid=ImgRaw&r=0'),
    (N'Sữa đậu nành', 5, 12000, 0 , 'https://tinhdau100.vn/uploads/images/bai-viet-2/sua-dau-nanh-1.jpg'),
    (N'Fanta', 5, 15000, 0, 'https://th.bing.com/th/id/OIP.DH9xV2fXAIfBZZra0DwuHgHaHm?rs=1&pid=ImgDetMain'),
    (N'7Up', 5, 15000, 0, 'https://media.supermart.ae/14086-thickbox_default/7up-regular-500ml.jpg'),
    (N'Nước lọc', 5, 10000, 0, 'https://happythai.vn/uploads/source/san-pham/nuoc-ngot/35ec109465feb5a0ecef10.jpg'),
    (N'Chanh dây', 6, 15000, 0 , 'https://th.bing.com/th/id/OIP.TkdGMulc07Gz94wZIILQQgHaHa?rs=1&pid=ImgDetMain')


-- Thêm tài khoản
INSERT INTO Account
    (UserName, DisplayName, PassWord, Type)
VALUES
    (N'Admin', N'Trương Văn Bình', 'admin', 524287),
    --MK: AD
    (N'Phuoc', N'Phan Ngọc Phước', '4229125024382100611251781583929172146215', 0),
    --MK: ST1
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

SELECT *
FROM Account;

-- Thêm bàn ăn (TableFood)
INSERT INTO TableFood
    (name, status, isHidden)
VALUES
    (N'Bàn 1', N'Chưa hoạt động', 0),
    (N'Bàn 2', N'Chưa hoạt động', 0),
    (N'Bàn 3', N'Chưa hoạt động', 0),
    (N'Bàn 4', N'Chờ thanh toán', 0),
    (N'Bàn 5', N'Đang hoạt động', 0),
    (N'Bàn 6', N'Chưa hoạt động', 0),
    (N'Bàn 7', N'Đang hoạt động', 0),
    (N'Bàn 8', N'Đang hoạt động', 0),
    (N'Bàn 9', N'Chưa hoạt động', 0),
    (N'Bàn 10', N'Chưa hoạt động', 0);

SELECT *
FROM TableFood;

-- Thêm Bill (50 hóa đơn)
SET DATEFORMAT DMY;
INSERT INTO Bill
    (DateCheckIn, DateCheckOut, idTable, status, discount, totalPrice)
VALUES
    ('01-01-2024 12:00', '01-01-2024 13:30', 4, 0, 10, 300000),
    --0: chưa thanh toán, 1: đã thanh toán
    ('01-01-2024 12:30', '01-01-2024 14:00', 5, 0, 0, 200000),
    ('02-01-2024 18:00', '02-01-2024 20:00', 7, 0, 5, 350000),
    ('03-01-2024 19:00', '03-01-2024 21:00', 8, 0, 0, 400000),
    ('04-01-2024 11:00', '04-01-2024 12:30', 6, 1, 0, 150000);

-- Tiếp tục tạo 50 hóa đơn lặp lại
-- DECLARE @counter INT = 1;
-- WHILE @counter <= 45
-- BEGIN
--     INSERT INTO Bill
--         (DateCheckIn, DateCheckOut, idTable, status, discount, totalPrice)
--     VALUES
--         (
--             DATEADD(DAY, @counter, '01-01-2024 12:00'),
--             DATEADD(HOUR, 2, DATEADD(DAY, @counter, '01-01-2024 12:00')),
--             (@counter % 10) + 1, -- Gán idTable ngẫu nhiên từ 1 đến 10
--             1, -- isServed và status luôn 1
--             (@counter % 3) * 5, -- Discount 0, 5 hoặc 10%
--             200000 + (@counter % 5) * 50000 -- Tổng tiền thay đổi ngẫu nhiên
--     );

--     SET @counter = @counter + 1;
-- END;

SELECT *
FROM Bill;

-- Thêm BillInfo
DECLARE @counterBill INT = 1;
WHILE @counterBill <= 50
BEGIN
    INSERT INTO BillInfo
        (idBill, idFood, count)
    VALUES
        (@counterBill, (1 + (@counterBill % 11)), 1 + (@counterBill % 3)),
        -- Món ăn từ idFood 1 đến 11
        (@counterBill, (2 + (@counterBill % 11)), 2 + (@counterBill % 2)),
        (@counterBill, (3 + (@counterBill % 11)), 1);

    SET @counterBill = @counterBill + 1;
END;

SELECT *
FROM BillInfo;
