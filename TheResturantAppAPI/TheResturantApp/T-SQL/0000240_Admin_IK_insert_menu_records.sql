
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



--SELECT * FROM menu 
--SELECT * FROM menu_category
--SELECT * from Menu_type
/***debug 
TRUNCATE TABLE menu
EXEC dbp_resto_get_menu
****/