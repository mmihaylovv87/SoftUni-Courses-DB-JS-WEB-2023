CREATE PROCEDURE usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
BEGIN
	DELETE FROM EmployeesProjects
	WHERE EmployeeID IN (
							SELECT EmployeeID
							FROM Employees
							WHERE DepartmentID IN (@departmentId)
						)

	UPDATE Employees
	SET ManagerID = NULL
	WHERE ManagerID IN (
							SELECT EmployeeID
							FROM Employees
							WHERE DepartmentID IN (@departmentId)
						)

	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT

	UPDATE Departments
	SET ManagerID = NULL
	WHERE ManagerID IN (	
							SELECT EmployeeID
							FROM Employees
							WHERE DepartmentID IN (@departmentId)
						)

	DELETE FROM Employees
	WHERE DepartmentID IN (@departmentId)

	DELETE FROM Departments
	WHERE DepartmentID IN (@departmentId)

	SELECT COUNT(*)
	FROM Employees
	WHERE DepartmentID IN (@departmentId)
END

EXECUTE usp_DeleteEmployeesFromDepartment 4