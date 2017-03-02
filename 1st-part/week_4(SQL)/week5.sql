/* [18]. �������� ������ �� ������� ���� ������� � ����������
 * ������ ������� ������, ��� ����������> 10. (����������� � �����, ����������).
 * ��������� ������������ �� �����, �������� ����������. */
	SELECT Products.ProductName,
			 SUM(Od.Quantity) AS 'Sum' FROM [Order Details] Od
								JOIN Products ON Products.ProductID = Od.ProductID
								WHERE Od.Quantity > 10
								GROUP BY Products.ProductName
								ORDER BY 'Sum' DESC

/* [19]. �������� ������ �� ������� ���� ������� � ���������� ������� ��������� ������ �����������,
 * ��� ����������< 5. (����������� � ����������, ����������).
 * ��������� ������������ �� �����, ������ ����������. */
	SELECT Customers.ContactName, 
			SUM(Od.Quantity) AS 'Sum' FROM [Order Details] Od
								JOIN Orders ON Orders.OrderID = Od.OrderID
								JOIN Customers ON Customers.CustomerID = Orders.CustomerID
								WHERE Od.Quantity < 5
								GROUP BY Customers.ContactName
								ORDER BY 'Sum'

/* [20]. �������� ������ �� ������� ���������� ������� � �������� ��������� ������ ������������,
 * � ����� ������� ������������ ���� �� ���� ����� �a�. (����������� � ����������, ����������).
 * ��������� ������������ �� �����, ������ ����������.*/
	SELECT Customers.ContactName, 
			SUM(Od.Quantity) AS 'Sum' FROM [Order Details] Od
							JOIN Orders ON Orders.OrderID = Od.OrderID
							JOIN Customers ON Customers.CustomerID = Orders.CustomerID
								AND Customers.ContactName LIKE '%a%'
							GROUP BY Customers.ContactName
							ORDER BY 'Sum';

/* [21]. ������� ������������� �� ������� ������� � ��������, ��������� �� 1997 ����.
 * (����������� � ����� �����, ����������, ���� �������, ���� �������).
 * ��������� ������������ �� ����, �������� ����������.*/
			SELECT Products.ProductName, Od.Quantity,
					ROUND(Od.Quantity * Od.UnitPrice * (1 - Od.Discount), 2) AS 'Sum total', Orders.OrderDate
						FROM [Order Details] Od
						JOIN Products ON Products.ProductID = Od.ProductID
						JOIN Orders ON Orders.OrderID = Od.OrderID;

			

/* [22]. ������� ������������� �� ������� ������ 7 ������� �
 * ��������. (����������� � ����� �����, �����, ���� �������, ����������). ��������� ������������
 * �� ����, ������ ����������. �������� ����� ������������� ����������.*/
		SELECT TOP 7 Products.ProductName, (Od.Quantity * Od.UnitPrice * (1 - Od.Discount)) 
				AS 'Sum total', .OrderDate, Customers.ContactName
							FROM [Order Details] Od
							JOIN Products ON Products.ProductID = Od.ProductID
							JOIN Orders ON Orders.OrderID = Od.OrderID
							JOIN Customers ON Customers.CustomerID = Orders.CustomerID;

/* [23]. ������� ������������� �� ������� ���� ������� �
 * ��������� �������� ������� ������. (����������� � ����� �����, �����). ��������� ������������
 * �� �����, �������� ���������� */
			SELECT Products.ProductName,
					SUM( ROUND(Od.Quantity * Od.UnitPrice * (1 - Od.Discount), 2) ) AS 'Sum total'
							FROM [Order Details] Od
							JOIN Products ON Products.ProductID = Od.ProductID
							GROUP BY Products.ProductName;


/* [24]. ������� ������������� �� ������� ���� ������� �
 * ���������� ������ ������� ������. (����������� � �����, ����������). ��������� ������������ ��
 * �����, �������� ����������. �������� ����� ������������� ����������.*/
		SELECT Products.ProductName,
					SUM(Od.Quantity) AS 'Total quantity'
					FROM [Order Details] Od
					JOIN Products ON Products.ProductID = Od.ProductID
					GROUP BY Products.ProductName;

/* [25]. ������� ������������� �� ������� ���� ������� �
 * ��������� �������� ������� ������ �� 1997 ���. (����������� � ����� �����, �����). ���������
 * ������������ �� �����, �������� ����������.*/
		 SELECT Products.ProductName,
				SUM( ROUND(Od.Quantity * Od.UnitPrice * (1 - Od.Discount), 2) ) AS 'Sum total'
						FROM [Order Details] Od
						JOIN Products ON Products.ProductID = Od.ProductID
						JOIN Orders ON Orders.OrderID = Od.OrderID AND YEAR(Orders.OrderDate) = 1997
						GROUP BY Products.ProductName;
