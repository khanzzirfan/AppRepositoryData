namespace TheResturantApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VirtualCoulmns2 : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.menu", "MenuCategory_ID", c => c.Decimal(precision: 18, scale: 2));
            //AlterColumn("dbo.menu", "menu_type_id", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            //AlterColumn("dbo.menu", "menu_category_id", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            //CreateIndex("dbo.menu", "menu_type_id");
            //CreateIndex("dbo.menu", "MenuCategory_ID");
            //AddForeignKey("dbo.menu", "MenuCategory_ID", "dbo.menu_category", "category_id");
            //AddForeignKey("dbo.menu", "menu_type_id", "dbo.menu_type", "menu_type_id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.menu", "menu_type_id", "dbo.menu_type");
            //DropForeignKey("dbo.menu", "MenuCategory_ID", "dbo.menu_category");
            //DropIndex("dbo.menu", new[] { "MenuCategory_ID" });
            //DropIndex("dbo.menu", new[] { "menu_type_id" });
            //AlterColumn("dbo.menu", "menu_category_id", c => c.Int(nullable: false));
            //AlterColumn("dbo.menu", "menu_type_id", c => c.Int(nullable: false));
            //DropColumn("dbo.menu", "MenuCategory_ID");
        }
    }
}
