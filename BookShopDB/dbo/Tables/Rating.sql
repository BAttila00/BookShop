CREATE TABLE [dbo].[Rating](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Value] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[UserProfileId] [int] NOT NULL,
 CONSTRAINT [PK_Rating] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)
GO
ALTER TABLE [dbo].[Rating] ADD CONSTRAINT [FK_Rating_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO

ALTER TABLE [dbo].[Rating] CHECK CONSTRAINT [FK_Rating_Product]
GO
ALTER TABLE [dbo].[Rating]  ADD CONSTRAINT [FK_Rating_UserProfile] FOREIGN KEY([UserProfileID])
REFERENCES [dbo].[UserProfile] ([ID])
GO

ALTER TABLE [dbo].[Rating] CHECK CONSTRAINT [FK_Rating_UserProfile]