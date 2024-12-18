-- Lần đầu chỉ chạy đến hết insert table Account và lần 2 Chạy riêng Insert USP_GenerateSampleData
CREATE DATABASE QLNH
GO

USE QLNH
GO

SET DATEFORMAT DMY

CREATE TABLE TableFood
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên' ,
	status NVARCHAR(100) NOT NULL DEFAULT N'Chưa hoạt động',--Trống || Có người
	isHidden INT NOT NULL DEFAULT 0 -- 1: Ẩn, 0: Hiện 
)
GO

CREATE TABLE Account
(
	UserName NVARCHAR(100) PRIMARY KEY,
	DisplayName NVARCHAR(100) NOT NULL DEFAULT N'Admin',
	PassWord NVARCHAR(1000) NOT NULL DEFAULT 0,
	Type INT NOT NULL DEFAULT 0, --1: Admin && 0: Staff
	isHidden INT NOT NULL DEFAULT 0 -- 1: Ẩn, 0: Hiện 
)
GO

CREATE TABLE FoodCategory
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
	isHidden INT NOT NULL DEFAULT 0, -- 1: Ẩn, 0: Hiện
)
GO

CREATE TABLE Food
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
	idCategory INT NOT NULL,
	price FLOAT NOT NULL DEFAULT 0,
	imageLink NVARCHAR(255) NOT NULL DEFAULT N'unavailable',
	isHidden INT NOT NULL DEFAULT 0, -- 1: Ẩn, 0: Hiện
	FOREIGN KEY (idCategory) REFERENCES dbo.FoodCategory(id)
)
GO

CREATE TABLE Bill
(
	id INT IDENTITY PRIMARY KEY,
	DateCheckIn DATETIME NOT NULL DEFAULT GETDATE(),
	DateCheckOut DATE,
	idTable INT NOT NULL,
	status INT NOT NULL DEFAULT 0, --1: Đã thanh toán && 0: Chưa thanh toán
	discount INT NOT NULL DEFAULT 0,
	totalPrice FLOAT NOT NULL DEFAULT 0,
	isHidden INT NOT NULL DEFAULT 0, -- 1: Ẩn, 0: Hiện

	FOREIGN KEY (idTable) REFERENCES dbo.TableFood(id)
)
GO

CREATE TABLE BillInfo
(
	id INT IDENTITY PRIMARY KEY,
	idBill INT NOT NULL,
	idFood INT NOT NULL,
	count INT NOT NULL DEFAULT 0,
	isHidden INT NOT NULL DEFAULT 0, -- 1: Ẩn, 0: Hiện

	FOREIGN KEY (idFood) REFERENCES dbo.Food(id),
	FOREIGN KEY (idBill) REFERENCES dbo.Bill(id)
)
GO

--Thêm bàn
DECLARE @i INT = 1

WHILE @i <= 20
BEGIN
	INSERT INTO TableFood (name) VALUES (N'Bàn ' + CAST(@i AS NVARCHAR(100)))
	SET @i = @i + 1
END
GO


--Thêm Food Category
INSERT INTO FoodCategory (name) VALUES (N'Hải sản/Seafood')
INSERT INTO FoodCategory (name) VALUES (N'Gỏi/Salad')
INSERT INTO FoodCategory (name) VALUES (N'Mì/Noodle')
INSERT INTO FoodCategory (name) VALUES (N'Cơm/Rice')
INSERT INTO FoodCategory (name) VALUES (N'Nước giải khát/Drinks')
INSERT INTO FoodCategory (name) VALUES (N'Nước ép')
GO

--Thêm Food 
INSERT INTO Food (name, idCategory, price, imageLink) VALUES (N'Hàu sữa nướng muối ớt', 1 , 150000, 'https://gofood.vn//upload/r/tong-hop-tin-tuc/huong-dan-mon-ngon/cach-lam-hau-nuong-mo-hanh-gofood.jpg' ),
(N'Sò huyết hấp', 1 , 150000, 'https://yummyday.vn/uploads/images/so-huyet-hap.jpg' ),
(N'Mực hấp bia', 1 , 150000, 'https://i-giadinh.vnecdn.net/2023/11/02/Thnhphm11-1698908868-5353-1698908989.jpg' ),
(N'Canh ngao chua', 1 , 150000, 'https://iv.vnecdn.net/giadinh/images/web/2021/05/29/cach-lam-canh-ngao-nau-dua-dua-com-mua-he-1622272767.jpg' ),
(N'Cua nướng muối ớt', 1 , 130000, 'https://ngonviet247.com/wp-content/uploads/2019/04/Cua-Nuong-Muoi-Ot.jpg' ),
(N'Tôm hùm nướng phô mai', 1 , 250000, 'https://www.cet.edu.vn/wp-content/uploads/2019/01/tom-hum-nuong-bo-toi-1.jpg'),
(N'Canh cá chua', 1, 150000, 'https://i.ytimg.com/vi/zNhazi2P4yI/hq720.jpg?sqp=-oaymwEhCK4FEIIDSFryq4qpAxMIARUAAAAAGAElAADIQj0AgKJD&rs=AOn4CLCGDf9GlJVxCRR7KD0LBzoFAwEO-Q'),
(N'Cá thu sốt cà chua', 1 , 200000, 'https://cdn.tgdd.vn/Files/2019/10/18/1209996/cach-nau-ca-thu-sot-ca-chua-ngon-kho-cuong-don-gian-tai-nha-6.jpg' ),
(N'Canh cua cà pháo', 1 , 70000, 'https://icdn.24h.com.vn/upload/2-2023/images/2023-06-17/1687015124-ca-muoi-xoi-1686969354162405886485-width640height407.jpg'),
(N'Gỏi xoài tôm khô', 2, 100000, 'https://img-global.cpcdn.com/recipes/2436699_508d77f785dc3e98/680x482cq70/g%E1%BB%8Fi-xoai-tom-kho-recipe-main-photo.jpg'),
(N'Gỏi ngó sen tôm thịt', 2, 100000, 'https://i.ytimg.com/vi/dTAHH5mQAZ0/maxresdefault.jpg'),
(N'Gỏi đu đủ trộn tai heo', 2, 100000, 'https://i.ex-cdn.com/nongnghiep.vn/files/dungct/2021/07/16/goi-du-du-tron-tai-heo_nongnghiep-164519_483.jpg'),
(N'Gỏi xoài khô mực', 2, 100000, 'https://cdn.tgdd.vn/Files/2021/08/21/1376848/cach-lam-goi-xoai-kho-muc-chua-ngot-ngon-kho-cuong-202201071120087279.jpg'),
(N'Gỏi cá trích', 2, 120000, 'https://netspace.edu.vn/upload/images/2016/08/23/goi-ca-trich-1.jpg'),
(N'Mì xào bò', 3, 75000, 'https://cdn.tgdd.vn/2021/12/CookDish/cach-lam-mi-goi-xao-thit-bo-don-gian-thom-ngon-hap-dan-ai-avt-1200x676.jpg'),
(N'Mì xào trứng', 3, 65000, 'https://cdn2.fptshop.com.vn/unsafe/1920x0/filters:quality(100)/2023_12_12_638379714166884908_cach-lam-mi-xao-trung.jpg'),
(N'Mì xào tóp mỡ', 3, 75000, 'https://bizweb.dktcdn.net/100/021/974/products/z2339653011488-6d52524e3bfddadd93bf2a41e5ad7fa3.jpg?v=1613820770937'),
(N'Mì xào hải sản', 3, 80000, 'https://netspace.edu.vn/app_assets/images/2021/07/18/cach-lam-mi-xao-hai-san-800.jpg'),
(N'Cơm chiên dương châu', 4, 90000, 'https://vcdn1-giadinh.vnecdn.net/2022/12/30/Buoc-4-4-4790-1672386702.jpg?w=460&h=0&q=100&dpr=2&fit=crop&s=o6bWUsUkMEMh5QvVeBPRCQ'),
(N'Cơm chiên thập cẩm', 4, 85000, 'https://i.ytimg.com/vi/iTg-z-INLPk/maxresdefault.jpg'),
(N'Cơm chiên cua tôm', 4, 95000, 'https://i-giadinh.vnecdn.net/2021/10/21/comchiencua-1634789802-4785-1634789818.jpg'),
(N'Cơm chiên bọc trứng', 4, 85000, 'https://cdn.tgdd.vn/2020/12/CookProduct/0-0000-1200x675.jpg'),
(N'Cơm trắng', 4, 20000, 'https://image.bephoa.vn/data/thumb_750/2023/06/202306231118195612.webp'),
(N'Coca Cola', 5, 15000, 'https://upload.wikimedia.org/wikipedia/commons/2/27/Coca_Cola_Flasche_-_Original_Taste.jpg'),
(N'Sữa đậu nành', 5, 12000, 'https://upload.wikimedia.org/wikipedia/commons/0/0f/001-soymilk.jpg'),
(N'Fanta', 5, 15000, 'https://bizweb.dktcdn.net/thumb/grande/100/236/638/products/18-55918f9b-1d05-41e3-ba21-8fe883e5128f.jpg?v=1726564978173'),
(N'7Up', 5, 15000, 'https://product.hstatic.net/200000407109/product/nuoc-ngot-7-up-vi-chanh-330ml-201905301056152288_db464b14145048a885a28c42cbb2af9c.jpg'),
(N'Nước lọc', 5, 10000, 'https://aquafinavietnam.com/wp-content/uploads/chai-aquafina-500ml-2.jpg'),
(N'Xá xị', 5, 15000, 'https://www.lottemart.vn/media/catalog/product/8/9/8934588132117.jpg'),
(N'Pepsi', 5, 15000, 'https://product.hstatic.net/1000288770/product/nuoc_ngot_pepsi_cola_lon_330ml_5d1df64d846f4f93aa666c723cea177d_master.jpg'),
(N'Nước tăng lực', 5, 15000, 'https://product.hstatic.net/200000459373/product/8936148070563__41__097e9c61c44d4bbe8ef840f4bdd21df0_master.png'),
(N'Nước cam', 6, 20000, 'https://www.lottemart.vn/media/catalog/product/cache/0x0/8/9/8934588192227.jpg.webp'),
(N'Nước dưa hấu', 6, 20000, 'https://www.cet.edu.vn/wp-content/uploads/2020/06/cach-lam-nuoc-ep-dua-hau.jpg'),
(N'Nước ổi', 6, 20000, 'https://file.hstatic.net/200000868155/file/post-tac-dung-nuoc-ep-oi-voi-suc-khoe-cach-uong-nuoc-ep-oi-dung-cach-1.jpg'),
(N'Nước tắc', 6, 10000, 'https://cdn.tgdd.vn/Files/2019/07/08/1178150/cach-lam-nuoc-tac-muoi-dam-da-hon-nguoi-yeu-cu-cua-ban-201907112255586760.jpg'),
(N'Nước chanh', 6, 20000, 'https://suckhoedoisong.qltns.mediacdn.vn/324455921873985536/2024/2/24/photo-1708768261159-17087682613401304849137.jpeg'),
(N'Chanh dây', 6, 15000, 'https://data-service.pharmacity.io/pmc-upload-media/production/pmc-ecm-asm/posts/uong-chanh-day-14.webp')
GO

-- Thêm tài khoản
INSERT INTO Account (UserName, DisplayName, PassWord, Type) VALUES (N'Admin', N'Nguyễn Minh Nhật', 'admin', 1), 
 (N'Tuong', N'Trịnh Kiến Tường', 'staff', 0), 
 (N'Triet', N'Phạm Minh Triết', 'staff', 0),
 (N'Lam', N'Nguyễn Cao Lãm', 'staff', 0),
 (N'Den', N'Đen Vâu', 'staff', 0),
 (N'Vu', N'Hoàng Thái Vũ', 'staff', 0),
 (N'Tung', N'Sơn Tùng MTP', 'staff', 0),
 (N'Dinh', N'Thái Đinh', 'staff', 0),
 (N'Quynh', N'Phan Mạnh Quỳnh', 'staff', 0)
GO


CREATE OR ALTER PROC USP_GenerateSampleData
    @StartDate DATE,
    @EndDate DATE
AS
BEGIN
    CREATE TABLE #SelectedDays (TheDate DATE)
    
    DECLARE @CurrentMonth INT = MONTH(@StartDate)
    DECLARE @CurrentYear INT = YEAR(@StartDate)
    
    WHILE (@CurrentYear * 12 + @CurrentMonth) <= (YEAR(@EndDate) * 12 + MONTH(@EndDate))
    BEGIN
        ;WITH DateRange AS (
            SELECT TOP (DAY(EOMONTH(DATEFROMPARTS(@CurrentYear, @CurrentMonth, 1))))
            DATEFROMPARTS(@CurrentYear, @CurrentMonth, ROW_NUMBER() OVER (ORDER BY (SELECT NULL))) AS TheDate
            FROM master.dbo.spt_values
        )
        INSERT INTO #SelectedDays
        SELECT TOP 5 TheDate
        FROM DateRange
        ORDER BY NEWID()

        DECLARE @CurrentDate DATE
        DECLARE DateCursor CURSOR FOR SELECT TheDate FROM #SelectedDays
        
        OPEN DateCursor
        FETCH NEXT FROM DateCursor INTO @CurrentDate
        
        WHILE @@FETCH_STATUS = 0
        BEGIN
            -- Số hóa đơn ngẫu nhiên trong ngày (10-30)
            DECLARE @BillCount INT = 10 + ABS(CHECKSUM(NEWID())) % 21
            DECLARE @BillNumber INT = 1
            
            WHILE @BillNumber <= @BillCount
            BEGIN
                -- Tạo thời gian ngẫu nhiên
                DECLARE @Hour INT = CASE 
                    WHEN @BillNumber <= @BillCount/2 THEN 11 + (ABS(CHECKSUM(NEWID())) % 4)
                    ELSE 17 + (ABS(CHECKSUM(NEWID())) % 6)
                END
                DECLARE @Minute INT = ABS(CHECKSUM(NEWID())) % 60
                
                DECLARE @TableID INT = 1 + (ABS(CHECKSUM(NEWID())) % 20)
                DECLARE @Discount INT = (ABS(CHECKSUM(NEWID())) % 3) * 5
                
                -- Random tổng tiền (350,000 - 1,500,000)
                DECLARE @TotalPrice FLOAT = 350000 + (ABS(CHECKSUM(NEWID())) % 1150001)
                
                DECLARE @CheckInTime DATETIME = DATEADD(MINUTE, @Minute, DATEADD(HOUR, @Hour, CAST(@CurrentDate AS DATETIME)))

                INSERT INTO Bill (DateCheckIn, DateCheckOut, idTable, status, discount, totalPrice)
                VALUES (
                    @CheckInTime,
                    @CurrentDate,
                    @TableID,
                    1,
                    @Discount,
                    @TotalPrice
                )

                DECLARE @CurrentBillId INT = SCOPE_IDENTITY()
                
                -- Số món ngẫu nhiên (5-15)
                DECLARE @FoodCount INT = 5 + (ABS(CHECKSUM(NEWID())) % 11)
                
                -- Thêm món chính (2-5 món)
                INSERT INTO BillInfo (idBill, idFood, count)
                SELECT TOP (2 + (ABS(CHECKSUM(NEWID())) % 4))
                    @CurrentBillId,
                    id,
                    1 + (ABS(CHECKSUM(NEWID())) % 3)
                FROM Food 
                WHERE idCategory IN (1, 3, 4)
                ORDER BY NEWID()
                
                -- Thêm món phụ (1-3 món)
                INSERT INTO BillInfo (idBill, idFood, count)
                SELECT TOP (1 + (ABS(CHECKSUM(NEWID())) % 3))
                    @CurrentBillId,
                    id,
                    1 + (ABS(CHECKSUM(NEWID())) % 2)
                FROM Food 
                WHERE idCategory = 2
                ORDER BY NEWID()
                
                -- Thêm đồ uống (2-7 món)
                INSERT INTO BillInfo (idBill, idFood, count)
                SELECT TOP (2 + (ABS(CHECKSUM(NEWID())) % 6))
                    @CurrentBillId,
                    id,
                    1 + (ABS(CHECKSUM(NEWID())) % 3)
                FROM Food 
                WHERE idCategory IN (5, 6)
                ORDER BY NEWID()
                
                SET @BillNumber = @BillNumber + 1
            END
            
            FETCH NEXT FROM DateCursor INTO @CurrentDate
        END
        
        CLOSE DateCursor
        DEALLOCATE DateCursor
        DELETE FROM #SelectedDays
        
        SET @CurrentMonth = @CurrentMonth + 1
        IF @CurrentMonth > 12
        BEGIN
            SET @CurrentMonth = 1
            SET @CurrentYear = @CurrentYear + 1
        END
    END
    
    DROP TABLE #SelectedDays
END
GO

EXEC USP_GenerateSampleData '2023-11-01', '2024-11-30'
GO

-- Kiểm tra kết quả
SELECT 
    CONVERT(date, DateCheckOut) as [Ngày],
    COUNT(*) as [Số hóa đơn],
    SUM(totalPrice) as [Doanh thu]
FROM Bill
WHERE status = 1
GROUP BY CONVERT(date, DateCheckOut)
ORDER BY [Ngày]
GO
