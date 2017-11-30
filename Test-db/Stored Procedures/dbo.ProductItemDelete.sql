SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[ProductItemDelete]
	@Ids dbo.GuidList readonly
AS
BEGIN
	delete from dbo.ListItem where id in (select [value] from @Ids)
END
GO
