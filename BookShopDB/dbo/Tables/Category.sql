CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [nvarchar](50) NOT NULL,
	[FriendlyUrl] [nvarchar](50) NOT NULL,
	[ParentCategoryId] [int] NULL,
	[Order] [nvarchar](20) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) 
GO
ALTER TABLE [dbo].[Category]  ADD  CONSTRAINT [FK_Category_Category] FOREIGN KEY([ParentCategoryId])
REFERENCES [dbo].[Category] ([Id])
GO

ALTER TABLE [dbo].[Category] CHECK CONSTRAINT [FK_Category_Category]