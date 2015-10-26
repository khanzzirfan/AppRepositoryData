
IF OBJECT_ID ( 'dbp_resto_add_baseorder', 'P' ) IS NOT NULL 
    DROP PROCEDURE dbp_resto_add_baseorder ;
GO

CREATE PROCEDURE dbp_resto_add_baseorder
		 @pv_order_name		VARCHAR(50),
		 @pv_customer_id	NUMERIC(18),
		 @pv_order_date		DATETIME,
		 @pv_required_date	DATETIME,
		 @pv_comments		VARCHAR(MAX),
		 @pn_output_id		NUMERIC(18) output
AS 
SET NOCOUNT ON;

DECLARE @pv_insert_datetime DATETIME,
		@pv_insert_user		VARCHAR(20),
		@pv_insert_process	VARCHAR(20),
		@d_today			DATETIME
		

SELECT	@pv_insert_datetime = GETDATE(),
		@pv_insert_user = HOST_NAME(),
		@pv_insert_process = 'WEBAPI',
		@d_today = DATEADD(DD, DATEDIFF(DD,0,GETDATE()),0)

IF NOT EXISTS (SELECT 'x' FROM dbo.customer c  WHERE c.customer_id = @pv_customer_id)
BEGIN
Raiserror('No Customer Exists',16,1) return;
END

IF ((DATEDIFF(DD,@d_today,@pv_order_date) < 0) OR (DATEDIFF(DD,@d_today,@pv_required_date) < 0))
BEGIN
Raiserror('Date order is in the past cannot be accepted.',16,1) return;
END

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
SELECT	@pv_order_name,
		@pv_customer_id,
		@pv_order_date,
		@pv_required_date,
		@pv_comments,
		'Y',
		@pv_insert_datetime,
		@pv_insert_process,
		@pv_insert_user
SELECT @pn_output_id = SCOPE_IDENTITY();

		
/** DEBUG *

BEGIN TRAN
DECLARE @pn_outId NUMERIC(18),
	    @d_date DATETIME = GETDATE()

EXEC dbp_resto_add_baseorder @pv_order_name = 'Irfan',
							@pv_customer_id= 	1,
							@pv_order_date =  @d_date ,
							@pv_required_date=  @d_date,
							@pv_comments= 'Initializing record',
						    @pn_output_id = @pn_outId OUTPUT
SELECT @pn_outId
ROLLBACK

****/