SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ProductListModify]	
	@Id UNIQUEIDENTIFIER,
	@OwnerId nvarchar(200),
	@Active bit,
	@Flags bigint,
	@Title nvarchar(500)
AS
BEGIN
		IF @ID IS NULL
            SET @ID = NEWID();	

		MERGE dbo.ProductList target
		using (select @id 'Id')source
		on target.Id = source.Id
		when matched then
			update set 
				target.OwnerId=@OwnerId,
				target.Active=@Active,
				target.Flags=@Flags,
				target.Title=@Title
		when not matched then
			INSERT (Id,
				OwnerId,
				Created,
				Updated,
				Active,
				Flags,
				Title)
			VALUES (@Id,
					@OwnerId,
					GETUTCDATE(),
					GETUTCDATE(),
					@Active,
					@Flags,
					@Title);

		select @ID
END
GO
