CREATE TABLE [dbo].[Comment]
(
	[Id] INT identity(0, 1) NOT NULL PRIMARY KEY,
	[UserId] int not null,
	[ImgId] int not null,
	[Text] nvarchar(150) not null,
	constraint [FK_COMMENT_USER] foreign key ([UserId]) references [dbo].[User]([Id]),
	constraint [FK_COMMENT_IMAGE] foreign key ([ImgId]) references [dbo].[Image]([Id])
)
