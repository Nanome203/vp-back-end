CREATE DATABASE QLNH

USE QLNH


SET DATEFORMAT DMY



--Thêm Food Category
INSERT INTO FoodCategory
    (name, isHidden)
VALUES
    (N'Hải sản/Seafood', 0),
    (N'Gỏi/Salad', 0),
    (N'Mì/Noodle', 0),
    (N'Cơm/Rice', 0),
    (N'Nước giải khát/Drinks', 0),
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

DELETE FROM Food;
-- Thêm tài khoản
INSERT INTO Account
    (UserName, DisplayName, PassWord, Type)
VALUES
    (N'Admin', N'Trương Văn Bình', '225130235188221091155411012113412958127197241', 524287),
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

delete from Account;
delete from Food;
delete from FoodCategory;



