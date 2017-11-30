CREATE TABLE [dbo].[EventList]
(
[Id] [uniqueidentifier] NOT NULL,
[OwnerId] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Title] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Active] [bit] NOT NULL,
[Description] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Created] [datetime] NOT NULL,
[Updated] [datetime] NOT NULL,
[Flags] [bigint] NULL,
[Public] [bit] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[EventList] ADD CONSTRAINT [PK_EventList] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
