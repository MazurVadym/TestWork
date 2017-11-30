SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ProductItemGet]
	@SearchType int, -- 1-all, 2-byIds 3-byProductListId
	@Ids dbo.GuidList readonly

AS
BEGIN
	
		CREATE TABLE #ids (  Id uniqueidentifier );

		if @SearchType=1
			insert into #ids
			select id from dbo.ProductItem

		if @SearchType = 2
			insert into #ids
			select [value] 'Id' from @Ids

		select * from dbo.ProductItem
		where id in (select Id from #ids)

END
GO
