
IF OBJECT_ID ( 'dbp_get_recent_orders', 'P' ) IS NOT NULL 
    DROP PROCEDURE dbp_get_recent_orders;
GO
CREATE PROCEDURE dbp_get_recent_orders
				 @pv_order_by VARCHAR(100) ,
				 @pv_value VARCHAR(100)
AS
SET NOCOUNT ON;

DECLARE @customer_id NUMERIC(18)

SELECT @customer_id = c.customer_id
  FROM dbo.customer c
 WHERE phone_number = @pv_value

IF NULLIF(@customer_id,0) IS NULL
BEGIN
SELECT @customer_id = 1
END


SELECT o.order_id,
	   o.customer_id,
	   o.order_name,
	   o.order_date,
	   o.required_date,
	   o.comments,
	   t.menu_id,
	   t.unit_price,
	   t.quantity,
	   t.amount,
	   m.menu_name
  FROM dbo.orders o
  JOIN dbo.order_transaction t ON o.order_id = t.order_id
  JOIN dbo.menu				 m ON t.menu_id = m.menu_id
 WHERE o.customer_id = @customer_id

/***DEBUG ***
EXEC dbp_get_orders @pv_order_by = 'orderid', @pv_value = '2'
EXEC dbp_get_orders @pv_order_by = 'customerid', @pv_value = '2'
EXEC dbp_get_orders @pv_order_by = 'orderdate', @pv_value = '11-OCT-2015'

********/

