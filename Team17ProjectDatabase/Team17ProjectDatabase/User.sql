CREATE TABLE [dbo].[User]
(
	[Id] INT identity(0, 1) NOT NULL PRIMARY KEY,
	[Username] varchar(25) not null,
	[Password] varchar(100) not null,
	[Email] varchar(50),
	[Type] int
)
