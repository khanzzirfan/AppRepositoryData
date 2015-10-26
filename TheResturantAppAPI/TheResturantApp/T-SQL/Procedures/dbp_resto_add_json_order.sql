
IF OBJECT_ID ( 'dbp_resto_add_json_order', 'P' ) IS NOT NULL 
    DROP PROCEDURE dbp_resto_add_json_order ;
GO

CREATE PROCEDURE dbp_resto_add_json_order
		 @pv_json_order		VARCHAR(MAX),
		 @pn_output_id		NUMERIC(18) output
AS 
SET NOCOUNT ON;

DECLARE @order			TABLE
(		customer_id		NUMERIC(18),
		name			VARCHAR(100),
		date_ordered	DATETIME,
		date_required	DATETIME,
		comments		VARCHAR(500) NULL,
		unique_cust_id  UNIQUEIDENTIFIER )

DECLARE @orderDetail	TABLE 
(		menu_id			NUMERIC(18),
		unit_price		MONEY,
		quantity		NUMERIC(18))
	

DECLARE @pv_insert_datetime DATETIME,
		@pv_insert_user		VARCHAR(20),
		@pv_insert_process	VARCHAR(20),
		@d_today			DATETIME
		

SELECT	@pv_insert_datetime = GETDATE(),
		@pv_insert_user = HOST_NAME(),
		@pv_insert_process = 'WEBAPI',
		@d_today = DATEADD(DD, DATEDIFF(DD,0,GETDATE()),0)

DECLARE @MyHierarchy Hierarchy

INSERT INTO @MyHierarchy
Select * from parseJSON(@pv_json_order)


INSERT INTO @order
(		unique_cust_id,
		name,	
		date_ordered,
		date_required,
		comments)
SELECT TOP 1
		x.customerId,
		x.name,
		x.dateOrdered,
		x.dateRequired,
		x.comments
	FROM (
SELECT
		max(case when name='customerId'		then CONVERT(Varchar(50),StringValue) else NULL end) as customerId,
		max(case when name='name'			then CONVERT(Varchar(50),StringValue) else '' end) as [name],
		max(case when name='dateOrdered'	then CONVERT(DATETIME, CAST(StringValue as datetime2),101) else null  end) as [dateOrdered],
		max(case when name='dateRequired'	then CONVERT(DATETIME, CAST(StringValue as datetime2),101) else null end) as [dateRequired],
		max(case when name='comments'		then CONVERT(Varchar(50),StringValue) else '' end) as [comments]
From @MyHierarchy
where ValueType IN ('string', 'boolean','real','int')
group by parent_ID
) x 
WHERE x.customerId IS NOT NULL

INSERT INTO @orderDetail
(	   menu_id,
		unit_price,
		quantity)
SELECT x.menuID,
		x.unitPrice,
		x.quantity
	FROM(
		SELECT
			max(case when name='menuID'		then convert(NUMERIC(18),StringValue) else NULL end) as menuID,
			max(case when name='unitPrice'	then convert(MONEY,StringValue) else NULL end) as [unitPrice],
			max(case when name='quantity'	then convert(NUMERIC(18),StringValue) else NULL end) as [quantity]
	From  @MyHierarchy
	where ValueType IN ('string', 'boolean','real','int')
	group by parent_ID
	) x	
	WHERE x.menuID IS NOT NULL

/************************** Check Validation Errors *********/	
IF NOT EXISTS 
	(SELECT 'x' 
		FROM dbo.customer c 
		JOIN @order		  o	 ON c.unique_id = o.unique_cust_id)
BEGIN
DECLARE @cust_id VARCHAR(100)
SELECT @cust_id = unique_cust_id
  FROM @order 
EXEC dbp_resto_add_customer @cust_id
----Raiserror('No Customer Exists',16,1) return;
END

IF EXISTS 
(
SELECT *
  FROM @order o
 WHERE ((DATEDIFF(DD,@d_today,o.date_ordered) < 0) OR
		(DATEDIFF(DD,@d_today,o.date_required) < 0))
)
BEGIN
Raiserror('Date order is in the past cannot be accepted.',16,1) return;
END

IF EXISTS (
SELECT 1
  FROM @orderDetail od
  LEFT JOIN dbo.Menu		 m	 ON od.menu_id  = m.menu_id
  WHERE m.menu_id IS NULL
)
BEGIN
Raiserror('Invalida Menu ID entered.',16,1)
 return;
END

/************************** Insert Data *********/	
 INSERT INTO orders 
 (		order_name,
		customer_id,
		order_date,
		required_date,
		comments,
		active,
		insert_datetime,
		insert_process,
		insert_user )
SELECT	o.name,
		c.customer_id,
		o.date_ordered,
		o.date_required,
		o.comments,
		'Y',
		@pv_insert_datetime,
		@pv_insert_process,
		@pv_insert_user
  FROM	@order o 
  JOIN dbo.customer c ON o.unique_cust_id = c.unique_id
SELECT @pn_output_id = SCOPE_IDENTITY();

INSERT INTO order_transaction
(		order_id,
		menu_id,
		unit_price,
		quantity,
		discount,
		amount,
		active,
		insert_datetime,
		insert_user,
		insert_process )
SELECT  @pn_output_id,
		od.menu_id,
		od.unit_price,
		od.quantity,
		0,
		(od.unit_price * od.quantity),
		'Y',
		@pv_insert_datetime,
		@pv_insert_process,
		@pv_insert_user
  FROM  @orderdetail od

		
/** DEBUG *

BEGIN TRAN
DECLARE @pn_outId NUMERIC(18),
	    @d_date DATETIME = GETDATE()

DECLARE @jsonString VARCHAR(MAX)
SELECT @jsonString  = '{
  "orderId": 1.0,
  "customerId": "F40700B1-795C-46B0-A657-16BFA8574666",
  "name": "procTest_order",
  "dateOrdered": "2015-10-25T11:49:47.103262+13:00",
  "dateRequired": "2015-10-25T11:49:47.103262+13:00",
  "comments": "sample string 6",
  "orderItems": [
    {
      "orderID": 1.0,
      "menuID": 2.0,
      "unitPrice": 3.0,
      "quantity": 4.0,
      "discount": 5.0,
      "orderAmount": 6.0,
      "id": 7.0,
      "active": "Y",
      "insertDateTime": "2015-10-18T11:49:47.1062622+13:00",
      "insertUser": "sample",
      "insertProcess": "sample",
      "updateDateTime": "2015-10-18T11:49:47.1062622+13:00",
      "updateUser": "sample",
      "updateProcess": "sample"
    }
  ]
}
';

EXEC dbp_resto_add_json_order @pv_json_order = @jsonString ,
						    @pn_output_id = @pn_outId OUTPUT
SELECT @pn_outId

SELECT * FROM orders
SELECT * from order_transaction

ROLLBACK

****/