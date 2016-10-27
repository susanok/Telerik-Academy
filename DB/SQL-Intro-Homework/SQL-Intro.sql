USE TelerikAcademy

--Write a SQL query to find all information about all departments (use "TelerikAcademy" database).
SELECT d.Name, e.FirstName + ' ' + e.LastName AS Manager
FROM Departments d, Employees e
WHERE d.ManagerID = e.EmployeeID

--Write a SQL query to find all department names.
SELECT d.Name AS 'Department Name'
FROM Departments d

--Write a SQL query to find the salary of each employee.
SELECT e.Salary AS 'Employee Salary'
FROM Employees e

--Write a SQL to find the full name of each employee.
SELECT e.FirstName + ' ' + e.LastName AS 'Employee Full Name'
FROM Employees e

--Write a SQL query to find the email addresses of each employee 
--(by his first and last name). Consider that the mail domain is telerik.com. 
--Emails should look like “John.Doe@telerik.com". The produced column should be named "Full Email Addresses".
SELECT e.FirstName + '.' + e.LastName + '@telerik.com' AS 'Full Email Adresses'
FROM Employees e

--Write a SQL query to find all different employee salaries.
SELECT DISTINCT e.Salary AS 'All Different Salaries'
FROM Employees e

--Write a SQL query to find all information about the employees whose job title is “Sales Representative“.
SELECT e.FirstName + ' ' + e.LastName AS Employee,
	e.JobTitle,
	m.FirstName + ' ' + m.LastName AS Manager,
	d.Name AS Department,
	a.AddressText AS Address,
	e.Salary,
	e.HireDate
FROM Employees e, Employees m, Addresses a, Departments d
WHERE e.JobTitle = 'Sales Representative'
	AND a.AddressID = e.AddressID
	AND e.ManagerID = m.EmployeeID
	AND d.DepartmentID = e.DepartmentID

--Write a SQL query to find the names of all employees whose first name starts with "SA".
SELECT e.FirstName + ' ' + e.LastName AS 'Employee Full Name'
FROM Employees e
WHERE e.FirstName LIKE 'SA%'

--Write a SQL query to find the names of all employees whose last name contains "ei".
SELECT e.FirstName + ' ' + e.LastName AS 'Employee Full Name'
FROM Employees e
WHERE e.LastName LIKE '%ei%'

--Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000].
SELECT e.Salary
FROM Employees e
WHERE e.Salary BETWEEN 20000 AND 30000

--Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600.
SELECT e.FirstName + ' ' + e.LastName AS 'Full Name', e.Salary
FROM Employees e
WHERE e.Salary IN (25000, 14000, 12500, 23600)

--Write a SQL query to find all employees that do not have manager.
SELECT e.FirstName + ' ' + e.LastName AS 'Full Name'
FROM Employees e
WHERE e.ManagerID IS NULL

--Write a SQL query to find all employees that have salary more than 50000.
-- Order them in decreasing order by salary.
SELECT e.FirstName + ' ' + e.LastName AS 'Full Name', e.Salary
FROM Employees e
WHERE e.Salary > 50000
ORDER BY e.Salary DESC

--Write a SQL query to find the top 5 best paid employees.
SELECT TOP(5) e.FirstName + ' ' + e.LastName AS 'Full Name', e.Salary
FROM Employees e
ORDER BY e.Salary DESC

--Write a SQL query to find all employees along with their address. Use inner join with ON clause.
SELECT e.FirstName + ' ' + e.LastName AS 'Full Name', a.AddressText
FROM Employees e 
  INNER JOIN Addresses a 
    ON e.AddressID = a.AddressID

--Write a SQL query to find all employees and their address. Use equijoins (conditions in the WHERE clause)
SELECT e.FirstName + ' ' + e.LastName AS 'Full Name', a.AddressText
FROM Employees e, Addresses a
WHERE e.AddressID = a.AddressID

--Write a SQL query to find all employees along with their manager.
SELECT e.FirstName + ' ' + e.LastName AS 'Employee',
		m.FirstName + ' ' + m.LastName AS 'Manager'
FROM Employees e
	INNER JOIN Employees m
		ON e.ManagerID = m.EmployeeID

--Write a SQL query to find all employees, along with their manager and their address.
--Join the 3 tables: Employees e, Employees m and Addresses a.
SELECT e.FirstName + ' ' + e.LastName AS 'Employee',
		a.AddressText AS 'Employee Address',
		m.FirstName + ' ' + m.LastName AS 'Manager'
FROM Employees e, Employees m, Addresses a
WHERE e.ManagerID = m.EmployeeID
	AND e.AddressID = a.AddressID

--Write a SQL query to find all departments and all town names as a single list. Use UNION.
SELECT t.Name AS 'Towns/Departments'
FROM Towns t
	UNION
SELECT d.Name AS 'Towns/Departments'
FROM Departments d

--Write a SQL query to find all the employees and the manager for each of them along with the
-- employees that do not have manager. Use right outer join. Rewrite the query to use left outer join.

--right
SELECT ISNULL(e.FirstName + ' ' + e.LastName, 'doesn''t have employees') AS Employee,
			m.FirstName + ' ' + m.LastName AS Manager
FROM Employees e
	RIGHT OUTER JOIN Employees m
		ON e.ManagerID = m.EmployeeID

--left
SELECT e.FirstName + ' ' + e.LastName AS Employee,
		ISNULL(m.FirstName + ' ' + m.LastName, 'doesn''t have manager') AS Manager
FROM Employees e
	LEFT JOIN Employees m
		ON e.ManagerID = m.EmployeeID

--Write a SQL query to find the names of all employees from the departments "Sales" and "Finance" 
--whose hire year is between 1995 and 2005.
SELECT e.FirstName + ' ' + e.LastName AS 'Full Name',
		e.HireDate,
		d.Name AS 'Department'
FROM Employees e, Departments d
WHERE e.DepartmentID = d.DepartmentID
	AND d.Name IN ('Sales', 'Finance')
	AND e.HireDate BETWEEN '1995/01/01' AND '2005/12/31'
	ORDER BY e.HireDate

