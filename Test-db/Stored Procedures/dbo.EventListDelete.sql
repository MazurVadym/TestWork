SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[EventListDelete] 
	@Ids dbo.GuidList readonly
AS
BEGIN
	delete from dbo.EventList where id in(select [value] from @Ids)

	update dbo.ProductList set EventListId=null  where EventListId in (select [value] from @Ids)
END
GO
