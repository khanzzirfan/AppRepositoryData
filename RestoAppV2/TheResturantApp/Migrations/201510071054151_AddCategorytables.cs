namespace TheResturantApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategorytables : DbMigration
    {
        public override void Up()
        {
            /***
            CreateTable(
                "dbo.menu_category",
                c => new
                    {
                        category_id = c.Decimal(nullable: false, precision: 18, scale: 2, identity: true),
                        category_name = c.String(nullable: false, maxLength: 100),
                        active = c.String(maxLength: 1),
                        insert_datetime = c.DateTime(nullable: false),
                        insert_user = c.String(maxLength: 100),
                        insert_process = c.String(maxLength: 100),
                        update_datetime = c.DateTime(nullable: false),
                        update_user = c.String(maxLength: 100),
                        update_process = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.category_id);
            *******/
        }
        
        public override void Down()
        {
            //DropTable("dbo.menu_category");
        }
    }
}
