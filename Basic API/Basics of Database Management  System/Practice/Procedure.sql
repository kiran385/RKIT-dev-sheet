delimiter $$

create procedure pr_getCustomers()
begin
	SELECT 
		*
	FROM
		customer;
end $$

delimiter ;

call pr_getCustomers();

drop procedure if exists pr_getCustomers;


delimiter $$

create procedure pr_getCustomerCount(out count int)
begin
	SELECT 
    COUNT(*) AS count
FROM
    customer;
end $$

delimiter ;

call pr_getCustomerCount(@total);

drop procedure if exists pr_getCustomerCount;