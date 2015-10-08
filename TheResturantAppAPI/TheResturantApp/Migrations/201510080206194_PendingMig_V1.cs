namespace TheResturantApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PendingMig_V1 : DbMigration
    {
        public override void Up()
        {
            //RenameColumn(table: "dbo.menu_type", name: "menu_type", newName: "name");
        }
        
        public override void Down()
        {
           // RenameColumn(table: "dbo.menu_type", name: "name", newName: "menu_type");
        }
    }
}
