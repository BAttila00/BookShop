CREATE TABLE [dbo].[Comment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[UserProfileID] [int] NOT NULL,
	[Text] [nvarchar](max) NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[Type] [int] NOT NULL,	
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)
GO
ALTER TABLE [dbo].[Comment]  ADD  CONSTRAINT [FK_Comment_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ID])
GO

ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_Product]
GO
ALTER TABLE [dbo].[Comment]  ADD  CONSTRAINT [FK_Comment_UserProfile] FOREIGN KEY([UserProfileID])
REFERENCES [dbo].[UserProfile] ([ID])
GO

ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_UserProfile]
GO
ALTER TABLE [dbo].[Comment] ADD  CONSTRAINT [DF_Comment_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]