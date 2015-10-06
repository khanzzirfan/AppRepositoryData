namespace TheResturantApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerTableMapping : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.customer",
            //    c => new
            //        {
            //            customer_id = c.Int(nullable: false),
            //            full_name = c.String(nullable: false, maxLength: 100),
            //            first_name = c.String(maxLength: 100),
            //            last_name = c.String(maxLength: 100),
            //            dob = c.DateTime(nullable: false),
            //            ird_number = c.String(maxLength: 100),
            //            gender = c.String(maxLength: 10),
            //            email = c.String(nullable: false, maxLength: 100),
            //            phone_number = c.String(nullable: false, maxLength: 100),
            //            home_number = c.String(maxLength: 100),
            //            active = c.String(maxLength: 1),
            //            insert_datetime = c.DateTime(nullable: false),
            //            insert_user = c.String(nullable: false, maxLength: 100),
            //            insert_process = c.String(nullable: false, maxLength: 100),
            //            update_datetime = c.DateTime(nullable: false),
            //            update_user = c.String(maxLength: 100),
            //            update_process = c.String(maxLength: 100),
            //        })
            //    .PrimaryKey(t => t.customer_id);
            
            //CreateTable(
            //    "dbo.Orders",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            CustomerId = c.Int(nullable: false),
            //            TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            TaxAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            NetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            Comments = c.String(maxLength: 400),
            //            InsertDateTime = c.DateTime(nullable: false),
            //            InsertProcess = c.String(nullable: false, maxLength: 100),
            //            InsertUser = c.String(nullable: false, maxLength: 100),
            //            UpdateDateTime = c.DateTime(),
            //            Updateuser = c.String(maxLength: 100),
            //            UpdateProcess = c.String(maxLength: 100),
            //        })
            //    .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            //DropTable("dbo.Orders");
            //DropTable("dbo.customer");
        }
    }
}
