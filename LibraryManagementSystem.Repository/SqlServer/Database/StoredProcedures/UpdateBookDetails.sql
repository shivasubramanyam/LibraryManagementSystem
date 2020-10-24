USE [LibraryManagementSystem]
GO

/****** Object:  StoredProcedure [dbo].[UpdateBookDetails]    Script Date: 10/24/2020 11:02:51 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateBookDetails] 
	-- Add the parameters for the stored procedure here
	@BookId INT, @Title VARCHAR(100), @Description VARCHAR(100), @AuthorName VARCHAR(100), @PublishedYear INT
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
	UPDATE Books 
	SET AuthorId = @AID,
		Title = @Title,
		Description = @Description,
		PublishedYear = @PublishedYear
	WHERE BookId = @BookId
END
GO


