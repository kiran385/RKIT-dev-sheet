CREATE TABLE Orders (
    OrderId INT PRIMARY KEY,
    OrderName VARCHAR(30),
    CustomerId INT
);

insert into orders values(1,'PR1',4);
insert into orders values(2,'PR2',2);
insert into orders values(3,'PR3',1);
insert into orders values(4,'PR4',6);
insert into orders values(5,'PR5',3);

SELECT 
    *
FROM
    orders;

CREATE TABLE Dealer (
    ProductId INT PRIMARY KEY,
    OrderId INT
);

insert into dealer values(101,10);
insert into dealer values(102,5);
insert into dealer values(103,1);
insert into dealer values(104,6);
insert into dealer values(105,2);

SELECT 
    *
FROM
    dealer;


-- Inner join
SELECT 
    Customer.CustomerId, Customer.CustomerName, Orders.OrderName
FROM
    customer
        JOIN
    orders ON customer.CustomerId = orders.CustomerId;
    

-- Left join
SELECT 
    Customer.CustomerId, Customer.CustomerName, Orders.OrderName
FROM
    customer
        LEFT JOIN
    orders ON customer.CustomerId = orders.CustomerId;
    
    
-- Right join
SELECT 
    Customer.CustomerId, Customer.CustomerName, Orders.OrderName
FROM
    customer
        RIGHT JOIN
    orders ON customer.CustomerId = orders.CustomerId;
    
    
-- Full join
SELECT 
    Customer.CustomerId, Customer.CustomerName, Orders.OrderName
FROM
    customer
        LEFT JOIN
    orders ON customer.CustomerId = orders.CustomerId 
UNION SELECT 
    Customer.CustomerId, Customer.CustomerName, Orders.OrderName
FROM
    customer
        RIGHT JOIN
    orders ON customer.CustomerId = orders.CustomerId;
    
    
-- Cross join
SELECT 
    Customer.CustomerId, Customer.CustomerName, Orders.OrderName
FROM
    Customer
        CROSS JOIN
    Orders;
    

-- Multiple join
SELECT 
    Customer.CustomerId,
    Customer.CustomerName,
    Orders.OrderId,
    Orders.OrderName,
    Dealer.ProductId
FROM
    customer
        JOIN
    orders ON customer.CustomerId = orders.CustomerId
        JOIN
    dealer ON orders.OrderId = dealer.OrderId;