-- create new database 
create database bank;
use bank;


-- customer table for customer data
CREATE TABLE customer (
    customer_id INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(50) NOT NULL,
    email VARCHAR(30) UNIQUE,
    phone_no VARCHAR(10) NOT NULL,
    city VARCHAR(30)
);

insert into customer(name,email,phone_no,city) values 
('Ajay','ajay@gmail.com','9999999999','Rajkot'),
('Rahul','rahul@gmail.com','888888888','Ahemdabad'),
('Harsh','harsh@gmail.com','777777777','Rajkot'),
('Jay','jay@gmail.com','6666666666','Gandhinagar'),
('Het','het@gmail.com','9898989898','Ahemdabad');

SELECT 
    *
FROM
    customer;


-- account table for account information
CREATE TABLE account (
    account_id INT PRIMARY KEY AUTO_INCREMENT,
    customer_id INT,
    balance DECIMAL(15 , 2 ) NOT NULL DEFAULT 0.00,
    status ENUM('active', 'closed') NOT NULL DEFAULT 'active',
    FOREIGN KEY (customer_id)
        REFERENCES customer (customer_id)
);

insert into account(customer_id,balance,status) values
(2,50000,'active'),
(3,30000,'active'),
(1,0,'closed'),
(2,45000,'active'),
(4,15000,'active');

SELECT 
    *
FROM
    account;


-- transaction table to store transaction data
CREATE TABLE transaction (
    transaction_id INT PRIMARY KEY AUTO_INCREMENT,
    account_id INT,
    amount DECIMAL(15 , 2 ) NOT NULL,
    type ENUM('credit', 'debit') NOT NULL,
    status ENUM('success', 'failed') NOT NULL,
    transfer_id VARCHAR(30) NOT NULL,
    FOREIGN KEY (account_id)
        REFERENCES account (account_id)
);

SELECT 
    *
FROM
    transaction;


-- log table to store transaction logs
CREATE TABLE log (
    message VARCHAR(100),
    dt DATETIME
);

SELECT 
    *
FROM
    log;


-- view for customer details
DROP VIEW IF EXISTS vws_customer_detail;
CREATE VIEW vws_customer_detail AS
    SELECT 
        c.customer_id,
        c.name,
        c.email,
        c.phone_no,
        c.city,
        COUNT(*) AS total_account,
        SUM(balance) AS total_balance
    FROM
        customer c
            LEFT JOIN
        account a ON c.customer_id = a.customer_id
    GROUP BY customer_id;

SELECT
    *
FROM
    vws_customer_detail;


-- view for accounts detail
DROP VIEW IF EXISTS vws_account_detail;
CREATE VIEW vws_account_detail AS
    SELECT 
        a.account_id, c.customer_id, c.name, a.balance, a.status
    FROM
        customer c
            RIGHT JOIN
        account a ON c.customer_id = a.customer_id;

SELECT 
    *
FROM
    vws_account_detail;


-- Function for active accounts
delimiter $$

drop function if exists fn_active_account;
create function fn_active_account()
returns int
deterministic
begin
	declare count int;
SELECT 
    COUNT(*)
INTO count FROM
    account
WHERE
    status = 'active';
    return count;
end $$

delimiter ;

SELECT FN_ACTIVE_ACCOUNT() AS active_accounts;


-- trigger for log new account
delimiter $$

drop trigger if exists trg_new_account;
create trigger trg_new_account
after insert on account
for each row
begin
	insert into log(message,dt) values (concat('New account is created with account id ',NEW.account_id),now());
end $$

delimiter ;

insert into account(customer_id,balance,status) values (5,12000,'active');


-- procedure for transaction
delimiter $$

drop procedure if exists pr_transaction;
create procedure pr_transaction(in from_account int, in to_account int, in transfer_amount int)
begin
	declare available_amount int;
    declare error_message varchar(50);
    declare trans_id varchar(30);
    
    declare exit handler for sqlexception
    begin
		rollback;
        insert into transaction (account_id,amount,type,status,transfer_id) 
		values (from_account,transfer_amount,'debit','failed',trans_id);
        
        insert into log (message,dt)
        values (concat('Transaction failed with transfer id ',trans_id,' due to ',ifnull(error_message, 'an unknown error')), NOW());
    end;
    
    start transaction;
    
    SET trans_id = DATE_FORMAT(NOW(), '%Y%m%d%H%i%s%f');
SELECT 
    balance
INTO available_amount FROM
    account
WHERE
    account_id = from_account
FOR UPDATE;
    
    if(select status from account where account_id = from_account) != 'active'
    then set error_message = 'Sender account is not active';
    signal sqlstate '45000' set message_text = error_message;
    
    elseif (select status from account where account_id = to_account) != 'active'
    then set error_message = 'Receiver account is not active';
    signal sqlstate '45000' set message_text = error_message;
    
    elseif available_amount < transfer_amount
    then set error_message = 'Insufficient balance';
    signal sqlstate '45000' set message_text = error_message;
    
    end if;
    
UPDATE account 
SET 
    balance = balance - transfer_amount
WHERE
    account_id = from_account;
    insert into transaction (account_id,amount,type,status,transfer_id) 
    values (from_account,transfer_amount,'debit','success',trans_id);
    
UPDATE account 
SET 
    balance = balance + transfer_amount
WHERE
    account_id = to_account;
    insert into transaction (account_id,amount,type,status,transfer_id) 
    values (to_account,transfer_amount,'credit','success',trans_id);
    
    insert into log (message,dt)
        values (concat('Transaction successful with transfer id ',trans_id), NOW());
    
    commit;
end $$

delimiter ;

call pr_transaction(2,100,1000);


-- procedure for deposit
delimiter $$

drop procedure if exists pr_deposit;
create procedure pr_deposit(in to_account int,in transfer_amount int)
begin
	declare error_message varchar(50);
    
    declare exit handler for sqlexception
    begin
		rollback;
		insert into transaction (account_id,amount,type,status,transfer_id) 
		values (to_account,transfer_amount,'credit','failed','cash');
    end;
    
    start transaction;
    
    if (select status from account where account_id = to_account) != 'active' 
    then set error_message = 'Account is not active';
    signal sqlstate '45000' set message_text = error_message;
    
    end if;
    
    update account set balance = balance + transfer_amount where account_id = to_account;
    insert into transaction (account_id,amount,type,status,transfer_id) 
    values (to_account,transfer_amount,'credit','success','cash');
    
    commit;
    
end $$

delimiter ;

call pr_deposit(1,1000);


-- procedure for withdraw
delimiter $$

drop procedure if exists pr_withdraw;
create procedure pr_withdraw(in from_account int,in transfer_amount int)
begin
	declare error_message varchar(50);
    
    declare exit handler for sqlexception
    begin
		rollback;
        insert into transaction (account_id,amount,type,status,transfer_id) 
		values (from_account,transfer_amount,'debit','failed','cash');
    end;
    
    start transaction;
    
	if (select status from account where account_id = from_account) != 'active'
    then set error_message = 'Account is not active';
    signal sqlstate '45000' set message_text = error_message;
    
    elseif (select balance from account where account_id = from_account) < transfer_amount
    then set error_message = 'Insufficient balance';
    signal sqlstate '45000' set message_text = error_message;
    
    end if;
    
    update account set balance = balance - transfer_amount where account_id = from_account;
    insert into transaction (account_id,amount,type,status,transfer_id) 
    values (from_account,transfer_amount,'debit','success','cash');
    
    commit;
end $$

delimiter ;

call pr_withdraw(1,1000);


-- DCL commands 
drop user if exists 'user123'@'localhost';
create user 'user123'@'localhost' identified by 'user123';
grant select on vws_account_detail to 'user123'@'localhost';
grant select on vws_customer_detail to 'user123'@'localhost';
revoke select on vws_account_detail from 'user123'@'localhost';
revoke select on vws_customer_detail from 'user123'@'localhost';