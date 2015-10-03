namespace TheResturantApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableCustomerV1 : DbMigration
    {
        public override void Up()
        {
//            //Always write this custom SQL to recreate the table.
//            string droptable = @"
//                          IF EXISTS (
//                          select *
//	                        from sys.tables 
//	                        where name = 'irfank.customer'
//	                        ) 
//	                        BEGIN
//	                        DROP TABLE irfank.customer
//	                        END
//                        ";
//            this.Sql(droptable);

//            //NPM code
//            CreateTable(
//                "irfank.customer",
//                c => new
//                    {
//                        customer_id = c.Int(nullable: false),
//                        customer_name = c.String(nullable: false, maxLength: 100),
//                        customer_phone = c.String(nullable: false, maxLength: 100),
//                        insert_datetime = c.DateTime(nullable: false),
//                        insert_user = c.String(nullable: false, maxLength: 100),
//                        insert_process = c.String(nullable: false, maxLength: 100),
//                        update_datetime = c.DateTime(nullable: false),
//                        update_user = c.String(maxLength: 100),
//                        update_process = c.String(maxLength: 100),
//                    })
//                .PrimaryKey(t => t.customer_id);
            
        }
        
        public override void Down()
        {
            //DropTable("irfank.customer");
        }
    }
}
