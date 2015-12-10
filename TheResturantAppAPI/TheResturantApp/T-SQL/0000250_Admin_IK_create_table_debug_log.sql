---------------------------------------------------------------------------------------------------------------
-- CREATE TABLE TEMPLATE SCRIPT
-- 1.  Do a Find and Replace on the Table name
-- 2.  Define the column names and additional columns
-- 3.  Save as new file according to Agility Convention E.g. 00010_AGL-101_RC_TABLE_utl_temp_table.sql
---------------------------------------------------------------------------------------------------------------
--- DROP TABLE debug_log
-- The following applies if you want to create a table from scratch
IF NOT EXISTS(SELECT *
                FROM sys.objects
               WHERE TYPE = 'U'
                 AND NAME = 'debug_log')
BEGIN
   -- Define your columns in your table
   CREATE TABLE dbo.[debug_log]
   (      debug_time DATETIME,
		  log_message VARCHAR(MAX) COLLATE DATABASE_DEFAULT NULL
          
		  )
   ON [DEFAULT]
   
   
   /* -- The following applies for a Primary Key defined by multiple columns
   ALTER TABLE dbo.utl_temp_table
     ADD CONSTRAINT pk_temp_id PRIMARY KEY (temp_id, temp_code, temp_date)
   */
   
   /* -- The following applies if there is a foreign key relationship
   ALTER TABLE dbo.[table_1]
     ADD CONSTRAINT FK_[table_1]_[table_2] FOREIGN KEY ([linking_id_column])
         REFERENCES dbo.[table_2]([linking_id_column])
   */
   
   /*  -- The following applies if you want to create an index on columns that are not the primary key
   CREATE NONCLUSTERED INDEX IX_utl_temp_table_temp_code
   ON  dbo.utl_temp_table (temp_code ASC)
   WITH (
       FILLFACTOR = 80,
       SORT_IN_TEMPDB = on 
       )
   ON [DEFAULT]
   */ 
   
   -- Grant Permissions
  --- GRANT SELECT, INSERT, UPDATE, DELETE ON dbo.customer TO [standard]
END


-- The following applies if you want to enable audit tracking on the table
/*
INSERT dbo.bfc_audit_table
(      table_name,
       single_row_only,
       primary_key,
       active,
       insert_datetime,
       insert_user,
       insert_process)
SELECT 'utl_temp_table' , -- (CONFIGURE THIS) table_name - varchar(200) 
       'Y' , -- single_row_only - varchar(1)
       'temp_id' , -- (CONFIGURE THIS) primary_key - varchar(200)
       'Y', 
       GetDate(), 
       Host_Name(), 
       'DATALOAD'
 WHERE NOT EXISTS (SELECT * 
                     FROM dbo.bfc_audit_table
                    WHERE table_name = 'utl_temp_table') -- (CONFIGURE THIS) table_name - varchar(200) 
                    
EXEC dbo.dbc_create_audit_tables_and_triggers
*/