SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[EventListModify]
	@Id UNIQUEIDENTIFIER,
	@OwnerId nvarchar(200),
	@Title nvarchar(100),
	@Active bit,
	@Description nvarchar(500),
	@Flags bigint ,
	@Public bit,
	@ProductListsId dbo.GuidList readonly
AS
BEGIN
	BEGIN TRANSACTION;	

	if @Id is not null
		update dbo.ProductList set EventListId = null where EventListId=@Id

	IF @Id IS NULL
            SET @Id = NEWID();	

	MERGE dbo.EventList target
	using (select @id 'Id')source
	on target.Id = source.Id
	when matched then
		update set 
		target.OwnerId=cast(@OwnerId as nvarchar(200)),
		target.Title=@Title,
		target.Active=@Active,
		target.[Description]=@Description,
		target.Updated=GETUTCDATE(),
		target.Flags=@Flags,
		target.[Public]=@Public
	when not matched then
		INSERT (Id,
				OwnerID,
				Title,
				Active,
				[Description],
				Created,
				Updated,
				Flags,
				[Public])
		VALUES (@Id,
				@OwnerId,
				@Title,
				@Active,
				@Description,
				GETUTCDATE(),
				GETUTCDATE(),
				@Flags,
				@Public);

	update dbo.ProductList set EventListId = @Id, ownerId=@OwnerId  where id in (select [Value] from @ProductListsId)

	select @Id

	COMMIT TRANSACTION;
END
GO
