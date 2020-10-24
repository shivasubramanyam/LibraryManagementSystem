USE [LibraryManagementSystem]
GO

/****** Object:  StoredProcedure [dbo].[UpdateBookAsDeleted]    Script Date: 10/24/2020 11:02:33 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateBookAsDeleted] 
	@BookId INT
AS
BEGIN
	IF EXISTS(SELECT 1 FROM Books WHERE BookId = @BookId AND IsDeleted = 0)
		BEGIN
			UPDATE Books
			SET IsDeleted = 1
			WHERE BookId = @BookId
		END
END
GO


