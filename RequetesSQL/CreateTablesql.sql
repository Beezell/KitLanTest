CREATE TABLE users(
	id INT PRIMARY KEY IDENTITY(1,1),
	username VARCHAR(50),
	password VARCHAR(50)
);

INSERT INTO users(username,password) values ('Yoyo','123')