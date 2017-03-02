using System;
using System.Data.SqlClient;

namespace AdoNetConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            string connectionString = @"Data Source=(local); Initial Catalog = Northwind;Integrated Security=true";
            string sqlExpression1 = @"SELECT Products.ProductName, SUM(Od.Quantity) AS 'Sum' FROM [Order Details] Od
				                        INNER JOIN Products ON Products.ProductID = Od.ProductID
				                    	WHERE Od.Quantity > 10
					                      GROUP BY Products.ProductName
					                      ORDER BY 'Sum' DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression1, connection);
                var reader1 = command.ExecuteReader();
                Output(reader1);

            }
            Console.Read();
        }

        public static void Output(SqlDataReader reader)
        {
            while (reader.Read())
            {
                for (var i = 0; i < reader.FieldCount; i++)
                {
                    if (i == reader.FieldCount - 1)
                    {
                        Console.WriteLine(reader[i]); ;
                    }
                    else
                    {
                        Console.WriteLine("{0} | ", reader[i]);
                    }

                }
            }
        }
    }
}
//
//
//		SELECT Customers.ContactName, SUM(Od.Quantity) AS 'Sum' FROM [Order Details] Od
//			INNER JOIN Orders ON Orders.OrderID = Od.OrderID
//			INNER JOIN Customers ON Customers.CustomerID = Orders.CustomerID
//					WHERE Od.Quantity < 5
//					GROUP BY Customers.ContactName
//					ORDER BY 'Sum'
//
//		SELECT Customers.ContactName, SUM(Od.Quantity) AS 'Sum' FROM [Order Details] Od
//				INNER	JOIN Orders ON Orders.OrderID = Od.OrderID
//				INNER	JOIN Customers ON Customers.CustomerID = Orders.CustomerID
//					AND Customers.ContactName LIKE '%a%'
//						GROUP BY Customers.ContactName
//						ORDER BY 'Sum'
//
//
//			SELECT TOP 7 Products.ProductName,(Od.Quantity * Od.UnitPrice * (1 - Od.Discount))
//				 AS 'Sum total',Orders.OrderDate,Customers.ContactName
//					FROM [Order Details] Od
//					INNER JOIN Products ON Products.ProductID = Od.ProductID
//					INNER JOIN Orders ON Orders.OrderID = Od.OrderID
//					INNER JOIN Customers ON Customers.CustomerID = Orders.CustomerID
//						ORDER BY 'Sum total'
//
//				SUM( ROUND(Od.Quantity * Od.UnitPrice * (1 - Od.Discount), 2) ) AS 'Sum total'
//							FROM [Order Details] Od
//								INNER JOIN Products ON Products.ProductID = Od.ProductID
//								GROUP BY Products.ProductName
//									ORDER BY 'Sum total' DESC;
//
//				SELECT	Products.ProductName,
//					SUM(Od.Quantity) AS 'Total quantity'
//						FROM [Order Details] Od
//							INNER JOIN Products ON Products.ProductID = Od.ProductID
//							GROUP BY Products.ProductName
//								ORDER BY 'Total quantity' DESC
//
//		SELECT Products.ProductName,
//			SUM( ROUND(Od.Quantity * Od.UnitPrice * (1 - Od.Discount), 2) ) AS 'Sum total'
//					FROM [Order Details] Od
//					INNER JOIN Products ON Products.ProductID = Od.ProductID
//					INNER JOIN Orders ON Orders.OrderID = Od.OrderID AND YEAR(Orders.OrderDate) = 1997
//					GROUP BY Products.ProductName
//					ORDER BY 'Sum total' DESC;
//
//

