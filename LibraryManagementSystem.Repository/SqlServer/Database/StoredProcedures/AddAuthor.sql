USE [LibraryManagementSystem]
GO

/****** Object:  StoredProcedure [dbo].[AddAuthor]    Script Date: 10/24/2020 10:59:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddAuthor]
	@AuthorFullName VARCHAR(100)
AS
BEGIN
	INSERT INTO Authors (FullName) VALUES (@AuthorFullName)
END
GO


