
IF NOT EXISTS(SELECT * FROM sys.columns 
            WHERE Name = N'is_invoiced' AND Object_ID = Object_ID(N'orders'))
BEGIN
 ALTER TABLE orders 
 ADD is_invoiced VARCHAR(1) COLLATE DATABASE_DEFAULT NULL
END

IF NOT EXISTS(SELECT * FROM sys.columns 
            WHERE Name = N'menu_id' AND Object_ID = Object_ID(N'orders'))
BEGIN
 ALTER TABLE orders 
 ADD menu_id NUMERIC(18) NULL
END

IF NOT EXISTS(SELECT * FROM sys.columns 
            WHERE Name = N'unit_price' AND Object_ID = Object_ID(N'orders'))
BEGIN
 ALTER TABLE orders 
 ADD unit_price  Money NULL
END

IF NOT EXISTS(SELECT * FROM sys.columns 
            WHERE Name = N'quantity' AND Object_ID = Object_ID(N'orders'))
BEGIN
 ALTER TABLE orders 
 ADD quantity NUMERIC(18) NULL
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

