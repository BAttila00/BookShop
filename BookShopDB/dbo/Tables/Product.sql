CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[FriendlyUrl] [nvarchar](100) NULL,
	[CategoryID] [int] NOT NULL,
	[PublisherID] [int] NOT NULL,
	[Subtitle] [nvarchar](100) NOT NULL,
	[CoverUrl] [nvarchar](100) NOT NULL,
	[ShortDescription] [nvarchar](max) NOT NULL,
	[Price] [int] NOT NULL,
	[DiscountPrice] [int] NULL,
	[PublishYear] [int] NOT NULL,
	[PageNumber] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[SumRating] [int] NOT NULL,
	[RatingCount] [int] NOT NULL,	
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)
GO
ALTER TABLE [dbo].[Product]  ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([ID])
GO

ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
ALTER TABLE [dbo].[Product]  ADD  CONSTRAINT [FK_Product_Publisher] FOREIGN KEY([PublisherID])
REFERENCES [dbo].[Publisher] ([ID])
GO

ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Publisher]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_SumRating]  DEFAULT ((0)) FOR [SumRating]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_RatingCount]  DEFAULT ((0)) FOR [RatingCount]