   IF NOT EXISTS( 
		SELECT 1 FROM resto_build 
		 WHERE build_version ='3.0'
   )
   BEGIN
	INSERT INTO resto_build
	(		build_version,
			build_date,
			ID)
	SELECT	'3.0',
			 GETDATE(),
			3
   END


BEGIN TRAN
update menu
  SET  thumb_url  = 'https://lh3.googleusercontent.com/-4SA0Vqw0isU/VjiTsccK1eI/AAAAAAAAApQ/Udpzd-SJ_NU/italian_prawn.png'
  WHERE menu_name = 'Sea Food'
COMMIT
