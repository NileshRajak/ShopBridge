--Create Database ShopBridgeDB

--use ShopBridgeDB

--Create Table tblShopBridgeDetails
--(
--	Id int identity(1,1) primary key,
--	Name Varchar(50) Not null,
--	Description Varchar(500) Not null,
--	Price decimal(10, 2) Not Null,
--	IsActive varchar(10) Not Null,
--	CreatedDate datetime Not Null,
--	ModifiedDate datetime 
--)

--Select *from tblShopBridgeDetails

--ALTER PROCEDURE SP_ShopBridge @Task VARCHAR(50) = NULL
--	,@Id INT = NULL
--	,@Name VARCHAR(50) = NULL
--	,@Description VARCHAR(500) = NULL
--	,@Price DECIMAL(10, 2) = NULL
--AS
--BEGIN
--	IF (@Task = 'Get')
--	BEGIN
--		SELECT Id
--			,Name
--			,Description
--			,Price
--		FROM tblShopBridgeDetails
--		WHERE IsActive = 'Y'
--	END
--	ELSE IF (@Task = 'GetById')
--	BEGIN
--		SELECT Id
--			,Name
--			,Description
--			,Price
--		FROM tblShopBridgeDetails
--		WHERE Id = @Id
--			AND IsActive = 'Y'
--	END
--	ELSE IF (@Task = 'Insert')
--	BEGIN
--		IF EXISTS (
--				SELECT *
--				FROM tblShopBridgeDetails
--				WHERE Name = @Name
--					AND IsActive = 'Y'
--				)
--		BEGIN
--			BEGIN TRAN

--			BEGIN TRY
--				INSERT INTO tblShopBridgeDetails
--				VALUES (
--					@Name
--					,@Description
--					,@Price
--					,'Y'
--					,GETDATE()
--					,NULL
--					)

--				COMMIT

--				SELECT 1;--Record inserted seccessfully
--			END TRY

--			BEGIN CATCH
--				ROLLBACK

--				SELECT 0;--Record Not Inserted due to some error
--			END CATCH
--		END
--		ELSE
--		BEGIN
--			SELECT 2;--Duplicate records can not be allow to insert
--		END
--	END
--	ELSE IF (@Task = 'Update')
--	BEGIN
--		IF EXISTS (
--				SELECT *
--				FROM tblShopBridgeDetails
--				WHERE Id = @Id
--				)
--		BEGIN
--			BEGIN TRAN

--			BEGIN TRY
--				UPDATE tblShopBridgeDetails
--				SET Name = @Name
--					,Description = @Description
--					,Price = @Price
--					,ModifiedDate = getdate()
--				WHERE Id = @Id

--				COMMIT;

--				SELECT 1;--Record is updated
--			END TRY

--			BEGIN CATCH
--				ROLLBACK;

--				SELECT 0;--Record is not update 
--			END CATCH
--		END
--		ELSE
--		BEGIN
--			SELECT 2;---Record is not available for update
--		END
--	END
--	ELSE IF (@Task = 'Delete')
--	BEGIN
--		IF EXISTS (
--				SELECT *
--				FROM tblShopBridgeDetails
--				WHERE Id = @Id And IsActive='Y'
--				)
--		BEGIN
--			BEGIN TRAN

--			BEGIN TRY
--				UPDATE tblShopBridgeDetails
--				SET ModifiedDate = getdate()
--					,IsActive = 'N'
--				WHERE Id = @Id

--				COMMIT;

--				SELECT 1;--Deleted successfully
--			END TRY

--			BEGIN CATCH
--				ROLLBACK;

--				SELECT 0;--record is not deleted due to some error
--			END CATCH
--		END
--		ELSE
--		BEGIN
--			SELECT 2;--Record is not available for delete
--		END
--	END
--END




--INSERT INTO tblShopBridgeDetails
--			VALUES (
--				'Apple'
--				,'Fruit'
--				,'100'
--				,'Y'
--				,GETDATE()
--				,NULL
--				)



--Create Table tblErrorLog
--(
--	Id Int identity(1,1) primary key,
--	Message Varchar(500) ,
--	Stacktrace Varchar(500),
--	Source Varchar(500),
--	Target Varchar(500),
--	LogDate Datetime
--)


--CREATE PROCEDURE SP_ErrorLog @Message VARCHAR(500)
--	,@Stacktrace VARCHAR(500)
--	,@Source VARCHAR(500)
--	,@Target VARCHAR(500)
--AS
--BEGIN
--	INSERT INTO ErrorLog
--	VALUES (
--		@Message
--		,@Stacktrace
--		,@Source
--		,@Target
--		,GETDATE()
--		)
--END


select * from tblShopBridgeDetails