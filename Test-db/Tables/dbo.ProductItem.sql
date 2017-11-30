CREATE TABLE [dbo].[ProductItem]
(
[Id] [uniqueidentifier] NOT NULL,
[ProductListId] [uniqueidentifier] NOT NULL,
[ProductId] [bigint] NOT NULL,
[VariantId] [bigint] NOT NULL,
[Amount] [int] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ProductItem] ADD CONSTRAINT [PK_ProductItem] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ProductItem] ADD CONSTRAINT [FK_ProductItem_ProductList] FOREIGN KEY ([ProductListId]) REFERENCES [dbo].[ProductList] ([Id])
GO
