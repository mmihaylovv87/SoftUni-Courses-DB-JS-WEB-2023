SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator IN ('Ollivander family')
GROUP BY DepositGroup