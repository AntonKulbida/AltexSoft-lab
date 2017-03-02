use [DfLessonDb]

select * from dbo.someinfo;
/*
DECLARE @iterator int = 1;
DECLARE @sql nvarchar(1000);
DECLARE @tab AS TABLE (t1 int);

WHILE (SELECT COL_NAME(OBJECT_ID ('dbo.someinfo'), @iterator)) is not NULL

BEGIN
set @sql = N'select top(1) row from (select ROW_NUMBER() over(order by(SELECT NULL)) as row_number,'
+ (SELECT COL_NAME(OBJECT_ID('dbo.someinfo'), @iterator)) + ' as row from dbo.someinfo) as result where row_number = ' + cast(@iterator as nvarchar(1000));
insert into @tab exec sp_executesql @sql;
set @iterator = @iterator+1;
END
select SUM(t1) from @tab
*/

DECLARE @iterator int = 1;
DECLARE @sql nvarchar(1000);
DECLARE @tab AS TABLE (t1 float);
DECLARE @VAL float;
DECLARE @CURSOR CURSOR;
DECLARE @RESULT float = 1;

WHILE (SELECT COL_NAME(OBJECT_ID ('dbo.someinfo'), @iterator)) is not NULL
	BEGIN 
		IF @iterator % 2 = 0
		set @sql = N'select ' + (SELECT COL_NAME(OBJECT_ID('dbo.someinfo'),@iterator)) + ' from dbo.someinfo';
		set @iterator = @iterator+1;
		insert into @tab exec sp_executesql @sql;
	END

	SET @CURSOR = CURSOR SCROLL
	FOR
		select * from @tab
	OPEN @CURSOR
		FETCH NEXT FROM @CURSOR INTO @VAL
	WHILE @@FETCH_STATUS = 0
	BEGIN
		SET @RESULT = @RESULT * @VAL 
	FETCH NEXT FROM @CURSOR INTO @VAL
END
CLOSE @CURSOR

print @RESULT