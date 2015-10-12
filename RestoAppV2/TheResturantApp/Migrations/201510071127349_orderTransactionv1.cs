namespace TheResturantApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderTransactionv1 : DbMigration
    {
        public override void Up()
        {
            /**
            CreateTable(
                "dbo.order_transaction",
                c => new
                    {
                        transaction_id = c.Decimal(nullable: false, precision: 18, scale: 2, identity: true),
                        order_id = c.Decimal(nullable: false, precision: 18, scale: 2),
                        order_menu_id = c.Decimal(nullable: false, precision: 18, scale: 2),
                        unit_price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        order_amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        active = c.String(maxLength: 1),
                        insert_datetime = c.DateTime(nullable: false),
                        insert_user = c.String(maxLength: 100),
                        insert_process = c.String(maxLength: 100),
                        update_datetime = c.DateTime(nullable: false),
                        update_user = c.String(maxLength: 100),
                        update_process = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.transaction_id);
            ****/
        }
        
        public override void Down()
        {
           // DropTable("dbo.order_transaction");
        }
    }
}
