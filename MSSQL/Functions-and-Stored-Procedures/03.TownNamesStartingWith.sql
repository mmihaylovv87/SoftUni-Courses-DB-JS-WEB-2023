CREATE PROCEDURE usp_GetTownsStartingWith @startsWith NVARCHAR(MAX)
AS
BEGIN
	SELECT [Name]
	FROM Towns
	WHERE [Name] LIKE @startsWith + '%'
END

EXECUTE usp_GetTownsStartingWith 'b'