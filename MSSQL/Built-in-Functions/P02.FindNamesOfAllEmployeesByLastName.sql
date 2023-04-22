SELECT [FirstName], [LastName] 
  FROM [Employees]
 WHERE [LastName] LIKE '%ei%'

 ---Another way---
SELECT [FirstName], [LastName]
  FROM [Employees]
 WHERE CHARINDEX('ei', [LastName]) <> 0