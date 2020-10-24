USE [LibraryManagementSystem]
GO

/****** Object:  Table [dbo].[FavouriteBooks]    Script Date: 10/24/2020 10:54:12 AM ******/
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

ALTER TABLE [dbo].[FavouriteBooks] ADD  CONSTRAINT [DF_Favourites_IsRead]  DEFAULT ((0)) FOR [IsRead]
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


