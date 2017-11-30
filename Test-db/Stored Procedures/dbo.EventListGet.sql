SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[EventListGet]
	@SearchType int, -- 1-all 2-byIds
	@Ids dbo.GuidList readonly
AS
BEGIN
		CREATE TABLE #ids (  Id uniqueidentifier );

		if @SearchType=1
			insert into #ids
			select id from dbo.EventList

		if @SearchType = 2
			insert into #ids
			select [value] 'Id' from @Ids

		select * from dbo.EventList
		where id in (select id from #ids)

		select * from dbo.ProductList
		where EventListId in (select id from #ids)

		select * from dbo.ProductItem
		where ProductListId in (select id from dbo.ProductList
								where EventListId in (select id from #ids))
END
GO
