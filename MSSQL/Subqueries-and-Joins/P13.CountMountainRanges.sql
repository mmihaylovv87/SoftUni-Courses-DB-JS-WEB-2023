  SELECT c.[CountryCode],
	     COUNT(m.[MountainRange]) AS [MountainRanges]
    FROM [Mountains] AS m
    JOIN [MountainsCountries] AS mc
      ON m.[Id] = mc.[MountainId]
    JOIN [Countries] AS c
      ON mc.[CountryCode] = c.[CountryCode]
   WHERE c.[CountryCode] IN ('BG', 'RU', 'US')
GROUP BY c.[CountryCode]