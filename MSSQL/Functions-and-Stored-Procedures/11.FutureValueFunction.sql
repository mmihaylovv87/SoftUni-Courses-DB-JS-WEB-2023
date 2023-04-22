CREATE FUNCTION ufn_CalculateFutureValue (@sum DECIMAL(18,4), @yearlyRate FLOAT, @years INT)
RETURNS DECIMAL(18, 4)
AS
BEGIN
	DECLARE @FutureValue DECIMAL(18,4) = @sum * POWER((1 + @yearlyRate), @years)
	RETURN @FutureValue
END