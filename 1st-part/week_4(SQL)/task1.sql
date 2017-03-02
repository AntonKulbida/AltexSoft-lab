CREATE DATABASE DB_TASK1
GO

use Week4_Db

--CREATE TABLE S(n_post char(5) not NULL,
--				name char(20),
--				reiting smallint,
--				town char(15))
--
--CREATE TABLE P(n_det char(6),
--				name char(20),
--				cvet char(7),
--				ves smallint,
--				town char(15))
--
--CREATE TABLE SP(n_post char(5),
--				n_det char(6),
--				post_date date,
--				kol smallint)
GO

INSERT INTO S (n_post, name, reiting, town) 
	VALUES 
		('S1', 'Смит', 20, 'Лондон'), 
		('S2', 'Джонс', 10, 'Париж'), 
		('S3', 'Блейк', 30, 'Париж'), 
		('S4', 'Кларк', 20, 'Лондон'), 
		('S5', 'Адамс', 30, 'Атенс')
GO

INSERT INTO P(n_det, name, cvet, ves,town)
	VALUES
		('P1', 'Гайка', 'Красный', 12, 'Лондон'),
		('P2', 'Болт', 'Зеленый', 17, 'Париж'),
		('P3', 'Винт', 'Голубой', 17, 'Рим'),
		('P4', 'Винт', 'Красный', 14, 'Лондон'),
		('P5', 'Кулачок', 'Голубой', 12, 'Париж'),
		('P6', 'Блюм', 'Красный', 19, 'Лондон')
GO

INSERT INTO SP(n_post, n_det, post_date, kol)
	VALUES
		('S1', 'P1', '02/01/95', 300),
		('S1', 'P2', '04/05/95', 200),
		('S1', 'P3', '05/12/95', 400),
		('S1', 'P4', '06/15/95', 200),
		('S1', 'P5', '07/22/95', 100),
		('S1', 'P6', '08/13/95', 100),
		('S2', 'P1', '03/03/95', 300),
		('S2', 'P2', '06/12/95', 400),
		('S3', 'P2', '04/04/95', 200),
		('S4', 'P2', '03/23/95', 200),
		('S4', 'P4', '06/17/95', 300),
		('S4', 'P5', '08/22/95', 400)
GO

SELECT * FROM S

SELECT name AS 'Surname', town AS 'Town', reiting AS 'Rating', n_post AS '# Provider' FROM S

SELECT n_det AS '# Component' FROM SP


SELECT DISTINCT n_det AS '# Component' FROM SP;

SELECT SUBSTRING(name, 1, 2) AS 'Surname', reiting AS 'Rating' FROM S;

SELECT * FROM S
	ORDER BY town, reiting

SELECT * FROM P
	WHERE name LIKE 'Б%'

SELECT CAST(AVG(CAST(kol AS DECIMAL(5,2))) AS DECIMAL(5,2)) AS 'Avg', MIN(kol) AS 'Min', MAX(kol) AS 'Max', n_post AS '# Deliver' FROM SP
WHERE n_post = 'S1'
GROUP BY n_post

SELECT n_det AS '# Component', kol AS 'Amount',
	DAY (post_date) AS 'Day',
	MONTH (post_date) AS 'Month',
	DATEPART (weekday, post_date) AS 'Day of the week',
	DATEDIFF (day, post_date, GETDATE()) AS 'Days passed'
	FROM SP;

SELECT S.n_post AS '# Provider',
	S.name AS 'Provider Name',
	S.reiting AS 'Rating',
	S.town AS 'Provider town',
	P.n_det AS '# Component',
	P.name AS 'Component title',
	P.cvet AS 'Colour',
	P.ves AS 'Weight',
	P.town AS 'Componet town'
FROM S, P WHERE S.town = P.town

SELECT n_det AS '# Component', SUM(kol) AS 'Total amount of deliveries' FROM SP
WHERE n_post <> 'S1'
GROUP BY n_det

SELECT n_det AS '# Component' FROM P
	WHERE ves > 16
UNION SELECT n_det FROM SP
	WHERE n_post = 'S2'

DELETE SP FROM SP INNER JOIN S ON SP.n_post = S.n_post
WHERE S.town = 'Лондон'

SELECT SP.*, S.town as 'Deliver town' FROM SP INNER JOIN S ON SP.n_post = S.n_post


