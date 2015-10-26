namespace TheResturantApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class restoBuilds : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.resto_build",
            //    c => new
            //        {
            //            ID = c.Decimal(nullable: false, precision: 18, scale: 2, identity: true),
            //            build_version = c.String(),
            //            build_date = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
         //   DropTable("dbo.resto_build");
        }
    }
}
