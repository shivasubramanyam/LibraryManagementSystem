USE [LibraryManagementSystem]
GO

/****** Object:  StoredProcedure [dbo].[GetAllReviews]    Script Date: 10/24/2020 11:00:25 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllReviews]
	@BookId INT
AS
BEGIN
	SELECT 
		r.ReviewId,
		b.Title,
		a.FullName AS Author,
		u.FullName AS ReviewBy,
		r.Review,
		r.CreatedDateTime
	FROM dbo.Reviews r
	JOIN Users u ON u.UserId = r.UserId
	JOIN Books b ON b.BookId = r.BookId
	JOIN Authors a ON a.AuthorId = b.AuthorId
	WHERE b.BookId = @BookId
		AND u.IsActive = 1
		AND b.IsDeleted = 0
END
GO


