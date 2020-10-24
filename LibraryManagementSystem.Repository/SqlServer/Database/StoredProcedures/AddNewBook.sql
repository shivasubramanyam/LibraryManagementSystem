USE [LibraryManagementSystem]
GO

/****** Object:  StoredProcedure [dbo].[AddNewBook]    Script Date: 10/24/2020 10:59:38 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddNewBook] 
	@Title VARCHAR(100), @Description VARCHAR(100), @AuthorName VARCHAR(100), @PublishedYear INT
AS
BEGIN
	DECLARE @AID INT;
	IF EXISTS (SELECT 1 FROM Authors WHERE FullName = @AuthorName)
		BEGIN
			SELECT TOP 1 @AID = AuthorId FROM Authors WHERE FullName = @AuthorName
		END
		ELSE
		BEGIN
			EXEC AddAuthor @AuthorName
			SELECT TOP 1 @AID = AuthorId FROM Authors WHERE FullName = @AuthorName
		END

	IF NOT EXISTS (SELECT 1 FROM Books WHERE Title = @Title AND AuthorId = @AID)
		BEGIN
			INSERT INTO 
			Books (Title, Description, AuthorId, PublishedYear, IsDeleted) 
			VALUES (@Title, @Description, @AID, @PublishedYear, 0)
		END
END
GO


