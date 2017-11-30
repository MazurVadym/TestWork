CREATE TABLE [dbo].[Customer]
(
[Id] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Customer] ADD CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
