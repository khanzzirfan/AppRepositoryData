namespace TheResturantApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reservation : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.reservation",
            //    c => new
            //        {
            //            reservation_id = c.Decimal(nullable: false, precision: 18, scale: 2, identity: true),
            //            name = c.String(nullable: false, maxLength: 100),
            //            guests = c.Int(nullable: false),
            //            status_id = c.Int(nullable: false),
            //            email = c.String(maxLength: 100),
            //            phone_number = c.String(nullable: false, maxLength: 100),
            //            comments = c.String(),
            //            start_date = c.DateTime(nullable: false),
            //            start_time = c.String(nullable: false),
            //            table_id = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            active = c.String(maxLength: 1),
            //            insert_datetime = c.DateTime(nullable: false),
            //            insert_user = c.String(maxLength: 100),
            //            insert_process = c.String(maxLength: 100),
            //            update_datetime = c.DateTime(nullable: false),
            //            update_user = c.String(maxLength: 100),
            //            update_process = c.String(maxLength: 100),
            //        })
            //    .PrimaryKey(t => t.reservation_id);
            
        }
        
        public override void Down()
        {
            //DropTable("dbo.reservation");
        }
    }
}
