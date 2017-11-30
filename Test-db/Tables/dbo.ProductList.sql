CREATE TABLE [dbo].[ProductList]
(
[Id] [uniqueidentifier] NOT NULL,
[EventListId] [uniqueidentifier] NULL,
[OwnerId] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Active] [bit] NOT NULL,
[Created] [datetime] NOT NULL,
[Updated] [datetime] NOT NULL,
[Flags] [bigint] NULL,
[Title] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ProductList] ADD CONSTRAINT [PK_ProductList] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
