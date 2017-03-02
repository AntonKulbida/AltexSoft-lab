use DB_BOOKS

CREATE TABLE cat (
   id int NOT NULL,
   PRIMARY KEY (id)
	);
INSERT INTO cat VALUES (1),(2),(3),(4),(5);


CREATE TABLE news (
   id int NOT NULL,
   name varchar(45) DEFAULT NULL,
   PRIMARY KEY (id)
	);
INSERT INTO news VALUES (6,'6y'),(7,'7u'),(8,'8i'),(9,'9o'),(10,'10p');


CREATE TABLE news_cat (
   news_id int NOT NULL,
   cat_id int NOT NULL
);
INSERT INTO news_cat VALUES (6,1),(6,2),(7,3),(8,4),(10,5);


select n.*, count(*) AS h
	from news_cat AS newcat
		left join cat AS c ON c.id = newcat.cat_id
		left join news AS n ON n.id = newcat.news_id
	where newcat.cat_id <> 5	
	 group by newcat.news_id
		having h <> 2