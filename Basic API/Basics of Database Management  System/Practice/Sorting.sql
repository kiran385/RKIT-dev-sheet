CREATE TABLE student (
    id INT PRIMARY KEY,
    name VARCHAR(30) NOT NULL,
    admission_year YEAR DEFAULT 2020,
    cgpa FLOAT NOT NULL
);

insert into student values (1,'S1',2020,8.2);
insert into student values (2,'S2',2020,8.5);
insert into student values (3,'S3',2020,9.2);
insert into student values (4,'S4',2020,7.5);

SELECT 
    *
FROM
    student;

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


DELETE FROM student;