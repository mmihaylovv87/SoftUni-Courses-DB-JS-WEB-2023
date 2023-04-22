SELECT [FirstName], [LastName] 
  FROM [Employees]
 WHERE LEFT([FirstName], 2) = 'Sa'

 
 ---Another way---
SELECT [FirstName], [LastName] 
  FROM [Employees]
 WHERE SUBSTRING([FirstName], 1, 2) = 'Sa'

 --Another way---
SELECT [FirstName], [LastName]
  FROM [Employees]
 WHERE [FirstName] LIKE 'Sa%'