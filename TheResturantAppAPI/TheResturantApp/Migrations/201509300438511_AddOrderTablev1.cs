namespace TheResturantApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderTablev1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "irfank.orders",
                c => new
                    {
                        order_id = c.Int(nullable: false, identity: true),
                        customer_id = c.Int(nullable: false),
                        total_amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        tax_amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        net_amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        comments = c.String(maxLength: 400),
                        insert_datetime = c.DateTime(nullable: false),
                        insert_process = c.String(nullable: false, maxLength: 100),
                        insert_user = c.String(nullable: false, maxLength: 100),
                        update_datetime = c.DateTime(),
                        update_user = c.String(maxLength: 100),
                        update_process = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.order_id);
            
        }
        
        public override void Down()
        {
            DropTable("irfank.orders");
        }
    }
}
