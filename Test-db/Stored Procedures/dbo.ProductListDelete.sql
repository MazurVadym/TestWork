SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ProductListDelete]
	@Ids dbo.GuidList readonly
AS
BEGIN
	delete from dbo.ProductItem where productListId in (select [value] from  @Ids)

	delete from dbo.ProductList where id in (select [value] from @Ids)
END
GO
