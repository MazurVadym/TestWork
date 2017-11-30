SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ProductListGet]
	@SearchType int, -- 1-all, 2-by ids, 3-without event, 4-by OwnerId, 
	@Ids dbo.GuidList readonly,
	@OwnerId uniqueidentifier=null
AS
BEGIN
	    CREATE TABLE #ids (  Id uniqueidentifier );

		if @SearchType=1
			insert into #ids
			select id from dbo.ProductList

		if @SearchType = 2
			insert into #ids
			select [value] 'Id' from @Ids

		if @SearchType = 3
			insert into #ids
			select id from dbo.ProductList where EventListId is null

		if @SearchType = 4
		insert into #ids
			select id from dbo.ProductList where OwnerID = @OwnerId

		select * from dbo.ProductList
		where id in (select id from #ids)

		select * from dbo.ProductItem
		where ProductListId in (select id from #ids)

END
GO
