IF OBJECT_ID ( 'dbp_resto_add_order', 'P' ) IS NOT NULL 
    DROP PROCEDURE dbp_resto_add_order ;
GO

CREATE PROCEDURE dbp_resto_add_order
		 @pv_order_name		VARCHAR(50),
		 @pv_customer_id	NUMERIC(18),
		 @pv_order_date		DATETIME,
		 @pv_required_date	DATETIME,
		 @pv_menu_id		NUMERIC(18),
		 @pv_unit_price		MONEY,
		 @pv_quantity		NUMERIC(18),
		 @pv_comments		VARCHAR(MAX),
		 @pn_output_id		NUMERIC(18) output
AS 
SET NOCOUNT ON;


 --DECLARE @pv_order_name		VARCHAR(50),
	--	 @pv_customer_id	NUMERIC(18),
	--	 @pv_order_date		DATETIME,
	--	 @pv_required_date	DATETIME,
	--	 @pv_menu_id		NUMERIC(18),
	--	 @pv_unit_price		MONEY,
	--	 @pv_quantity		NUMERIC(18),
	--	 @pv_comments		VARCHAR(MAX)

DECLARE @pv_insert_datetime DATETIME,
		@pv_insert_user		VARCHAR(20),
		@pv_insert_process	VARCHAR(20)

SELECT	@pv_insert_datetime = GETDATE(),
		@pv_insert_user = HOST_NAME(),
		@pv_insert_process = 'WEBAPI'

 INSERT INTO orders 
 (		order_name,
		customer_id,
		order_date,
		required_date,
		menu_id,
		unit_price,
		quantity,
		total_amount,
		comments,
		active,
		insert_datetime,
		insert_process,
		insert_user )
SELECT	@pv_order_name,
		@pv_customer_id,
		@pv_order_date,
		@pv_required_date,
		@pv_menu_id,
		@pv_unit_price,
		@pv_quantity,
		(@pv_unit_price * @pv_quantity),
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

EXEC dbo.dbp_resto_add_order @pv_order_name = 'Irfan',
							@pv_customer_id= 	2,
							@pv_order_date =  @d_date ,
							@pv_required_date=  @d_date,
							@pv_menu_id= 4,
							@pv_unit_price= 10.00,
							@pv_quantity=  3,
							@pv_comments= 'Initializing record',
						    @pn_output_id = @pn_outId OUTPUT
SELECT @pn_outId
ROLLBACK
****/