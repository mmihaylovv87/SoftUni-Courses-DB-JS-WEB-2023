SELECT LEFT(FirstName, 1) AS FirstLetter
FROM WizzardDeposits
WHERE DepositGroup IN ('Troll Chest')
GROUP BY LEFT(FirstName, 1)
ORDER BY FirstLetter