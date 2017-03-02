
CREATE TABLE Purchases(
			Code_book smallint not NULL FOREIGN KEY references Books(Code_book),
			Date_order date,
			Code_delivery smallint  not NULL FOREIGN KEY references Deliveries(Code_delivery),
			Type_purchase char(15),
			Cost int,
			Amount char(10),
			Code_purchase smallint   not NULL PRIMARY KEY IDENTITY(1,1))

CREATE TABLE Books(Code_book smallint   not NULL PRIMARY KEY IDENTITY(1,1),
				Title_book char(20),
				Code_author int not NULL FOREIGN KEY references Authors(Code_authors),
				Pages smallint,
				Code_publish smallint)

CREATE TABLE Authors(Code_author int not NULL PRIMARY KEY IDENTITY(1,1),
				Name_author char(6),
				B_day date)

CREATE TABLE Deliveries(
				Code_delivery smallint   not NULL PRIMARY KEY IDENTITY(1,1),
				Name_delivery char(20),
				Name_company char(15),
				[Address] char(6),
				Phone int,
				INN int)

CREATE TABLE Publishing_house(Code_publish  smallint,
				Publish char(20),
				City char(10))
				
