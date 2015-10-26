
IF OBJECT_ID ( 'dbp_get_recent_orders', 'P' ) IS NOT NULL 
    DROP PROCEDURE dbp_get_recent_orders;
GO
CREATE PROCEDURE dbp_get_recent_orders
				 @pv_order_by VARCHAR(100) ,
				 @pv_value VARCHAR(100)
AS
SET NOCOUNT ON;

DECLARE @customer_id NUMERIC(18)

IF @pv_order_by = 'phone'
BEGIN
SELECT @customer_id = c.customer_id
  FROM dbo.customer c
 WHERE phone_number = @pv_value
END

IF @pv_order_by = 'unique_id'
BEGIN
SELECT @customer_id = c.customer_id
  FROM dbo.customer c
 WHERE unique_id = CONVERT(uniqueidentifier, @pv_value)
END

IF NULLIF(@customer_id,0) IS NULL
BEGIN
SELECT @customer_id = 1
END

SELECT o.order_id OrderId,
	   o.customer_id CustomerId,
	   o.order_name Name,
	   o.order_date DateOrdered,
	   o.required_date DateRequired,
	   o.comments Comments,
	   t.menu_id  MenuID,
	   t.unit_price UnitPrice,
	   t.quantity Quantity,
	   t.amount TotalAmount,
	   m.menu_name MenuName,
	   IsNull(o.is_invoiced,'N') IsInvoiced
  FROM dbo.orders o
  JOIN dbo.order_transaction t ON o.order_id = t.order_id
  JOIN dbo.menu				 m ON t.menu_id = m.menu_id
 WHERE o.customer_id = @customer_id

/***DEBUG ***
EXEC dbp_get_recent_orders @pv_order_by = 'phone', @pv_value = '0220778677'

EXEC dbp_get_recent_orders @pv_order_by = 'unique_id', @pv_value = 'F40700B1-795C-46B0-A657-16BFA85749F2'

update customer 
  set phone_number = '0220778677'

********/

