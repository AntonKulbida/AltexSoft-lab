USE [BooksShop]
GO

/****** Object:  Index [PK_dbo.Authors]    Script Date: 19.01.2017 15:19:42 ******/
ALTER TABLE [dbo].[Authors] ADD  CONSTRAINT [PK_dbo.Authors] PRIMARY KEY CLUSTERED 
(
	[CodeAuthor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO


USE [BooksShop]
GO

/****** Object:  Index [PK_dbo.Books]    Script Date: 19.01.2017 15:21:30 ******/
ALTER TABLE [dbo].[Books] ADD  CONSTRAINT [PK_dbo.Books] PRIMARY KEY CLUSTERED 
(
	[CodeBook] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO


USE [BooksShop]
GO

/****** Object:  Index [PK_dbo.Deliveries]    Script Date: 19.01.2017 15:22:47 ******/
ALTER TABLE [dbo].[Deliveries] ADD  CONSTRAINT [PK_dbo.Deliveries] PRIMARY KEY CLUSTERED 
(
	[CodeDelivery] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO

USE [BooksShop]
GO

/****** Object:  Index [PK_dbo.PublishingHouses]    Script Date: 19.01.2017 15:23:40 ******/
ALTER TABLE [dbo].[PublishingHouses] ADD  CONSTRAINT [PK_dbo.PublishingHouses] PRIMARY KEY CLUSTERED 
(
	[CodePublish] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO


USE [BooksShop]
GO

/****** Object:  Index [PK_dbo.Purchases]    Script Date: 19.01.2017 15:24:02 ******/
ALTER TABLE [dbo].[Purchases] ADD  CONSTRAINT [PK_dbo.Purchases] PRIMARY KEY CLUSTERED 
(
	[CodePurchase] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO