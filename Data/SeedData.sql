CREATE DATABASE QLNH

USE QLNH
GO

SET DATEFORMAT DMY

GO


CREATE PROC USP_GetAccountByUserName
@userName NVARCHAR(100)
AS 
BEGIN
	SELECT * FROM Account WHERE UserName = @userName
END
GO

EXEC USP_GetAccountByUserName @userName = N'Anh0505'
GO

CREATE PROC USP_Login
@userName NVARCHAR(100), @passWord NVARCHAR(100)
AS
BEGIN
	SELECT * FROM Account WHERE UserName = @userName AND PassWord = @passWord
END
GO

--Thêm bàn
DECLARE @i INT = 0

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
INSERT INTO FoodCategory (name, isHidden) VALUES (N'Hải sản/Seafood', 0)
INSERT INTO FoodCategory (name, isHidden) VALUES (N'Gỏi/Salad', 0)
INSERT INTO FoodCategory (name, isHidden) VALUES (N'Mì/Noodle', 0)
INSERT INTO FoodCategory (name, isHidden) VALUES (N'Cơm/Rice', 0)
INSERT INTO FoodCategory (name, isHidden) VALUES (N'Nước giải khát/Drinks',0)
INSERT INTO FoodCategory (name, isHidden) VALUES (N'Nước ép', 0)
GO

SELECT * FROM FoodCategory;

--Thêm Food 
INSERT INTO Food (name, idCategory, price, isHidden) VALUES (N'Hàu sữa nướng muối ớt', 19 , 150000, 0 )
INSERT INTO Food (name, idCategory, price, isHidden) VALUES (N'Sò huyết hấp', 1 , 150000, 0 )
INSERT INTO Food (name, idCategory, price, isHidden) VALUES (N'Mực hấp bia', 1 , 150000, 0 )
INSERT INTO Food (name, idCategory, price, isHidden) VALUES (N'Canh ngao chua', 1 , 150000, 0 )
INSERT INTO Food (name, idCategory, price, isHidden) VALUES (N'Cơm trắng', 4, 20000, 0)
INSERT INTO Food (name, idCategory, price, isHidden) VALUES (N'Coca Cola', 5, 15000, 0)
INSERT INTO Food (name, idCategory, price, isHidden) VALUES (N'Sữa đậu nành', 5, 12000, 0)
INSERT INTO Food (name, idCategory, price, isHidden) VALUES (N'Fanta', 5, 15000, 0)
INSERT INTO Food (name, idCategory, price, isHidden) VALUES (N'7Up', 5, 15000, 0)
INSERT INTO Food (name, idCategory, price, isHidden) VALUES (N'Nước lọc', 5, 10000, 0)
INSERT INTO Food (name, idCategory, price, isHidden) VALUES (N'Chanh dây', 6, 15000, 0)
GO

-- Thêm tài khoản
INSERT INTO Account (UserName, DisplayName, PassWord, Type) VALUES (N'Admin', N'Trương Văn Bình', '225130235188221091155411012113412958127197241', 524287) --MK: AD
INSERT INTO Account VALUES (N'Phuoc', N'Phan Ngọc Phước', '4229125024382100611251781583929172146215', 0) --MK: ST1
INSERT INTO Account VALUES (N'Manh', N'Hoàng Đức Mạnh', '4229125024382100611251781583929172146215', 0)
INSERT INTO Account VALUES (N'Duy', N'Trường Hoàng Bảo Duy', '4229125024382100611251781583929172146215', 0)
INSERT INTO Account VALUES (N'Anh', N'Nguyễn Văn Hoàng Anh', '4229125024382100611251781583929172146215', 0)
INSERT INTO Account VALUES (N'Duong', N'Nguyễn Quốc Thái Dương', '4229125024382100611251781583929172146215', 0)
INSERT INTO Account VALUES (N'Den', N'Đen Vâu', '4229125024382100611251781583929172146215', 0)
INSERT INTO Account VALUES (N'Vu', N'Hoàng Thái Vũ', '4229125024382100611251781583929172146215', 0)
INSERT INTO Account VALUES (N'Tung', N'Sơn Tùng MTP', '4229125024382100611251781583929172146215', 0)
INSERT INTO Account VALUES (N'Dinh', N'Thái Đinh', '4229125024382100611251781583929172146215', 0)
INSERT INTO Account VALUES (N'Quynh', N'Phan Mạnh Quỳnh', '4229125024382100611251781583929172146215', 0)
INSERT INTO Account VALUES (N'Linh', N'Bùi Trường Linh', '4229125024382100611251781583929172146215', 0)



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


SELECT * FROM Account
SELECT * FROM Bill
SELECT * FROM BillInfo
SELECT * FROM Food
SELECT * FROM FoodCategory
SELECT * FROM TableFood