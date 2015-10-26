--DECLARE @MyHierarchy Hierarchy
--INSERT INTO @myHierarchy
--select * from parseJSON('{"menu": {
--  "id": "file",
--  "value": "File",
--  "popup": {
--    "menuitem": [
--      {"value": "New", "onclick": "CreateNewDoc()"},
--      {"value": "Open", "onclick": "OpenDoc()"},
--      {"value": "Close", "onclick": "CloseDoc()"}
--    ]
--  }
--}}')
--SELECT dbo.ToJSON(@MyHierarchy)

BEGIN TRAN
DECLARE @MyHierarchy Hierarchy
INSERT INTO @MyHierarchy
Select * from parseJSON('{
  "orderId": 1.0,
  "customerId": 1,
  "name": "XMLTest",
  "dateOrdered": "2015-10-18T11:49:47.103262+13:00",
  "dateRequired": "2015-10-18T11:49:47.103262+13:00",
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
    },
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
')

SELECT * FROM @MyHierarchy

DECLARE @order TABLE
(		customer_id		NUMERIC(18),
		name			VARCHAR(100),
		date_ordered	DATETIME,
		date_required	DATETIME,
		comments		VARCHAR(500) NULL)

DECLARE @orderDetail TABLE 
(		menu_id			NUMERIC(18),
		unit_price		MONEY,
		quantity		NUMERIC(18))
		


INSERT INTO @order
(		customer_id,
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
		   max(case when name='customerId' then convert(NUMERIC(18),StringValue) else NULL end) as customerId,
		   max(case when name='name' then convert(Varchar(50),StringValue) else '' end) as [name],
		   max(case when name='dateOrdered' then CONVERT(DATETIME, CAST(StringValue as datetime2),101) else null  end) as [dateOrdered],
		   max(case when name='dateRequired' then CONVERT(DATETIME, CAST(StringValue as datetime2),101) else null end) as [dateRequired],
		   max(case when name='comments' then convert(Varchar(50),StringValue) else '' end) as [comments]
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
			   max(case when name='menuID' then convert(NUMERIC(18),StringValue) else NULL end) as menuID,
			   max(case when name='unitPrice' then convert(MONEY,StringValue) else NULL end) as [unitPrice],
			   max(case when name='quantity' then convert(NUMERIC(18),StringValue) else NULL end) as [quantity]
		From  @MyHierarchy
		where ValueType IN ('string', 'boolean','real','int')
		group by parent_ID
	 ) x	
	 WHERE x.menuID IS NOT NULL

	
SELECT * FROM @order
SELECT * FROM @orderDetail

--SELECT TOP 1 CONVERT(DATETIME, CAST(StringValue as datetime2),101)  FROM @MyHierarchy m   WHERE m.name in ('dateRequired')
--SELECT TOP 1 DATEPART(year,StringValue)  FROM @MyHierarchy m   WHERE m.name in ('dateOrdered')
--SELECT TOP 1 CONVERT(DATETIME, StringValue, 101)  FROM @MyHierarchy m   WHERE m.name in ('dateOrdered')


ROLLBACK