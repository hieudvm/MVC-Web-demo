CREATE TABLE [dbo].[Image]
(
	[Id] INT identity(0, 1) NOT NULL PRIMARY KEY,
	[UserId] int not null,
	[Url] varchar(100) not null,
	[LocationId] int not null,
	constraint [FK_IMAGE_USER] foreign key ([UserId]) references [dbo].[User]([Id]),
	constraint [FK_IMAGE_LOCATION] foreign key ([LocationId]) references [dbo].[Location]([Id])
)
