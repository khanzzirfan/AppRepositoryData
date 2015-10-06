/****************************************************************************************************
 * Template Name: Add Column to table
 * Date         : 16 April 2007
 * Author       : Dean Williamson
 * Requirement  : A template that can be used for adding Columns to tables
 * Updated on   : 27 Mar 2012
 * Modification : Customised the script to handle multiple alter statements
 ****************************************************************************************************/
DECLARE @t_table_changes TABLE
(       id                    NUMERIC(18,0) IDENTITY(1,1),
        column_name           VARCHAR(255) COLLATE database_default NULL,
        table_name            VARCHAR(255) COLLATE database_default NULL,
        datatype              VARCHAR(255) COLLATE database_default NULL,
        default_string        VARCHAR(100) COLLATE database_default NULL,
        default_number        NUMERIC(18) NULL)

DECLARE @v_column_name        VARCHAR(255),
        @v_table_name         VARCHAR(255),
        @v_datatype           VARCHAR(255),
        @v_default            VARCHAR(100),
        @n_default            NUMERIC(18),
        @v_sql_text           NVARCHAR(1000),
        @n_ctr                NUMERIC,
        @n_number_of_columns  NUMERIC,
        @n_debug              NUMERIC,
        @v_audit              VARCHAR(1)

-----------------------------------------------------------------------------------------
-- setup run variables
-----------------------------------------------------------------------------------------
SELECT @n_debug = 1,
       @n_ctr = 1,
       @v_audit = 'N'

-----------------------------------------------------------------------------------------
-- Populate the table variable with the columns to be added  
-----------------------------------------------------------------------------------------
INSERT @t_table_changes
(      column_name,
       table_name,
       datatype,
       default_string,
       default_number)
SELECT column_name = 'start_date',
       table_name = 'price_plan_rates',
       datatype = 'datetime',
       default_string = NULL,
       default_number = NULL
 UNION ALL 
SELECT column_name = 'end_date',
       table_name = 'price_plan_rates',
       datatype = 'datetime',
       default_string = NULL,
       default_number = NULL

-----------------------------------------------------------------------------------------
-- Loop through and add columns
-----------------------------------------------------------------------------------------
 -- Store the number of columns to be added
SELECT @n_number_of_columns = Count(*) 
  FROM @t_table_changes

WHILE (@n_ctr <= @n_number_of_columns)
BEGIN
   SELECT @v_table_name = table_name,
          @v_column_name = column_name,
          @v_datatype = datatype,
          @v_default = default_string,
          @n_default = default_number
     FROM @t_table_changes
    WHERE id = @n_ctr
   
   IF NOT EXISTS(SELECT * 
                   FROM sys.syscolumns    sc
                   JOIN sys.sysobjects    so    ON so.id = sc.id 
                  WHERE sc.name = @v_column_name
                    AND so.name = @v_table_name)
      AND EXISTS (SELECT * 
                    FROM sys.sysobjects   so 
                   WHERE so.name = @v_table_name)
   BEGIN
      IF @n_debug = 1 PRINT 'Adding column ' + @v_column_name + ' to ' + @v_table_name
   
      SELECT @v_sql_text = 'ALTER TABLE dbo.' + @v_table_name + ' ADD ' + @v_column_name + ' ' + @v_datatype + IsNull(' DEFAULT ' + IsNull('''' + @v_default + '''', Convert(VARCHAR(20), @n_default)), '')
      
      EXEC sp_executesql @v_sql_text

      IF @n_debug = 1 PRINT @v_sql_text

      IF @v_default IS NOT NULL OR @n_default IS NOT NULL
      BEGIN
         IF EXISTS(SELECT * 
                     FROM sys.sysobjects  so
                    WHERE so.name = @v_table_name + '_audit_trig' 
                      AND so.type = 'TR')
         BEGIN
            SELECT @v_sql_text = 'DISABLE TRIGGER ' + @v_table_name + '_audit_trig ON ' + @v_table_name
            
            EXEC sp_executesql @v_sql_text
            
            IF @n_debug = 1 PRINT @v_sql_text
         END

         SELECT @v_sql_text = 'UPDATE dbo.' + @v_table_name + ' SET ' + @v_column_name + ' = ' + IsNull('''' + @v_default + '''', Convert(VARCHAR(20), @n_default))
         
         EXEC sp_executesql @v_sql_text 

         IF @n_debug = 1 PRINT @v_sql_text

         IF EXISTS(SELECT * 
                     FROM sys.sysobjects  so
                    WHERE so.name = @v_table_name + '_audit_trig' 
                      AND so.type = 'TR')
         BEGIN
            SELECT @v_sql_text = 'ENABLE TRIGGER ' + @v_table_name + '_audit_trig ON ' + @v_table_name
            
            EXEC sp_executesql @v_sql_text
            
            IF @n_debug = 1 PRINT @v_sql_text
         END
      END
   END 
   ELSE
   BEGIN
      IF @n_debug = 1 PRINT 'Table: ' + @v_table_name + ', Column already exists: ' + @v_column_name + ', Datatype: ' + @v_datatype
   END
   
   -- if an audit table exists ensure the column is also added there
   IF EXISTS(SELECT * 
               FROM sys.sysobjects  so
              WHERE so.name = @v_table_name + '_bfc_audit' 
                AND type = 'U')
   BEGIN
      IF NOT EXISTS(SELECT * 
                      FROM sys.syscolumns    sc
                      JOIN sys.sysobjects    so    ON so.id = sc.id 
                     WHERE sc.name = @v_column_name
                       AND so.name = @v_table_name + '_bfc_audit')
      BEGIN
         SELECT @v_sql_text = 'ALTER TABLE dbo.' + @v_table_name + '_bfc_audit ADD ' + @v_column_name + ' ' + @v_datatype + IsNull(' DEFAULT ' + IsNull('''' + @v_default + '''', Convert(VARCHAR(20), @n_default)), '')
         
         EXEC sp_executesql @v_sql_text
      END 
   END
   
   --IF EXISTS (SELECT * 
   --             FROM dbo.bfc_audit_table
   --            WHERE table_name = @v_table_name)
   --BEGIN
   --   SELECT @v_audit = 'Y'
   --END
   
   SELECT @n_ctr = @n_ctr + 1
END

---- Recreate Audit Table Trigger as the column specification has changed
--IF @v_audit = 'Y'
--BEGIN
--   EXEC dbo.dbc_create_audit_tables_and_triggers @debug = 'N',
--                                                 @recreate_trig = 'Y',
--                                                 @drop_tables = 'N'
--END
--GO
