-- create database
create database practice_db;
use practice_db;


-- create departments table to store different departments
CREATE TABLE departments (
    department_id INT PRIMARY KEY,
    department_name VARCHAR(50)
);

INSERT INTO departments (department_id, department_name) VALUES
(1, 'IT'),
(2, 'HR'),
(3, 'Finance'),
(4, 'Marketing');


-- create employees table to store employees data
CREATE TABLE employees (
    employee_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    department_id INT,
    salary DECIMAL(10,2),
    hire_year YEAR,
    FOREIGN KEY (department_id) REFERENCES departments(department_id)
);

INSERT INTO employees (employee_id, first_name, last_name, department_id, salary, hire_year) VALUES
(101, 'Ajay', 'Patel', 1, 75000.00, '2019'),
(102, 'Ronak', 'Parmar', 2, 50000.00, '2021'),
(103, 'Rahul', 'Dave', 1, 85000.00, '2018'),
(104, 'Akshay', 'Patel', 3, 90000.00, '2020'),
(105, 'Jay', 'Shah', 4, 60000.00, '2023'),
(106, 'Vijay', 'Sharma', 1, 67000.00, '2017'),
(107, 'Harsh', 'Modi', 2, 55000.00, '2022');


-- create projects table to store different projects
CREATE TABLE projects (
    project_id INT PRIMARY KEY,
    project_name VARCHAR(100),
    start_date DATE,
    end_date DATE
);

INSERT INTO projects (project_id, project_name, start_date, end_date) VALUES
(201, 'Website Redesign', '2023-01-10', '2023-07-20'),
(202, 'Mobile App', '2024-05-01', '2024-12-31'),
(203, 'Payroll System', '2022-09-15', '2023-03-30'),
(204, 'Market Research', '2023-06-01', '2023-09-15');


-- create employee_projects table to store data of employees on projects
CREATE TABLE employee_projects (
    employee_id INT,
    project_id INT,
    assigned_date DATE,
    role VARCHAR(50),
    PRIMARY KEY (employee_id, project_id),
    FOREIGN KEY (employee_id) REFERENCES employees(employee_id),
    FOREIGN KEY (project_id) REFERENCES projects(project_id)
);

INSERT INTO employee_projects (employee_id, project_id, assigned_date, role) VALUES
(101, 201, '2023-01-15', 'Developer'),
(103, 201, '2023-01-20', 'Team Lead'),
(106, 202, '2024-05-05', 'Developer'),
(104, 203, '2022-09-20', 'Analyst'),
(102, 204, '2023-06-10', 'Coordinator'),
(105, 204, '2023-06-12', 'Marketing Specialist'),
(107, 202, '2024-06-01', 'Tester'),
(101, 202, '2024-05-10', 'Project Manager'),
(103, 202, '2024-05-15', 'Architect');


-- Question: List all employees working in the "IT" department.
-- Using subquery
SELECT 
    employee_id, first_name, last_name
FROM
    employees
WHERE
    department_id IN (SELECT 
            department_id
        FROM
            departments
        WHERE
            department_name = 'IT');

-- Using join
SELECT 
    employee_id, first_name, last_name
FROM
    employees
        JOIN
    departments ON employees.department_id = departments.department_id
WHERE
    departments.department_id = 1;


-- Question: Find departments where the average salary is more than 70,000.
-- Using subquery
SELECT 
    department_name
FROM
    departments
WHERE
    department_id IN (SELECT 
            department_id
        FROM
            employees
        GROUP BY department_id
        HAVING AVG(salary) > 75000);
       
-- Using join
SELECT 
    department_name
FROM
    departments
        JOIN
    employees ON departments.department_id = employees.department_id
GROUP BY employees.department_id
HAVING AVG(salary) > 75000;


-- Question: List all employees along with their department names, ordered by salary descending.
SELECT 
    employee_id,
    first_name,
    last_name,
    salary,
    d.department_name
FROM
    employees
        JOIN
    departments d ON employees.department_id = d.department_id
ORDER BY salary DESC;


-- Question: List employees who earn more than the average salary of all employees.
SELECT 
    employee_id, first_name, salary
FROM
    employees
WHERE
    salary > (SELECT 
            AVG(salary)
        FROM
            employees);


-- Question: List the names of employees along with the projects they are working on and their roles.
SELECT 
    e.employee_id,
    e.first_name,
    ep.project_id,
    p.project_name,
    ep.role
FROM
    employees e
        JOIN
    employee_projects ep ON e.employee_id = ep.employee_id
        JOIN
    projects p ON ep.project_id = p.project_id
ORDER BY e.employee_id;


-- Question: Find the names of departments where at least one employee is assigned to a project.
SELECT 
    department_name
FROM
    departments d
WHERE
    department_id IN (SELECT 
            department_id
        FROM
            employees e
        WHERE
            employee_id IN (SELECT 
                    employee_id
                FROM
                    employee_projects));


-- Question: Find the project name and number of employees working on each project, 
-- 			 but only include projects with more than 3 employees.
SELECT 
    project_name, COUNT(ep.employee_id)
FROM
    projects p
        JOIN
    employee_projects ep ON p.project_id = ep.project_id
GROUP BY ep.project_id
HAVING COUNT(ep.employee_id) > 3;


-- Question: List employees who joined before 2020 and are working on projects started before 2024.
SELECT 
    employee_id, first_name, hire_year
FROM
    employees e
WHERE
    hire_year < 2020
        AND employee_id IN (SELECT 
            employee_id
        FROM
            employee_projects ep
                JOIN
            projects p ON ep.project_id = p.project_id
        WHERE
            start_date < '2024-01-01');


-- Question: Find employees who earn more than their department’s average salary.
SELECT 
    e.employee_id,
    CONCAT(e.first_name, ' ', e.last_name) AS 'full_name',
    e.salary
FROM
    employees e
WHERE
    e.salary > (SELECT 
            AVG(salary)
        FROM
            employees
        WHERE
            department_id = e.department_id);


-- Question: Find departments where the average salary of employees is above 60,000. 
-- 			 For each such department, list the department name, number of employees, 
-- 			 and average salary. Order the results by average salary descending.
SELECT 
    department_name,
    COUNT(e.employee_id) AS 'no_of_employees',
    AVG(e.salary) AS 'avg_dept_salary'
FROM
    departments d
        JOIN
    employees e ON d.department_id = e.department_id
GROUP BY e.department_id
HAVING AVG(e.salary) > 60000
ORDER BY AVG(salary) DESC;


-- Question: List the project names along with the total number of employees working on 
-- 			 each project where the project has more than 1 employees assigned. 
-- 			 Also, include the average salary of those employees. 
-- 			 Order the result by the number of employees descending.
SELECT 
    project_name,
    COUNT(e.employee_id) AS 'no_of_employees',
    AVG(e.salary) AS 'avg_salary'
FROM
    projects p
        JOIN
    employee_projects ep ON p.project_id = ep.project_id
        JOIN
    employees e ON ep.employee_id = e.employee_id
GROUP BY ep.project_id
HAVING COUNT(e.employee_id) > 1
ORDER BY COUNT(e.employee_id) DESC;


-- Question: For each department, show the department name, total number of unique employees 
-- 			 assigned to any project, and average salary of those employees. 
-- 			 Only include departments where more than 1 employees are assigned to projects. 
-- 			 Order by average salary descending
SELECT 
    department_name,
    COUNT(DISTINCT (ep.employee_id)) AS 'no_of_employees',
    AVG(DISTINCT (e.salary)) AS 'avg_salary'
FROM
    departments d
        JOIN
    employees e ON d.department_id = e.department_id
        JOIN
    employee_projects ep ON e.employee_id = ep.employee_id
GROUP BY d.department_name
HAVING COUNT(ep.employee_id) > 1
ORDER BY AVG(DISTINCT (e.salary)) DESC;