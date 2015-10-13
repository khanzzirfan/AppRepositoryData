namespace TheResturantApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeforiegnkeyreference : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.menu", "MenuCategory_ID", "dbo.menu_category");
            //DropForeignKey("dbo.menu", "menu_type_id", "dbo.menu_type");
            //DropIndex("dbo.menu", new[] { "menu_type_id" });
            //DropIndex("dbo.menu", new[] { "MenuCategory_ID" });
            //DropColumn("dbo.menu", "MenuCategory_ID");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.menu", "MenuCategory_ID", c => c.Decimal(precision: 18, scale: 2));
            //CreateIndex("dbo.menu", "MenuCategory_ID");
            //CreateIndex("dbo.menu", "menu_type_id");
            //AddForeignKey("dbo.menu", "menu_type_id", "dbo.menu_type", "menu_type_id", cascadeDelete: true);
            //AddForeignKey("dbo.menu", "MenuCategory_ID", "dbo.menu_category", "category_id");
        }
    }
}
