SELECT 
    *
FROM
    Customer
WHERE
    CustomerAge > 25;

create index idx_age on customer(customerAge);

drop index idx_age on customer;

show indexes from customer;
