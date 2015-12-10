BEGIN TRAN
/****************************************************************
 Note: 
 1. Increase Build Number for new menus;

***********************************************************************/
IF OBJECT_ID('tempdb..#menu') IS NOT NULL DROP TABLE #menu

CREATE TABLE #menu
(	    name			VARCHAR(200) COLLATE DATABASE_DEFAULT NULL,
		menu_desc		VARCHAR(200) COLLATE DATABASE_DEFAULT NULL,
		menu_category	VARCHAR(200) COLLATE DATABASE_DEFAULT NULL,
		menu_type		VARCHAR(200) COLLATE DATABASE_DEFAULT NULL,
		menu_price		MONEY,
		thumb_url		VARCHAR(MAX) COLLATE DATABASE_DEFAULT NULL,

		cat_id			NUMERIC(18),
		menu_type_id	NUMERIC(18) )

INSERT INTO #menu
(		name,
		menu_desc,
		menu_category,
		menu_type,
		menu_price,
		thumb_url )
SELECT 'Chicken Afgani',
		'Afghani Chicken is another specialty recipe of Asian cuisine.',
		'Mains',
		'Chicken',
		15.00,
		'https://lh3.googleusercontent.com/-fZXGfuTB2UU/VeFCHZIIukI/AAAAAAAAAOo/hgxPzq3_a3c/c1_chicken_afgani.png'
UNION ALL
SELECT 'Chicken Kebab',
		'chicken kebab, better known as ‘tavuk şiş’ (tah-VOOK’ SHEESH’), is often served alongside grilled beef and lamb.',
		'Mains',
		'Chicken',
		15.00,
		'https://lh3.googleusercontent.com/-nyuWEiI0BQA/Vb0ilfsVLAI/AAAAAAAAANU/3ElmooO5tdo/gchickenkebab_highres.jpg'
UNION ALL
SELECT 'Chicken Smoked',
		'Chicken Smoked',
		'Mains',
		'Chicken',
		15.00,
		'https://lh3.googleusercontent.com/-ReuUjC4E6o0/VeFCHdGMYnI/AAAAAAAAAO4/BZB_1NVlEGk/c1_smoke_chicken.png'
UNION ALL
SELECT 'Butter Chicken',
		'Butter chicken or murgh makhani is an Indian dish of chicken in a mildly spiced curry sauce. ',
		'Mains',
		'Chicken',
		15.00,
		'https://lh3.googleusercontent.com/-cZdvAxn0EyA/VeFCHTm_nQI/AAAAAAAAAOM/UCVCzmAh8Fk/c1_butter_chicken.jpg'
UNION ALL
SELECT 'Chicken Tikka',
		'It is traditionally small pieces of boneless chicken baked using skewers in a clay oven called a tandoor after marinating in spices and yogurt-essentially a boneless version of tandoori chicken.',
		'Mains',
		'Chicken',
		15.00,
		'https://lh3.googleusercontent.com/-n_v-LXlsC6E/VbvmwT8wk8I/AAAAAAAAAL8/rRlK651PHI8/gv_ctikkav1.jpg'
UNION ALL
SELECT 'Vegetarian',
		'It is Vegetarian',
		'Mains',
		'Vegetarian',
		15.00,
		'https://lh3.googleusercontent.com/-xaCacbUrAYA/VbvmwR3NZrI/AAAAAAAAAJ0/SQmh3Q3O1y0/gv_vegev1.jpg'
UNION ALL
SELECT 'Lamb',
		'It is Lamb',
		'Mains',
		'Lamb',
		15.00,
		'https://lh3.googleusercontent.com/-rqCpTJhJ5QU/VbvmwUus3kI/AAAAAAAAAMM/GvW4J3P5RrE/gv_lambgrid.jpg'
UNION ALL
SELECT 'Sea Food',
		'It is sea food',
		'Mains',
		'Sea Food',
		15.00,
		'https://lh3.googleusercontent.com/-rqCpTJhJ5QU/VbvmwUus3kI/AAAAAAAAAMM/GvW4J3P5RrE/gv_lambgrid.jpg'
UNION ALL
SELECT 'Sides',
		'It is Side Dish',
		'Mains',
		'Sides',
		15.00,
		'https://lh3.googleusercontent.com/-WREcIrGaBYw/VbvmwYA0Z8I/AAAAAAAAAM4/xDmlBcWbfK8/gv_sidedishesv1.jpg'
UNION ALL
SELECT 'Starter',
		'It is Starter',
		'Mains',
		'Starter',
		15.00,
		'https://lh3.googleusercontent.com/-YPQi3-4I2aY/VeFCHe7dMrI/AAAAAAAAAOM/1wa21O3L2mk/k1_seek_kebab.png'
UNION ALL
SELECT 'Dessert',
		'It is Starter',
		'Mains',
		'Dessert',
		15.00,
		'https://lh3.googleusercontent.com/-Xh8aY2RRwd0/VeFCHSv2lzI/AAAAAAAAAOY/8SY3a6qk7WM/d1_icecream.png'
/***************** INSERT Starter ****************/
UNION ALL
SELECT 'Vege Spring Roll',
		'A super healthy Vietnamese favourite that''s quick and easy to make at home',
		'Starter',
		'Starter',
		15.00,
		'https://lh3.googleusercontent.com/-oSphV_HtmJg/Vjh50XCiEOI/AAAAAAAAAoc/DCYOoJfmpBg/spring_rolls.png'
/***************** INSERT Vegetarian ****************/
UNION ALL
SELECT 'Sprouting Broccoli',
		'Treated like asparagus, broccoli can be turned into a delicious starter.',
		'Mains', ---menu_category,
		'Vegetarian', ---menu_type
		15.00,
		'https://lh3.googleusercontent.com/-wPsWoqCDU64/Vjh5R1ZAZiI/AAAAAAAAAnQ/ey143HEViIA/brocolli.png'
/***************** INSERT Lamb ****************/
UNION ALL
SELECT 'Lamb Shank',
		'The tender, braised lamb shank elevates this favourite to something special.',
		'Mains', ---menu_category,
		'Lamb', ---menu_type
		15.00,
		'https://lh3.googleusercontent.com/-M4MJ7oJU3Ps/Vjh5YPg_fiI/AAAAAAAAAnk/ozof7dwhzd4/lamb_shank.png'

/***************** INSERT SeaFood ****************/
UNION ALL
SELECT 'Cardamon Prawns',
		'Cardamom and saffron dipping sauce with prawns',
		'Mains', ---menu_category,
		'Sea Food', ---menu_type
		15.00,
		'https://lh3.googleusercontent.com/-3qtDisGv9yg/Vjh5fshM07I/AAAAAAAAAn0/tDzAmWtmMQo/prawn.png'
/***************** INSERT Dessert ****************/
UNION ALL
SELECT 'Butterfly Triffle',
		'Sweet & delicious. You have to try this autumnal blackberry recipe',
		'Mains', ---menu_category,
		'Dessert', ---menu_type
		15.00,
		'https://lh3.googleusercontent.com/-oacb41rLdYk/Vjh5JclD8iI/AAAAAAAAAm8/23rJR29iAhM/blackberry_triffle.png'

/***************** INSERT Sides ****************/
UNION ALL
SELECT 'Scotch eggs',
		'Behold. The perfect picnic snack and not so time-consuming to make.',
		'Mains', ---menu_category,
		'Sides', ---menu_type
		15.00,
		'https://lh3.googleusercontent.com/-ReWMuvGQyb0/Vjh5ocC_0CI/AAAAAAAAAoI/I5pJRUqPt90/scotch_eggs.png'

UPDATE m
 SET cat_id = c.category_id
 FROM #menu m
 JOIN menu_category c ON c.category_name = m.menu_category
 
UPDATE m
 SET menu_type_id = t.menu_type_id
 FROM #menu m
 JOIN menu_type t on t.name = m.menu_type
 
 INSERT INTO Menu 
(		menu_name,	
		menu_description,
		menu_type_id,
		menu_category_id,
		menu_price,
		active,
		insert_datetime,
		insert_user,
		insert_process,
		thumb_url)
SELECT  m.name,
		m.menu_desc,
		 m.menu_type_id,
		 m.cat_id,
		 m.menu_price,
		 'Y',
		 GetDate(),
		 HOST_NAME(),
		 'IKPROCESS',
		 m.thumb_url
 FROM   #menu m 
 LEFT  JOIN menu m1	 ON m1.menu_name = m.name
 WHERE m1.menu_id IS NULL
 SELECT @@ROWCOUNT [ROW_COUNT]

 

---COMMIT
ROLLBACK

--SELECT * FROM menu 
--SELECT * FROM menu_category
--SELECT * from Menu_type
/***debug 

SELECT '#Menu', mc.category_Name [category_name], mt.name [menu_type], m.*
	 FROM menu m 
	 JOIN menu_type mt	 ON m.menu_type_id = mt.menu_type_id
	 JOIN menu_category mc ON m.menu_category_id = mc.category_id
ORDER BY m.menu_id asc

TRUNCATE TABLE menu
EXEC dbp_resto_get_menu
****/