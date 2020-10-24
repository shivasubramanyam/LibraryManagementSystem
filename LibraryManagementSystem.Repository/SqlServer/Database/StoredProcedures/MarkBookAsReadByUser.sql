USE [LibraryManagementSystem]
GO

/****** Object:  StoredProcedure [dbo].[MarkBookAsReadByUser]    Script Date: 10/24/2020 11:01:27 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[MarkBookAsReadByUser]
	@UserId INT, @BookId INT
AS
BEGIN
	IF EXISTS(SELECT 1 FROM FavouriteBooks WHERE UserId = @UserId AND BookId = @BookId)
		BEGIN
			UPDATE FavouriteBooks
			SET IsRead = 1
			WHERE UserId = @UserId AND BookId = @BookId
		END
END
GO


