USE [DB_BOOKS]
GO

SELECT [id] ,[CPU], [memory]
  FROM [dbo].[TABLE-PC] WHERE [Memory] >= 3000
GO

SELECT [id], [hdd] 
	FROM [dbo].[TABLE-PC] WHERE [hdd]<= 500
GO

Select count (*) 
	from [dbo].[TABLE-PC] 
	where [hdd] <= 500;


select [hdd], count([hdd]) as count from [dbo].[TABLE-PC] 
  where [hdd] = (select min([hdd]) from [dbo].[TABLE-PC] )
  group by [hdd];