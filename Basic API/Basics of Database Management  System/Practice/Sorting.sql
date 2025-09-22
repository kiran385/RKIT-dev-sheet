CREATE TABLE student (
    id INT,
    name VARCHAR(30),
    gpa FLOAT
);

insert into student values (1,'S1',8.2);
insert into student values (2,'S2',8.7);
insert into student values (3,'S3',9.1);
insert into student values (4,'S4',7.5);
insert into student values (5,'S5',9.3);
insert into student values (6,'S6',6.9);
insert into student values (7,'S7',9.5);
insert into student values (8,'S8',8.7);
insert into student values (9,'S9',8.8);
insert into student values (10,'S10',8.3);
insert into student values (11,'S11',NULL);
insert into student values (NULL,NULL,NULL);

SELECT 
    *
FROM
    student
ORDER BY gpa DESC
LIMIT 5;

SELECT 
    *
FROM
    student
ORDER BY gpa DESC
LIMIT 2 OFFSET 3;


DELETE FROM student 
WHERE
    name IS NULL;