CREATE TABLE [dbo].[QuantityMeasurementData]
(
	[Id] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[OptionType] VARCHAR(50),
	[Value]	DECIMAL,
	[Result] DECIMAL,
	[DateOfCreation] DATETIME
)
