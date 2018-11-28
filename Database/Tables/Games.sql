CREATE TABLE [dbo].[Games]
(
	[Name] NVARCHAR(300) NOT NULL PRIMARY KEY,
	[Date] DATETIME,
	[courtFees] NVARCHAR(300),
	[Venue] NVARCHAR(300),
	[whoPaid] NVARCHAR(300),
	[AmountSpent] NVARCHAR(300)
)
