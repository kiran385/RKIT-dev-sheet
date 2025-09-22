SELECT 
    Customer.CustomerId, Customer.CustomerName
FROM
    customer
WHERE
    Customer.CustomerId IN (SELECT 
            CustomerId
        FROM
            orders);
            

SELECT 
    Customer.CustomerId, Customer.CustomerName
FROM
    customer
WHERE
    Customer.CustomerId IN (SELECT 
            CustomerId
        FROM
            orders
        WHERE
            orders.OrderId IN (SELECT 
                    OrderId
                FROM
                    dealer));


-- CTE(Common Table Execution)
WITH seniorCustomer AS (
    SELECT 
        CustomerName, CustomerAge
    FROM
        Customer
    WHERE
        CustomerAge > 20
)
SELECT 
    *
FROM
    seniorCustomer;

with avgSalary as (
SELECT 
    AVG(salary) AS avg_salary
FROM
    employee
)
UPDATE employee
        JOIN
    avgSalary 
SET 
    salary = avgSalary.avg_salary
WHERE
    salary < avgSalary.avg_salary;


-- Temporary table
create temporary table seniorCust as 
SELECT 
    CustomerName, CustomerAge
FROM
    customer
WHERE
    CustomerAge > 20;

SELECT 
    *
FROM
    seniorCust;


-- CASE statement
SELECT 
    CustomerName,
    CustomerAge,
    CASE
        WHEN CustomerAge > 45 THEN 'Senior citizen'
        WHEN CustomerAge BETWEEN 20 AND 45 THEN 'Responsible citizen'
        ELSE 'Child citizen'
    END AS CitizenCategory
FROM
    Customer;
