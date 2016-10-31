USE TelerikAcademy

--1.Write a SQL query to find the names and salaries of the employees that take 
--the minimal salary in the company.
--Use a nested SELECT statement.

SELECT e.FirstName + ' ' + e.LastName AS 'Full Name', Salary
FROM Employees e
WHERE Salary = (SELECT MIN(Salary) FROM Employees)


--2.Write a SQL query to find the names and salaries of the employees that have a salary 
--that is up to 10% higher than the minimal salary for the company.

SELECT e.FirstName + ' ' + e.LastName AS 'Full Name', Salary
FROM Employees e
WHERE Salary < (SELECT MIN(Salary) * 1.1 FROM Employees)


--3.Write a SQL query to find the full name, salary and department of the employees that take 
--the minimal salary in their department.
--Use a nested SELECT statement.

SELECT e.FirstName + ' ' + e.LastName AS 'Full Name',
		 d.Name AS 'Department',
		  e.Salary
FROM Employees e, Departments d
WHERE Salary = (SELECT MIN(Salary) FROM Employees empl
   WHERE empl.DepartmentID = d.DepartmentID)
ORDER BY d.DepartmentID


--4.Write a SQL query to find the average salary in the department #1.

SELECT AVG(Salary) AS 'Average Salary'
FROM Employees
WHERE DepartmentID = 1


--5.Write a SQL query to find the average salary in the "Sales" department.

SELECT AVG(e.Salary) AS 'Average Salary'
FROM Employees e, Departments d
WHERE e.DepartmentID = d.DepartmentID AND d.Name = 'Sales'


--6.Write a SQL query to find the number of employees in the "Sales" department.

SELECT COUNT(e.FirstName) AS 'Count of Employees'
FROM Employees e, Departments d
WHERE e.DepartmentID = d.DepartmentID AND d.Name = 'Sales'

--7.Write a SQL query to find the number of all employees that have manager.

SELECT COUNT(*) 'Count of Employees'
FROM Employees e
WHERE e.ManagerID IS NOT NULL


--8.Write a SQL query to find the number of all employees that have no manager.

SELECT COUNT(*) 'Count of Employees'
FROM Employees e
WHERE e.ManagerID IS NULL


--9.Write a SQL query to find all departments and the average salary for each of them.

SELECT AVG(e.Salary) AS 'Average Salary',
	 d.Name AS Department
FROM Employees e, Departments d
WHERE  e.DepartmentID = d.DepartmentID
GROUP BY  d.Name

--10.Write a SQL query to find the count of all employees in each department and for each town.

SELECT COUNT(*) 'Count of Employees',
	 d.Name AS Department,
	  t.Name AS Town
FROM Employees e, Departments d, Addresses a, Towns t
WHERE  e.DepartmentID = d.DepartmentID
	AND e.AddressID = a.AddressID
	AND a.TownID = t.TownID
GROUP BY t.Name, d.Name


--11.Write a SQL query to find all managers that have exactly 5 employees.
-- Display their first name and last name.

SELECT m.FirstName, m.LastName
FROM Employees e, Employees m
WHERE e.ManagerID = m.EmployeeID
GROUP BY m.FirstName, m.LastName
HAVING COUNT(*) = 5


--12.Write a SQL query to find all employees along with their managers. 
--For employees that do not have manager display the value "(no manager)".
SELECT e.FirstName + ' ' + e.LastName AS 'Employee',
	 ISNULL(m.FirstName + ' ' + m.LastName, ('(no manager)')) AS 'Manager'
FROM Employees e
LEFT OUTER JOIN Employees m
ON e.ManagerID = m.EmployeeID