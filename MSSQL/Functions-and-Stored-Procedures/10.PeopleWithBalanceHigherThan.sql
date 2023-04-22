CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan (@balance MONEY)
AS
BEGIN
	SELECT FirstName, LastName
	FROM (
			SELECT ah.Id,
				 ah.FirstName,
				 ah.LastName,
				 SUM(Balance) AS TotalBalance
			FROM AccountHolders AS ah
			JOIN Accounts AS a
			ON ah.Id = a.AccountHolderId
			GROUP BY ah.Id, ah.FirstName, ah.LastName
		  ) AS TotalBalanceSubQ
	WHERE TotalBalance > @balance
	ORDER BY FirstName, LastName
END

EXECUTE usp_GetHoldersWithBalanceHigherThan 30000