-- DDL Commands

CREATE TABLE employee (
    id INT,
    name VARCHAR(30),
    salary FLOAT
);

alter table employee add department int;
alter table employee modify department varchar(30);
alter table employee change department dept varchar(30);
alter table employee drop column dept;

drop table employee;

truncate employee;


-- DML Commands

insert into employee values (1,'E1',10000);
insert into employee values (2,'E2',20000),(3,'E3',22000);

UPDATE employee 
SET 
    salary = 15000
WHERE
    id = 1;

DELETE FROM employee 
WHERE
    salary < 20000;


-- DQL Command

SELECT 
    *
FROM
    employee;

SELECT 
    name AS employeeName
FROM
    employee
WHERE
    salary > 20000;


-- DCL Commands

CREATE USER 'user123'@'localhost' IDENTIFIED BY 'user123';

grant select on kb.employee to 'user123'@'localhost';

revoke select on kb.employee from 'user123'@'localhost';

DROP USER if exists 'user123'@'localhost';


-- TCL Commands

start transaction;

insert into employee values (100,'E100',10000,'Ahmedabad',202);

savepoint before_update;

UPDATE employee 
SET 
    salary = 50000
WHERE
    id = 100;

rollback to before_update;

commit;

select * from employee;