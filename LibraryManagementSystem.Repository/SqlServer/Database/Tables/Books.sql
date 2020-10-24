USE [LibraryManagementSystem]
GO

/****** Object:  Table [dbo].[Books]    Script Date: 10/24/2020 10:53:49 AM ******/
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

ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Authors_Books] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Authors] ([AuthorId])
GO

ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Authors_Books]
GO


