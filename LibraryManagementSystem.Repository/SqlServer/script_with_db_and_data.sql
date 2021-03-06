USE [master]
GO
/****** Object:  Database [LibraryManagementSystem]    Script Date: 10/24/2020 10:48:34 AM ******/
CREATE DATABASE [LibraryManagementSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LibraryManagementSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\LibraryManagementSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LibraryManagementSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\LibraryManagementSystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [LibraryManagementSystem] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LibraryManagementSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LibraryManagementSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LibraryManagementSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LibraryManagementSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LibraryManagementSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LibraryManagementSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [LibraryManagementSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LibraryManagementSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LibraryManagementSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LibraryManagementSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LibraryManagementSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LibraryManagementSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LibraryManagementSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LibraryManagementSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LibraryManagementSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LibraryManagementSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LibraryManagementSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LibraryManagementSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LibraryManagementSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LibraryManagementSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LibraryManagementSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LibraryManagementSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LibraryManagementSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LibraryManagementSystem] SET RECOVERY FULL 
GO
ALTER DATABASE [LibraryManagementSystem] SET  MULTI_USER 
GO
ALTER DATABASE [LibraryManagementSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LibraryManagementSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LibraryManagementSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LibraryManagementSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LibraryManagementSystem] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'LibraryManagementSystem', N'ON'
GO
ALTER DATABASE [LibraryManagementSystem] SET QUERY_STORE = OFF
GO
USE [LibraryManagementSystem]
GO
/****** Object:  Table [dbo].[Authors]    Script Date: 10/24/2020 10:48:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authors](
	[AuthorId] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Authors] PRIMARY KEY CLUSTERED 
(
	[AuthorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 10/24/2020 10:48:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[BookId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](200) NOT NULL,
	[AuthorId] [int] NOT NULL,
	[Description] [varchar](500) NULL,
	[PublishedYear] [int] NOT NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FavouriteBooks]    Script Date: 10/24/2020 10:48:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FavouriteBooks](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[BookId] [int] NOT NULL,
	[IsRead] [bit] NOT NULL,
 CONSTRAINT [PK_Favourites] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reviews]    Script Date: 10/24/2020 10:48:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reviews](
	[ReviewId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[BookId] [int] NOT NULL,
	[Review] [varchar](500) NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Reviews] PRIMARY KEY CLUSTERED 
(
	[ReviewId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 10/24/2020 10:48:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleType] [varchar](100) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 10/24/2020 10:48:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [varchar](100) NOT NULL,
	[UserName] [varchar](100) NOT NULL,
	[Password] [varchar](25) NOT NULL,
	[RoleId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[FavouriteBooks] ADD  CONSTRAINT [DF_Favourites_IsRead]  DEFAULT ((0)) FOR [IsRead]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Authors_Books] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Authors] ([AuthorId])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Authors_Books]
GO
ALTER TABLE [dbo].[FavouriteBooks]  WITH CHECK ADD  CONSTRAINT [FK_Books_Favourites] FOREIGN KEY([BookId])
REFERENCES [dbo].[Books] ([BookId])
GO
ALTER TABLE [dbo].[FavouriteBooks] CHECK CONSTRAINT [FK_Books_Favourites]
GO
ALTER TABLE [dbo].[FavouriteBooks]  WITH CHECK ADD  CONSTRAINT [FK_Users_Favourites] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[FavouriteBooks] CHECK CONSTRAINT [FK_Users_Favourites]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Books_Reviews] FOREIGN KEY([BookId])
REFERENCES [dbo].[Books] ([BookId])
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Books_Reviews]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Users_Reviews] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Users_Reviews]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Roles_Users] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Roles_Users]
GO
/****** Object:  StoredProcedure [dbo].[AddAuthor]    Script Date: 10/24/2020 10:48:35 AM ******/
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
/****** Object:  StoredProcedure [dbo].[AddNewBook]    Script Date: 10/24/2020 10:48:35 AM ******/
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
/****** Object:  StoredProcedure [dbo].[GetAllBooks]    Script Date: 10/24/2020 10:48:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllBooks]
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
		WHERE b.IsDeleted = 0
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllReviews]    Script Date: 10/24/2020 10:48:35 AM ******/
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
/****** Object:  StoredProcedure [dbo].[GetBookById]    Script Date: 10/24/2020 10:48:35 AM ******/
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
/****** Object:  StoredProcedure [dbo].[GetUserByValidatingCredential]    Script Date: 10/24/2020 10:48:35 AM ******/
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
/****** Object:  StoredProcedure [dbo].[MarkBookAsReadByUser]    Script Date: 10/24/2020 10:48:35 AM ******/
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
/****** Object:  StoredProcedure [dbo].[MarkBookAsUserFavourite]    Script Date: 10/24/2020 10:48:35 AM ******/
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
/****** Object:  StoredProcedure [dbo].[UpdateBookAsDeleted]    Script Date: 10/24/2020 10:48:35 AM ******/
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
/****** Object:  StoredProcedure [dbo].[UpdateBookDetails]    Script Date: 10/24/2020 10:48:35 AM ******/
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
/****** Object:  StoredProcedure [dbo].[WriteReview]    Script Date: 10/24/2020 10:48:35 AM ******/
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
USE [master]
GO
ALTER DATABASE [LibraryManagementSystem] SET  READ_WRITE 
GO
