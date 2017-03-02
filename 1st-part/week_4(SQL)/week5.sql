/* [18]. Написать скрипт на выборку всех записей о количестве
 * продаж каждого товара, где количество> 10. (Детализация – товар, количество).
 * Результат отсортирован по сумме, обратная сортировка. */
	SELECT Products.ProductName,
			 SUM(Od.Quantity) AS 'Sum' FROM [Order Details] Od
								JOIN Products ON Products.ProductID = Od.ProductID
								WHERE Od.Quantity > 10
								GROUP BY Products.ProductName
								ORDER BY 'Sum' DESC

/* [19]. Написать скрипт на выборку всех записей о количестве покупок сделанных каждым покупателем,
 * где количество< 5. (Детализация – покупатель, количество).
 * Результат отсортирован по сумме, прямая сортировка. */
	SELECT Customers.ContactName, 
			SUM(Od.Quantity) AS 'Sum' FROM [Order Details] Od
								JOIN Orders ON Orders.OrderID = Od.OrderID
								JOIN Customers ON Customers.CustomerID = Orders.CustomerID
								WHERE Od.Quantity < 5
								GROUP BY Customers.ContactName
								ORDER BY 'Sum'

/* [20]. Написать скрипт на выборку количества записей о покупках сделанных каждым покупателями,
 * в имени которых присутствует хотя бы одна буква “a”. (Детализация – покупатель, количество).
 * Результат отсортирован по сумме, прямая сортировка.*/
	SELECT Customers.ContactName, 
			SUM(Od.Quantity) AS 'Sum' FROM [Order Details] Od
							JOIN Orders ON Orders.OrderID = Od.OrderID
							JOIN Customers ON Customers.CustomerID = Orders.CustomerID
								AND Customers.ContactName LIKE '%a%'
							GROUP BY Customers.ContactName
							ORDER BY 'Sum';

/* [21]. Создать представление на выборку записей о продажах, сделанных до 1997 года.
 * (Детализация – какой товар, количество, цена продажи, дата продажи).
 * Результат отсортирован по цене, обратная сортировка.*/
			SELECT Products.ProductName, Od.Quantity,
					ROUND(Od.Quantity * Od.UnitPrice * (1 - Od.Discount), 2) AS 'Sum total', Orders.OrderDate
						FROM [Order Details] Od
						JOIN Products ON Products.ProductID = Od.ProductID
						JOIN Orders ON Orders.OrderID = Od.OrderID;

			

/* [22]. Создать представление на выборку первых 7 записей о
 * продажах. (Детализация – какой товар, сумма, дата продажи, покупатель). Результат отсортирован
 * по цене, прямая сортировка. Исходный текст представления зашифрован.*/
		SELECT TOP 7 Products.ProductName, (Od.Quantity * Od.UnitPrice * (1 - Od.Discount)) 
				AS 'Sum total', .OrderDate, Customers.ContactName
							FROM [Order Details] Od
							JOIN Products ON Products.ProductID = Od.ProductID
							JOIN Orders ON Orders.OrderID = Od.OrderID
							JOIN Customers ON Customers.CustomerID = Orders.CustomerID;

/* [23]. Создать представление на выборку всех записей о
 * суммарных продажах каждого товара. (Детализация – какой товар, сумма). Результат отсортирован
 * по сумме, обратная сортировка */
			SELECT Products.ProductName,
					SUM( ROUND(Od.Quantity * Od.UnitPrice * (1 - Od.Discount), 2) ) AS 'Sum total'
							FROM [Order Details] Od
							JOIN Products ON Products.ProductID = Od.ProductID
							GROUP BY Products.ProductName;


/* [24]. Создать представление на выборку всех записей о
 * количестве продаж каждого товара. (Детализация – товар, количество). Результат отсортирован по
 * сумме, обратная сортировка. Исходный текст представления зашифрован.*/
		SELECT Products.ProductName,
					SUM(Od.Quantity) AS 'Total quantity'
					FROM [Order Details] Od
					JOIN Products ON Products.ProductID = Od.ProductID
					GROUP BY Products.ProductName;

/* [25]. Создать представление на выборку всех записей о
 * суммарных продажах каждого товара за 1997 год. (Детализация – какой товар, сумма). Результат
 * отсортирован по сумме, обратная сортировка.*/
		 SELECT Products.ProductName,
				SUM( ROUND(Od.Quantity * Od.UnitPrice * (1 - Od.Discount), 2) ) AS 'Sum total'
						FROM [Order Details] Od
						JOIN Products ON Products.ProductID = Od.ProductID
						JOIN Orders ON Orders.OrderID = Od.OrderID AND YEAR(Orders.OrderDate) = 1997
						GROUP BY Products.ProductName;
