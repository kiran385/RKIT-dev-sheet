CREATE TABLE Customer (
    CustomerId INT PRIMARY KEY AUTO_INCREMENT,
    CustomerName VARCHAR(30) NOT NULL,
    CustomerEmail VARCHAR(30) UNIQUE,
    CustomerAge INT CHECK (CustomerAge >= 20)
);

alter table Customer alter column CustomerAge set default 20;

insert into Customer (CustomerName,CustomerEmail) values('C1','c1@gmail.com');
insert into Customer values(101,'C2','c2@gmail.com',22);
insert into Customer (CustomerName,CustomerEmail) values('C3','c3@gmail.com');
insert into Customer values(4,'C4','c4@gmail.com',22);
insert into Customer (CustomerName,CustomerEmail) values('D5','d5@yahoo.in');
insert into Customer values(5,'E1','e1@outlook.com',30);
insert into Customer values(6,'A1','a1@yahoo.com',50);
insert into Customer values(99,'A2','a2@yahoo.com',50);
insert into Customer values(199,'A2','a22@yahoo.com',50);
insert into Customer values(198,'A2','a222@yahoo.com',60);

SELECT 
    *
FROM
    Customer;

SELECT 
    *
FROM
    Customer
WHERE
    (CustomerName LIKE 'C_%'
        OR CustomerEmail LIKE '%.in')
        AND CustomerAge = 20;
        
SELECT 
    CustomerName AS Name, CustomerAge AS Age
FROM
    Customer
WHERE
    CustomerAge IN (20 , 21)
        OR CustomerAge BETWEEN 25 AND 30;

DELETE FROM Customer;
Drop table Customer;