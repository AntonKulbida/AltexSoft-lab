USE [BooksShop]
GO

CREATE NONCLUSTERED INDEX IDX_Authors_NameAuthor
ON dbo.Authors(NameAuthor)


USE [BooksShop]
GO

CREATE NONCLUSTERED INDEX IDX_PublishingHouses_Publish
ON dbo.PublishingHouses(Publish)


USE [BooksShop]
GO

CREATE NONCLUSTERED INDEX IDX_Purchases_DateOrder
ON dbo.Purchases(DateOrder)


USE [BooksShop]
GO

CREATE NONCLUSTERED INDEX IDX_Authors_FullAuthorInfo
ON dbo.Authors(NameAuthor, Birthday)