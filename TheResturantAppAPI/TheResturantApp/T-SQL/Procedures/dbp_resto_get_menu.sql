
IF OBJECT_ID ( 'dbp_resto_get_menu', 'P' ) IS NOT NULL 
    DROP PROCEDURE dbp_resto_get_menu ;
GO

CREATE PROCEDURE dbp_resto_get_menu
AS 
SET NOCOUNT ON;
SELECT 0 [ID], 
	   m.menu_id [MenuID],
	   m.menu_name [Name],
	   m.menu_description [Description],
	   mt.name [MenuType] ,
	   mc.category_name [MenuCategory], 
	   m.menu_price [Price],
	   m.thumb_url [ThumbUrl],
	   m.large_url [LargeUrl],
	   m.small_url [SmallUrl],
	   0.0 [QuantityOrdered]
  FROM dbo.menu m
  JOIN dbo.menu_type mt	 ON m.menu_type_id = mt.menu_type_id
  JOIN dbo.menu_category mc	 ON m.menu_category_id = mc.category_id


/***debug 
EXEC dbp_resto_get_menu
****/