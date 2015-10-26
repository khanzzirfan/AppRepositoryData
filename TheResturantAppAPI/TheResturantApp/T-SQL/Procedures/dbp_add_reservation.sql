IF OBJECT_ID ( 'dbp_add_reservation', 'P' ) IS NOT NULL 
    DROP PROCEDURE dbp_add_reservation;
GO

CREATE PROCEDURE dbp_add_reservation 
	@pv_name		VARCHAR(50),
	@pn_guest		INT,
	@pv_email		VARCHAR(200),
	@pv_phone		VARCHAR(10),
	@pv_comment		VARCHAR(500),
	@pv_date		DATETIME,
	@pv_time		VARCHAR(20),
	@pv_cust_id		VARCHAR(100),
	@pn_output_id		NUMERIC(18) OUTPUT
	
AS
SET NOCOUNT ON;



DECLARE @identity NUMERIC(18);
INSERT INTO reservation
(			name,
			guests,
			email,
			phone_number,
			comments,
			start_date,
			start_time,
			active,
			insert_datetime,
			insert_process,
			insert_user,
			customer_uid)
SELECT		@pv_name,
			@pn_guest,
			@pv_email,
			@pv_phone,
			@pv_comment,
			@pv_date,
			@pv_time,
			'Y',
			GETDATE(),
			'WebApp',
			HOST_NAME(),
			CONVERT(UniqueIdentifier,@pv_cust_id)

SELECT @pn_output_id = SCOPE_IDENTITY();

GO

/***
----Debug 
DECLARE @identity  NUMERIC(18)
EXEC 
*****/