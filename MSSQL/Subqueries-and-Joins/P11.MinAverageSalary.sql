SELECT TOP(1) [AverageSalaries] AS [MinAverageSalary] 
         FROM 
		    (
	            SELECT AVG([Salary]) AS [AverageSalaries]
		          FROM [Employees]
	          GROUP BY [DepartmentID]
	        ) 
		   AS [SalariesQuery]
     ORDER BY [AverageSalaries] ASC