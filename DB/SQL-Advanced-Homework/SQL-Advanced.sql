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

--13.Write a SQL query to find the names of all employees whose last name is exactly
-- 5 characters long. Use the built-in LEN(str) function.

SELECT e.FirstName, e.LastName
FROM Employees e
WHERE LEN(e.LastName) = 5

--14.Write a SQL query to display the current date and time in the following format
-- "day.month.year hour:minutes:seconds:milliseconds".

SELECT CONVERT(VARCHAR, GETDATE(), 104) + ' ' + CONVERT(VARCHAR, GETDATE(), 114)

--15.Write a SQL statement to create a table Users. Users should have username, password, 
--full name and last login time.
--Choose appropriate data types for the table fields. Define a primary key column with a primary key constraint.
--Define the primary key column as identity to facilitate inserting records.
--Define unique constraint to avoid repeating usernames.
--Define a check constraint to ensure the password is at least 5 characters long.

CREATE TABLE Users (
  UserID int IDENTITY PRIMARY KEY,
  UserName nvarchar(100) NOT NULL UNIQUE,
  FullName nvarchar(100) NOT NULL,
  [Password] nvarchar(50) NOT NULL,
  LastLoginTime smalldatetime NOT NULL,
  CONSTRAINT [Password] CHECK (LEN([Password]) >= 5)
)

GO

--16.Write a SQL statement to create a view that displays the users from the Users 
--table that have been in the system today.
--Test if the view works correctly.

CREATE VIEW [Users Today] AS
SELECT  u.UserName
FROM Users u
WHERE CONVERT(DATE, u.LastLoginTime) = CONVERT(DATE, GETDATE())

GO

--17.Write a SQL statement to create a table Groups. Groups should have unique name (use unique constraint).
--Define primary key and identity column.

CREATE TABLE Groups (
  GroupID int IDENTITY PRIMARY KEY,
  Name nvarchar(100) NOT NULL UNIQUE,
)

GO

--18.Write a SQL statement to add a column GroupID to the table Users.
--Fill some data in this new column and as well in the `Groups table.
--Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.

--Add GroupId column in the Users table

ALTER TABLE Users 
ADD GroupID INT
GO

--Add foreign key

ALTER TABLE Users
ADD CONSTRAINT FK_Users_Groups
  FOREIGN KEY (GroupID)
  REFERENCES Groups(GroupID)

GO

--19.Write SQL statements to insert several records in the Users and Groups tables.

INSERT INTO Groups VALUES
('first group'),
('second group'),
('third group'),
('fourth group')

GO

INSERT INTO Users VALUES
('goshko', 'georgi petrov', 'goshkopass', GETDATE(), 1),
('peshko', 'pesho goshev', 'peshkopass', GETDATE(), 2),
('sashko', 'sasho sashev', 'sashkopass', GETDATE(), 3),
('mitko', 'mitko mitev', 'mitkopass', GETDATE(), 4)

GO

--20.Write SQL statements to update some of the records in the Users and Groups tables.

UPDATE Users
SET UserName = 'myNewUsername'
WHERE UserID = 1

UPDATE Groups
SET Name = 'Second'
WHERE GroupID = 2

GO

--21.Write SQL statements to delete some of the records from the Users and Groups tables.

DELETE FROM Users
 WHERE UserID = 3

DELETE FROM Groups 
WHERE Name = 'third group'

GO

--22.Write SQL statements to insert in the Users table the names of all employees from the Employees table.
--Combine the first and last names as a full name.
--For username use the first letter of the first name + the last name (in lowercase).
--Use the same for the password, and NULL for last login time.

INSERT INTO Users
([FullName], [UserName], [Password], [LastLoginTime])
SELECT e.FirstName + e.LastName,
		SUBSTRING(e.FirstName, 1, 1) + LOWER(e.LastName) + CONVERT(varchar, e.HireDate),
		SUBSTRING(e.FirstName, 1, 1) + LOWER(e.LastName) + 'minLen',
		GETDATE()
FROM Employees e
GO

--23.Write a SQL statement that changes the password to NULL for all
-- users that have not been in the system since 10.03.2010.

ALTER TABLE Users
ALTER COLUMN [Password] NVARCHAR(100) NULL
GO

UPDATE Users
SET [Password] = NULL
WHERE DATEDIFF(DAY, LastLoginTime, '03.10.2010 00:00:00:000') > 0
GO

--24.Write a SQL statement that deletes all users without passwords (NULL password).

DELETE FROM Users
WHERE [Password] IS NULL
GO

--25.Write a SQL query to display the average employee salary by department and job title.

SELECT AVG(Salary) AS 'Average Salary',
		d.Name AS 'Department',
		e.JobTitle AS 'Job Title'
FROM Employees e
	JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle

--26.Write a SQL query to display the minimal employee salary by department and job
-- title along with the name of some of the employees that take it.

SELECT e.FirstName AS 'First Name',
		e.LastName AS 'Last Name',
		MIN(Salary) AS 'Minimal Salary',
		d.Name AS 'Department',
		e.JobTitle AS 'Job Title'
FROM Employees e
	JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle, e.FirstName, e.LastName

--27.Write a SQL query to display the town where maximal number of employees work.

SELECT TOP 1 t.Name AS 'Town',
		 COUNT(*) AS 'Count of Employees'
FROM Employees e
	JOIN Addresses a
		ON e.AddressID = a.AddressID
	JOIN Towns t
		ON a.TownID = t.TownID
GROUP BY t.Name
ORDER BY 'Count of Employees' DESC

--28.Write a SQL query to display the number of managers from each town.

SELECT t.Name AS 'Town',
		 COUNT(DISTINCT e.ManagerID) AS 'Count of Managers'
FROM Employees e
	JOIN Addresses a
		ON e.AddressID = a.AddressID
	JOIN Towns t
		ON a.TownID = t.TownID
GROUP BY t.Name
ORDER BY 'Count of Managers' DESC

--29.Write a SQL to create table WorkHours to store work reports for each employee 
--(employee id, date, task, hours, comments).
--Don't forget to define identity, primary key and appropriate foreign key.
--Issue few SQL statements to insert, update and delete of some data in the table.
--Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers.
--For each change keep the old record data, the new record data and the command (insert / update / delete).

CREATE TABLE WorkHours (
	ID INT IDENTITY PRIMARY KEY,
	EmployeeID INT NOT NULL,
	[Date] SMALLDATETIME,
	Task NVARCHAR(100),
	[Hours] INT,
	Comments NVARCHAR(300),
	CONSTRAINT FK_WorkHours_Employees
		FOREIGN KEY (EmployeeID)
		REFERENCES Employees(EmployeeID)
)

GO

INSERT INTO WorkHours VALUES
(1, GETDATE(), 'First Task', 2, 'hard task'),
(2, GETDATE(), 'Second Task', 4, 'very hard task'),
(3, GETDATE(), 'Third Task', 6, NULL)
GO

UPDATE WorkHours
SET [Hours] = 5
WHERE EmployeeID = 1
GO

DELETE FROM WorkHours
WHERE EmployeeID = 3
GO

CREATE TABLE WorkHoursLogs (
	ID INT IDENTITY PRIMARY KEY,
	EmployeeID INT NOT NULL,
	[Date] SMALLDATETIME,
	Task NVARCHAR(100),
	[Hours] INT,
	Comments NVARCHAR(300),
	Change VARCHAR(30)
)
GO

CREATE TRIGGER trg_WorkHours_Insert ON WorkHours
FOR INSERT 
AS
	INSERT INTO WorkHoursLogs(EmployeeID, [Date], Task, [Hours], Comments, Change)
	SELECT EmployeeId, [Date], Task, [Hours], Comments, 'INSERT'
	FROM INSERTED
GO

CREATE TRIGGER trg_WorkHours_Delete ON WorkHours
FOR DELETE 
AS
	INSERT INTO WorkHoursLogs(EmployeeID, [Date], Task, [Hours], Comments, Change)
	SELECT EmployeeId, [Date], Task, [Hours], Comments, 'DELETE'
	FROM DELETED
GO

CREATE TRIGGER trg_WorkHours_Update ON WorkHours
FOR UPDATE 
AS
	INSERT INTO WorkHoursLogs(EmployeeID, [Date], Task, [Hours], Comments, Change)
	SELECT EmployeeId, [Date], Task, [Hours], Comments, 'UPDATE'
	FROM INSERTED
GO

INSERT INTO WorkHours VALUES
(4, GETDATE(), 'Fourth Task', 2, 'hard task'),
(5, GETDATE(), 'Fifth Task', 4, 'very hard task'),
(6, GETDATE(), 'Sixth Task', 6, NULL)
GO

UPDATE WorkHours
SET [Hours] = 20
WHERE EmployeeID = 5
GO

DELETE FROM WorkHours
WHERE EmployeeID = 6
GO

--30.Start a database transaction, delete all employees from the 'Sales' department along 
--with all dependent records from the pother tables.
--At the end rollback the transaction.

BEGIN TRANSACTION
	ALTER TABLE Departments
	DROP CONSTRAINT FK_Departments_Employees

	ALTER TABLE WorkHours
	DROP CONSTRAINT FK_WorkHours_Employees

	ALTER TABLE EmployeesProjects
	DROP CONSTRAINT FK_EmployeesProjects_Employees

	DELETE FROM Employees
	SELECT d.Name
	FROM Employees e
		JOIN Departments d
			ON e.DepartmentID = d.DepartmentID
	WHERE d.Name = 'Sales'
	GROUP BY d.Name
ROLLBACK TRAN

--31.Start a database transaction and drop the table EmployeesProjects.
--Now how you could restore back the lost table data?

BEGIN TRAN
	DROP TABLE EmployeesProjects
ROLLBACK TRAN

--32.Find how to use temporary tables in SQL Server.
--Using temporary tables backup all records from EmployeesProjects and 
--restore them back after dropping and re-creating the table.

BEGIN TRAN
	SELECT * INTO #TempTable
	FROM EmployeesProjects

	DROP TABLE EmployeesProjects

	SELECT * INTO EmployeesProjects
	FROM #TempTable

ROLLBACK TRAN


