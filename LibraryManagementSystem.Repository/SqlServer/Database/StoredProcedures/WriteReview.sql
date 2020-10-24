USE [LibraryManagementSystem]
GO

/****** Object:  StoredProcedure [dbo].[WriteReview]    Script Date: 10/24/2020 11:03:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[WriteReview]
	@UserId INT, @BookId INT, @Review VARCHAR(500), @CreatedDateTime DATETIME
AS
BEGIN
	IF EXISTS(SELECT 1 from Books where BookId = @BookId AND IsDeleted = 0)
		BEGIN
			IF NOT EXISTS(SELECT 1 FROM Reviews WHERE UserId = @UserId AND BookId = @BookId)
				BEGIN
					INSERT INTO Reviews (UserId, BookId, Review, CreatedDateTime) 
					VALUES (@UserId, @BookId, @Review, @CreatedDateTime) 
				END
		END	
END
GO


