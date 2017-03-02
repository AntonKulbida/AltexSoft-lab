use Northwind;

Select * from Products;

CREATE VIEW Products1
        AS SELECT * 
        FROM Products
        WHERE UnitPrice > = 10;


/*
CREATE VIEW Custumers1
      AS SELECT City, COUNT (DISTINCT CustomerID)
         FROM Customers
         GROUP BY City;
/*
CREATE VIEW Custumers1
      AS SELECT City, COUNT (DISTINCT CustomerID)
         FROM Customers
         GROUP BY City;

		 */
		 */
Select * from Employees
Select * from EmployeeTerritories
Select * from Products

CREATE VIEW Employees11
      AS SELECT EmployeeID, AVG (Categories), SUM (Categories) 
         FROM Customers, Orders 
         WHERE Customers.CustomerID = Orders.CustomerID
         GROUP BY EmployeeID; 
