namespace TheResturantApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addentityOrderMenuCOlumns : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.orders", "is_invoiced", c => c.String(maxLength: 1));
            //AddColumn("dbo.orders", "menu_id", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            //AddColumn("dbo.orders", "unit_price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            //AddColumn("dbo.orders", "quantity", c => c.Int(nullable: false));
            //AddColumn("dbo.menu", "thumb_url", c => c.String());
            //AddColumn("dbo.menu", "large_url", c => c.String());
            //AddColumn("dbo.menu", "small_url", c => c.String());
        }
        
        public override void Down()
        {
            //DropColumn("dbo.menu", "small_url");
            //DropColumn("dbo.menu", "large_url");
            //DropColumn("dbo.menu", "thumb_url");
            //DropColumn("dbo.orders", "quantity");
            //DropColumn("dbo.orders", "unit_price");
            //DropColumn("dbo.orders", "menu_id");
            //DropColumn("dbo.orders", "is_invoiced");
        }
    }
}
