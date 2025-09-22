create database kb;

use kb;

-- drop database kb;

show databases;

CREATE TABLE Person (
    name VARCHAR(30),
    age INT
);

insert into Person (name, age) values ('user1',20);
-- insert into Person (age,name) values (20,'user1');
insert into Person values ('user2',21);
insert into Person (name) values ('user4');

UPDATE Person 
SET 
    age = 25
WHERE
    age < 25;
UPDATE Person 
SET 
    age = 22
WHERE
    age IS NULL;

SELECT 
    *
FROM
    Person;
SELECT 
    name
FROM
    Person;
SELECT 
    *
FROM
    Person
LIMIT 2;
SELECT 
    *
FROM
    Person
WHERE
    age > 20
ORDER BY name DESC;

DELETE FROM Person;

