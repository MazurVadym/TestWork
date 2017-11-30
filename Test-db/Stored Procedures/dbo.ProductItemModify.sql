SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ProductItemModify]
	@Id UNIQUEIDENTIFIER,
	@ProductListId UNIQUEIDENTIFIER,
	@ProductId bigint,
	@VariantId bigint,
	@Amount int
AS
BEGIN
		IF @ID IS NULL
            SET @ID = NEWID();	

		MERGE dbo.ProductItem target
		using (select @id 'Id')source
		on target.Id = source.Id
		when matched then
			update set
				target.ProductListId=@ProductListId,
				target.ProductId=@ProductId,
				target.VariantId=@VariantId,
				target.Amount=@Amount
		when not matched then
			insert(
				Id,
				ProductListId,
				ProductId,
				VariantId,
				Amount
			)
			values(
				@Id,
				@ProductListId,
				@ProductId,
				@VariantId,
				@Amount
			);

		select @Id
END
GO
