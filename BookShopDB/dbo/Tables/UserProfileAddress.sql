CREATE TABLE [dbo].[UserProfileAddress](
	[UserProfileId] [int] NOT NULL,
	[AddressId] [int] NOT NULL,
	[Type] [int] NOT NULL,
	[IsDefault] [bit] NOT NULL,	
 CONSTRAINT [PK_UserProfileAddress] PRIMARY KEY CLUSTERED 
(
	[UserProfileId] ASC,
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)
GO
ALTER TABLE [dbo].[UserProfileAddress]  ADD  CONSTRAINT [FK_UserProfileAddress_Address] FOREIGN KEY([AddressID])
REFERENCES [dbo].[Address] ([ID])
GO

ALTER TABLE [dbo].[UserProfileAddress] CHECK CONSTRAINT [FK_UserProfileAddress_Address]
GO
ALTER TABLE [dbo].[UserProfileAddress]  ADD  CONSTRAINT [FK_UserProfileAddress_UserProfile] FOREIGN KEY([UserProfileID])
REFERENCES [dbo].[UserProfile] ([ID])
GO

ALTER TABLE [dbo].[UserProfileAddress] CHECK CONSTRAINT [FK_UserProfileAddress_UserProfile]
GO
ALTER TABLE [dbo].[UserProfileAddress] ADD  CONSTRAINT [DF_UserProfileAddress_IsDefault]  DEFAULT ((0)) FOR [IsDefault]