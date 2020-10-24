USE [LibraryManagementSystem]
GO

/****** Object:  StoredProcedure [dbo].[MarkBookAsUserFavourite]    Script Date: 10/24/2020 11:01:47 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[MarkBookAsUserFavourite]
	@UserId INT, @BookId INT
AS
BEGIN
	IF EXISTS(SELECT 1 FROM Books WHERE BookId = @BookId)
		BEGIN
			IF EXISTS(SELECT 1 FROM Users WHERE UserId = @UserId)
				BEGIN
					INSERT INTO FavouriteBooks (UserId, BookId) VALUES (@UserId, @BookId)					
				END
		END
END
GO


