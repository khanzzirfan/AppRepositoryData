namespace TheResturantApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderTransactions : DbMigration
    {
        public override void Up()
        {
            //RenameColumn(table: "dbo.order_transaction", name: "order_menu_id", newName: "menu_id");
            //RenameColumn(table: "dbo.order_transaction", name: "order_amount", newName: "amount");
            //AddColumn("dbo.order_transaction", "price_plan_id", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            //AddColumn("dbo.order_transaction", "Comments", c => c.String(maxLength: 200));
            //DropColumn("dbo.orders", "net_amount");
            //DropColumn("dbo.orders", "menu_id");
            //DropColumn("dbo.orders", "unit_price");
            //DropColumn("dbo.orders", "quantity");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.orders", "quantity", c => c.Int(nullable: false));
            //AddColumn("dbo.orders", "unit_price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            //AddColumn("dbo.orders", "menu_id", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            //AddColumn("dbo.orders", "net_amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            //DropColumn("dbo.order_transaction", "Comments");
            //DropColumn("dbo.order_transaction", "price_plan_id");
            //RenameColumn(table: "dbo.order_transaction", name: "amount", newName: "order_amount");
            //RenameColumn(table: "dbo.order_transaction", name: "menu_id", newName: "order_menu_id");
        }
    }
}
