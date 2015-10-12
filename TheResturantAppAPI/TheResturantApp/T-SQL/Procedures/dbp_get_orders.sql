
IF OBJECT_ID ( 'dbp_get_orders', 'P' ) IS NOT NULL 
    DROP PROCEDURE dbp_get_orders;
GO
CREATE PROCEDURE dbp_get_orders
				 @pv_order_by VARCHAR(100) ,
				 @pv_value VARCHAR(100)
AS
SET NOCOUNT ON;

IF @pv_order_by = 'orderid'
BEGIN
DECLARE @order_id NUMERIC(18)
SELECT @order_id = CONVERT(NUMERIC(18), @pv_value);

SELECT	o.order_id [OrderId],
		o.order_name [Name],
		o.customer_id [CustomerId],
		m.menu_name [MenuName],
		o.unit_price [UnitPrice],
		o.quantity [Quantity],
		o.total_amount [TotalAmount],
		o.order_date [DateOrdered],
		o.is_invoiced [IsInvoiced]
  FROM  dbo.orders o
  JOIN  dbo.menu		m	 ON o.menu_id = m.menu_id
  WHERE o.order_id= @order_id 
END

IF @pv_order_by = 'customerid'
BEGIN
DECLARE @customer_id NUMERIC(18)
SELECT @customer_id = CONVERT(NUMERIC(18), @pv_value);

SELECT	o.order_id [OrderId],
		o.order_name [Name],
		o.customer_id [CustomerId],
		m.menu_name [MenuName],
		o.unit_price [UnitPrice],
		o.quantity [Quantity],
		o.total_amount [TotalAmount],
		o.order_date [DateOrdered],
		o.is_invoiced [IsInvoiced]
  FROM  dbo.orders o
  JOIN  dbo.menu		m	 ON o.menu_id = m.menu_id
  WHERE o.customer_id= @customer_id 
END

IF @pv_order_by = 'orderdate'
BEGIN
DECLARE @order_date DATETIME
SELECT @order_date = CONVERT(DATETIME, @pv_value);

SELECT	o.order_id [OrderId],
		o.order_name [Name],
		o.customer_id [CustomerId],
		m.menu_name [MenuName],
		o.unit_price [UnitPrice],
		o.quantity [Quantity],
		o.total_amount [TotalAmount],
		o.order_date [DateOrdered],
		o.is_invoiced [IsInvoiced]
  FROM  dbo.orders o
  JOIN  dbo.menu		m	 ON o.menu_id = m.menu_id
  WHERE	DATEADD(DD,DATEDIFF(DD, 0, o.order_date),0) = @order_date

END


/***DEBUG ***
EXEC dbp_get_orders @pv_order_by = 'orderid', @pv_value = '2'
EXEC dbp_get_orders @pv_order_by = 'customerid', @pv_value = '2'
EXEC dbp_get_orders @pv_order_by = 'orderdate', @pv_value = '11-OCT-2015'

********/
