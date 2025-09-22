SELECT 
    COUNT(*) AS total_student
FROM
    student;


SELECT 
    COUNT(gpa)
FROM
    student;


SELECT 
    SUM(gpa)
FROM
    student;


SELECT 
    AVG(gpa)
FROM
    student;


SELECT 
    MIN(name)
FROM
    student;


SELECT 
    MAX(gpa)
FROM
    student;


SELECT 
    GROUP_CONCAT(name
        SEPARATOR '-')
FROM
    student;