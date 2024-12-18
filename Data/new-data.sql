CREATE DATABASE QLNH
GO

USE QLNH
GO

SET DATEFORMAT DMY

CREATE TABLE TableFood
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên' ,
	status NVARCHAR(100) NOT NULL DEFAULT N'Trống',--Trống || Có người
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

CREATE PROC USP_GetAccountByUserName
@userName NVARCHAR(100)
AS 
BEGIN
	SELECT * FROM Account WHERE UserName = @userName
END
GO

EXEC USP_GetAccountByUserName @userName = N'Admin'
GO

CREATE PROC USP_Login
@userName NVARCHAR(100), @passWord NVARCHAR(100)
AS
BEGIN
	SELECT * FROM Account WHERE UserName = @userName AND PassWord = @passWord
END
GO

--Thêm bàn
DECLARE @i INT = 1

WHILE @i <= 100
BEGIN
	INSERT INTO TableFood (name) VALUES (N'Bàn ' + CAST(@i AS NVARCHAR(100)))
	SET @i = @i + 1
END
GO

CREATE PROC USP_GetTableList
AS SELECT * FROM TableFood WHERE isHidden = 0
GO

EXEC USP_GetTableList
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
INSERT INTO Food (name, idCategory, price) VALUES (N'Hàu sữa nướng muối ớt', 1 , 150000 )
INSERT INTO Food (name, idCategory, price) VALUES (N'Sò huyết hấp', 1 , 150000 )
INSERT INTO Food (name, idCategory, price) VALUES (N'Mực hấp bia', 1 , 150000 )
INSERT INTO Food (name, idCategory, price) VALUES (N'Canh ngao chua', 1 , 150000 )
INSERT INTO Food (name, idCategory, price) VALUES (N'Cua nướng muối ớt', 1 , 130000 )
INSERT INTO Food (name, idCategory, price) VALUES (N'Tôm hùm nướng phô mai', 1 , 250000)
INSERT INTO Food (name, idCategory, price) VALUES (N'Canh cá chua', 1, 150000)
INSERT INTO Food (name, idCategory, price) VALUES (N'Cá thu sốt cà chua', 1 , 200000 )
INSERT INTO Food (name, idCategory, price) VALUES (N'Canh cua cà pháo', 1 , 70000)
INSERT INTO Food (name, idCategory, price) VALUES (N'Gỏi xoài tôm khô', 2, 100000)
INSERT INTO Food (name, idCategory, price) VALUES (N'Gỏi ngó sen tôm thịt', 2, 100000)
INSERT INTO Food (name, idCategory, price) VALUES (N'Gỏi đu đủ trộn tai heo', 2, 100000)
INSERT INTO Food (name, idCategory, price) VALUES (N'Gỏi xoài khô mực', 2, 100000)
INSERT INTO Food (name, idCategory, price) VALUES (N'Gỏi cá trích', 2, 120000)
INSERT INTO Food (name, idCategory, price) VALUES (N'Mì xào bò', 3, 75000)
INSERT INTO Food (name, idCategory, price) VALUES (N'Mì xào trứng', 3, 65000)
INSERT INTO Food (name, idCategory, price) VALUES (N'Mì xào tóp mỡ', 3, 75000)
INSERT INTO Food (name, idCategory, price) VALUES (N'Mì xào hải sản', 3, 80000)
INSERT INTO Food (name, idCategory, price) VALUES (N'Cơm chiên dương châu', 4, 90000)
INSERT INTO Food (name, idCategory, price) VALUES (N'Cơm chiên thập cẩm', 4, 85000)
INSERT INTO Food (name, idCategory, price) VALUES (N'Cơm chiên cua tôm', 4, 95000)
INSERT INTO Food (name, idCategory, price) VALUES (N'Cơm chiên bọc trứng', 4, 85000)
INSERT INTO Food (name, idCategory, price) VALUES (N'Cơm trắng', 4, 20000)
INSERT INTO Food (name, idCategory, price) VALUES (N'Coca Cola', 5, 15000)
INSERT INTO Food (name, idCategory, price) VALUES (N'Sữa đậu nành', 5, 12000)
INSERT INTO Food (name, idCategory, price) VALUES (N'Fanta', 5, 15000)
INSERT INTO Food (name, idCategory, price) VALUES (N'7Up', 5, 15000)
INSERT INTO Food (name, idCategory, price) VALUES (N'Nước lọc', 5, 10000)
INSERT INTO Food (name, idCategory, price) VALUES (N'Xá xị', 5, 15000)
INSERT INTO Food (name, idCategory, price) VALUES (N'Pepsi', 5, 15000)
INSERT INTO Food (name, idCategory, price) VALUES (N'Nước tăng lực', 5, 15000)
INSERT INTO Food (name, idCategory, price) VALUES (N'Nước cam', 6, 20000)
INSERT INTO Food (name, idCategory, price) VALUES (N'Nước dưa hấu', 6, 20000)
INSERT INTO Food (name, idCategory, price) VALUES (N'Nước ổi', 6, 20000)
INSERT INTO Food (name, idCategory, price) VALUES (N'Nước tắc', 6, 10000)
INSERT INTO Food (name, idCategory, price) VALUES (N'Nước chanh', 6, 20000)
INSERT INTO Food (name, idCategory, price) VALUES (N'Chanh dây', 6, 15000)
GO

-- Thêm tài khoản
INSERT INTO Account (UserName, DisplayName, PassWord, Type) VALUES (N'Admin', N'Nguyễn Minh Nhật', 'admin', 524287), 
 (N'Tuong', N'Trịnh Kiến Tường', 'staff', 0), 
 (N'Triet', N'Phạm Minh Triết', 'staff', 0),
 (N'Lam', N'Nguyễn Cao Lãm', 'staff', 0),
 (N'Den', N'Đen Vâu', 'staff', 0),
 (N'Vu', N'Hoàng Thái Vũ', 'staff', 0),
 (N'Tung', N'Sơn Tùng MTP', 'staff', 0),
 (N'Dinh', N'Thái Đinh', 'staff', 0),
 (N'Quynh', N'Phan Mạnh Quỳnh', 'staff', 0)


SELECT f.name, bi.count, f.price, f.price * bi.count AS totalPrice
FROM BillInfo bi, Bill b, Food f
WHERE bi.idBill = b.id AND bi.idFood = f.id AND b.idTable = 55

GO

CREATE PROC USP_InsertBill
@idTable INT
AS
BEGIN
	INSERT dbo.Bill 
		( DateCheckIn,
	      DateCheckOut,
		  idTable,
		  status,
		  discount
		)
	VALUES (GETDATE(),
			NULL,
			@idTable,
			0,
			0
		   )
END 
GO

CREATE PROC USP_InsertBillInfo
@idBill INT, @idFood INT, @count INT
AS
BEGIN
	DECLARE @isExitsBillInfo INT
	DECLARE @FoodCount INT = 1
	SELECT @isExitsBillInfo = id, @FoodCount = dbb.count 
	FROM dbo.BillInfo AS dbb
	WHERE idBill = @idBill AND idFood = @idFood

	IF (@isExitsBillInfo > 0)
	BEGIN
		DECLARE @newCount INT = @FoodCount + @count
		IF (@newCount > 0)
			UPDATE dbo.BillInfo SET count = @FoodCount + @count WHERE idBill = @idBill AND idFood = @idFood
		ELSE
			DELETE dbo.BillInfo WHERE idBill = @idBill AND idFood = @idFood
	END 
	ELSE
	BEGIN
		INSERT dbo.BillInfo
			( idBill, idFood, count)
		VALUES (@idBill, @idFood, @count)
	END
END 
GO

CREATE TRIGGER UTG_UpdateBillInfo
ON BillInfo FOR INSERT, UPDATE
AS 
BEGIN
DECLARE @idBill INT
	
	SELECT @idBill = idBill FROM Inserted
	
	DECLARE @idTable INT
	
	SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill AND (status = 0	OR isServed = 0)
	
	DECLARE @count INT
	SELECT @count = COUNT(*) FROM dbo.BillInfo WHERE idBill = @idBill
	
	IF (@count > 0)
	BEGIN
	
		PRINT @idTable
		PRINT @idBill
		PRINT @count
		
		UPDATE dbo.TableFood SET status = N'Có người' WHERE id = @idTable		
		
	END		
	ELSE
	BEGIN
	PRINT @idTable
		PRINT @idBill
		PRINT @count
	UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable	
	END
	
END
GO

CREATE TRIGGER UTG_UpdateBill
ON Bill FOR UPDATE
AS 
BEGIN
	DECLARE @idBill INT
	
	SELECT @idBill = id FROM Inserted	
	
	DECLARE @idTable INT
	
	SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill
	
	DECLARE @count int = 0
	
	SELECT @count = COUNT(*) FROM dbo.Bill WHERE idTable = @idTable AND (status = 0 or isServed = 0)
	
	IF (@count = 0)
		UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable
END
GO

CREATE PROC USP_GetAccountInfo
AS
BEGIN
	SELECT UserName, DisplayName, [Type] FROM Account
END
GO


CREATE PROC USP_SwitchTable
@idTable1 INT, @idTable2 int
AS BEGIN

	DECLARE @idFirstBill int
	DECLARE @idSecondBill INT
	
	SELECT @idSecondBill = id FROM dbo.Bill WHERE idTable = @idTable2 AND (status = 0 or isServed = 0)
	SELECT @idFirstBill = id FROM dbo.Bill WHERE idTable = @idTable1 AND (status = 0 or isServed = 0)
	
	IF (@idSecondBill IS NULL)
	BEGIN
		UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable1
		UPDATE Bill SET idTable = @idTable2 WHERE id = @idFirstBill
		RETURN
	END

	IF (@idFirstBill IS NULL)
	BEGIN
		UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable2
		UPDATE Bill SET idTable = @idTable1 WHERE id = @idSecondBill
		RETURN
	END

	

	SELECT id INTO IDBillInfoTable FROM dbo.BillInfo WHERE idBill = @idSecondBill
	
	UPDATE dbo.BillInfo SET idBill = @idSecondBill WHERE idBill = @idFirstBill
	
	UPDATE dbo.BillInfo SET idBill = @idFirstBill WHERE id IN (SELECT * FROM IDBillInfoTable)
	
	DROP TABLE IDBillInfoTable
END
GO


CREATE PROC USP_GetListBillByDate
@checkIn date, @checkOut date
AS
BEGIN
	SELECT b.id 'Mã đơn', t.name AS [Tên bàn], discount AS [Giảm giá], b.totalPrice AS [Tổng tiền], DateCheckOut AS [Ngày]
	FROM Bill AS b, TableFood AS t
	WHERE DateCheckOut >= @checkIn AND DateCheckOut <= @checkOut AND b.status = 1
	AND t.id = b.idTable
END
GO

CREATE PROC USP_GetTotalMoneyByDate
@checkIn date, @checkOut date
AS
BEGIN
	SELECT SUM(cast(b.TotalPrice as float)) 'totalMoney'
	FROM Bill AS b, TableFood AS t
	WHERE DateCheckOut >= @checkIn AND DateCheckOut <= @checkOut AND b.status = 1
	AND t.id = b.idTable
END
GO

CREATE PROC USP_UpdateAccount
@userName NVARCHAR(100), @displayName NVARCHAR(100), @password NVARCHAR(100), @newPassword NVARCHAR(100)
AS 
BEGIN 
	DECLARE @isRightPass INT = 0
	SELECT @isRightPass = COUNT(*) FROM Account WHERE UserName = @userName AND PassWord = @password

	IF(@isRightPass = 1)
	BEGIN 
		IF (@newPassword = NULL OR @newPassword = '')
		BEGIN 
			UPDATE Account SET DisplayName = @displayName WHERE UserName = @userName
		END 
		ELSE 
			UPDATE Account SET DisplayName = @displayName ,PassWord = @newpassword WHERE UserName = @userName
	END 
END 
GO 

CREATE TRIGGER UTG_DeleteBill
ON Bill FOR DELETE
AS
BEGIN
	DECLARE @idTable INT
	SELECT @idTable = idTable FROM deleted

	UPDATE TableFood SET status = N'Trống' WHERE id = @idTable
END
GO

CREATE PROC USP_NewInsertBillInfo
@idBill INT, @idFood INT, @count INT
AS
BEGIN
	DECLARE @isExitsBillInfo INT
	SELECT @isExitsBillInfo = id
	FROM dbo.BillInfo
	WHERE idBill = @idBill AND idFood = @idFood

	IF (@isExitsBillInfo > 0)
	BEGIN
		IF (@count > 0)
			UPDATE dbo.BillInfo SET count = @count WHERE idBill = @idBill AND idFood = @idFood
		ELSE
			DELETE dbo.BillInfo WHERE idBill = @idBill AND idFood = @idFood
	END 
	ELSE
	BEGIN
		IF (@count > 0)
		BEGIN
			INSERT dbo.BillInfo (idBill, idFood, count)
			VALUES (@idBill, @idFood, @count)
		END
	END
END 
GO

CREATE PROC USP_GetListProcessingBill
AS
BEGIN
	SELECT b.id , t.name 'tableName' , b.totalPrice , N'' 'Trạng Thái'  , discount, t.id 'idTable', b.isServed, b.status
	FROM Bill b, TableFood t
	WHERE (b.status = 0 OR b.isServed = 0) AND t.id = b.idTable
END
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
                
                DECLARE @TableID INT = 1 + (ABS(CHECKSUM(NEWID())) % 90)
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
