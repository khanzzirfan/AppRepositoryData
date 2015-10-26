
IF NOT EXISTS(SELECT * FROM sys.columns 
            WHERE Name = N'is_invoiced' AND Object_ID = Object_ID(N'orders'))
BEGIN
 ALTER TABLE orders 
 ADD is_invoiced VARCHAR(1) COLLATE DATABASE_DEFAULT NULL
END

IF NOT  EXISTS(SELECT * FROM sys.columns 
            WHERE Name = N'thumb_url' AND Object_ID = Object_ID(N'menu'))
BEGIN
 ALTER TABLE menu
 ADD thumb_url VARCHAR(MAX)  COLLATE DATABASE_DEFAULT NULL
END

IF NOT EXISTS(SELECT * FROM sys.columns 
            WHERE Name = N'large_url' AND Object_ID = Object_ID(N'menu'))
BEGIN
 ALTER TABLE menu
 ADD large_url VARCHAR(MAX)  COLLATE DATABASE_DEFAULT NULL
END

IF NOT EXISTS(SELECT * FROM sys.columns 
            WHERE Name = N'small_url' AND Object_ID = Object_ID(N'menu'))
BEGIN
 ALTER TABLE menu
 ADD small_url VARCHAR(MAX)  COLLATE DATABASE_DEFAULT NULL
END


IF NOT EXISTS(SELECT * FROM sys.columns 
            WHERE Name = N'unique_id' AND Object_ID = Object_ID(N'customer'))
BEGIN
 ALTER TABLE customer
 ADD unique_id UNIQUEIDENTIFIER 
END

IF NOT EXISTS(SELECT * FROM sys.columns 
            WHERE Name = N'customer_uid' AND Object_ID = Object_ID(N'reservation'))
BEGIN
 ALTER TABLE reservation
 ADD customer_uid UNIQUEIDENTIFIER 
END
