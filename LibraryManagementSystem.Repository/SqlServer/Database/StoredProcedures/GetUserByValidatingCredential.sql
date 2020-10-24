USE [LibraryManagementSystem]
GO

/****** Object:  StoredProcedure [dbo].[GetUserByValidatingCredential]    Script Date: 10/24/2020 11:01:06 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUserByValidatingCredential]
	@UserName VARCHAR(100), @Password VARCHAR(25)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		u.UserId,
		u.FullName,
		u.UserName,
		r.RoleType,
		u.IsActive
	FROM Users u
	JOIN Roles r ON u.RoleId = r.RoleId
	WHERE u.UserName = @UserName 
		AND u.Password = @Password
		AND u.IsActive = 1
		AND r.IsActive = 1
END
GO


