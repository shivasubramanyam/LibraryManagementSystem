USE [LibraryManagementSystem]
GO

/****** Object:  StoredProcedure [dbo].[GetBookById]    Script Date: 10/24/2020 11:00:43 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetBookById]
	@BookId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT b.BookId,
		 b.Title,
		 b.Description,
		 a.FullName AS Author,
		 b.PublishedYear
	 from Books b WITH (NOLOCK)
	 JOIN Authors a
		ON a.AuthorId = b.AuthorId
		WHERE b.BookId = @BookId
		AND b.IsDeleted = 0
END
GO


