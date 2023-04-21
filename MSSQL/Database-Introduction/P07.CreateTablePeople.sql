CREATE TABLE [People](
	[Id] INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX) NULL
	CHECK(DATALENGTH(Picture) <= (1024 * 1024) * 2),
	[Height] DECIMAL(3,1) NULL,
	[Weight] DECIMAL(5,2) NULL,
	[GENDER] CHAR(1) NOT NULL,
	[Birthdate] DATETIME2 NOT NULL,
	[Biography] NVARCHAR(MAX) NULL
)

INSERT INTO People([Name], [Picture], [Height], [Weight], [Gender], [Birthdate], [Biography])
	VALUES
		 ('Pesho', NULL, 1.88, 85.60, 'm', '1959-10-10', NULL)
		,('Petya', NULL, 1.70, 57.70, 'f', '1989-12-05', NULL)
		,('Stivi', NULL, 1.80, 72.40, 'm', '1985-02-10', NULL)
		,('Misha', NULL, 1.60, 48.10, 'f', '1983-11-08', NULL)
		,('Tisho', NULL, 1.78, 75.00, 'm', '1987-05-10', NULL)