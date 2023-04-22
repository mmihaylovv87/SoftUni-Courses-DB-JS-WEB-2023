SELECT * 
INTO #Temp_Employees
FROM Employees
WHERE Salary > 30000

DELETE 
FROM #Temp_Employees
WHERE ManagerID IN (42)

UPDATE #Temp_Employees
SET Salary += 5000
WHERE DepartmentID IN (1)

SELECT DepartmentID,
	   AVG(#Temp_Employees.Salary) AS AverageSalary
FROM #Temp_Employees
GROUP BY DepartmentID