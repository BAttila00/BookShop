CREATE TABLE [dbo].[ProductAuthor](
	[ProductId] [int] NOT NULL,
	[AuthorId] [int] NOT NULL,
 CONSTRAINT [PK_ProductAuthor] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC,
	[AuthorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)
GO
ALTER TABLE [dbo].[ProductAuthor]  ADD  CONSTRAINT [FK_ProductAuthor_Author] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Author] ([Id])
GO

ALTER TABLE [dbo].[ProductAuthor] CHECK CONSTRAINT [FK_ProductAuthor_Author]
GO
ALTER TABLE [dbo].[ProductAuthor]  ADD  CONSTRAINT [FK_ProductAuthor_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO

ALTER TABLE [dbo].[ProductAuthor] CHECK CONSTRAINT [FK_ProductAuthor_Product]