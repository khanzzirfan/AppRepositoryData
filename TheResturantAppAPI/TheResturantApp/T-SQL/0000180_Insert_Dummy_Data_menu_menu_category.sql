--Select *   from menu
--select * from menu_type
--select * from menu_category
--select * from orders

IF EXISTS( SELECT 'x' FROM menu_category mc where mc.category_name = 'starter')
BEGIN 
	DELETE FROM menu 
	DELETE FROM menu_category
	DELETE FROM menu_type
END

INSERT INTO menu_category
(	   category_name,
	   active,
	   insert_datetime,
	   insert_user,
	   insert_process)
SELECT 'Starter',
	   'Y',
	   GetDate(),
	   HOST_NAME(),
	   'IKProcess'
UNION ALL
SELECT 'Mains',
	   'Y',
	   GetDate(),
	   HOST_NAME(),
	   'IKProcess'
UNION ALL
SELECT 'Sides',
	   'Y',
	   GetDate(),
	   HOST_NAME(),
	   'IKProcess'	   

INSERT INTO menu_type 
(		name,
		active,
		insert_datetime,
		insert_user,
		insert_process)
SELECT 'Vegetarian',
		'Y',
		GetDate(),
		Host_name(),
		'IKProcess'
UNION ALL
SELECT 'Chicken',
		'Y',
		GetDate(),
		Host_name(),
		'IKProcess'
UNION ALL
SELECT 'Lamb',
		'Y',
		GetDate(),
		Host_name(),
		'IKProcess'
UNION ALL
SELECT 'Sea Food',
		'Y',
		GetDate(),
		Host_name(),
		'IKProcess'
UNION ALL
SELECT 'Dessert',
		'Y',
		GetDate(),
		Host_name(),
		'IKProcess'
UNION ALL
SELECT 'Sides',
		'Y',
		GetDate(),
		Host_name(),
		'IKProcess'
UNION ALL
SELECT 'Starter',
		'Y',
		GetDate(),
		Host_name(),
		'IKProcess'

--INSERT INTO Menu 
--(		menu_name,	
--		menu_description,
--		menu_type_id,
--		menu_category_id,
--		menu_price,
--		active,
--		insert_datetime,
--		insert_user,
--		insert_process)
--SELECT  'Chicken Tikka',
--		'Chicken Tikka description',
--		 t.menu_type_id,
--		 mc.category_id,
--		 10.00,
--		 'Y',
--		 GetDate(),
--		 HOST_NAME(),
--		 'IKPROCESS'
-- FROM   dbo.menu_type t 
-- CROSS JOIN dbo.menu_category mc 
-- WHERE t.name = 'Chicken'
--   AND mc.category_name = 'Mains'
--UNION ALL
--SELECT  'Sheek Kebab',
--		'Mutton Sheek Kebab description',
--		 t.menu_type_id,
--		 mc.category_id,
--		 10.00,
--		 'Y',
--		 GetDate(),
--		 HOST_NAME(),
--		 'IKPROCESS'
-- FROM   dbo.menu_type t 
-- CROSS JOIN dbo.menu_category mc 
-- WHERE t.name = 'Lamb'
--   AND mc.category_name = 'Starter'



IF NOT EXISTS( select 'x' from customer)
BEGIN
INSERT INTO customer 
(		first_name,
		last_name,
		full_name,
		dob,
		gender,
		email,
		phone_number,
		active,
		insert_datetime,
		insert_process,
		insert_user )
SELECT  'Irfan',
		'Khan',
		'Irfan Khan',
		'3-APRIL-2000',
		'M',
		'irfank@gmail.com',
		'44485305840',
		'Y',
		Getdate(),
		'process',
		'Irfank'
END
