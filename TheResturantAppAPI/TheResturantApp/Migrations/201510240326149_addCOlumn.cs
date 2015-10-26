namespace TheResturantApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCOlumn : DbMigration
    {
        public override void Up()
        {
           // AddColumn("dbo.reservation", "customer_uid", c => c.Guid());
        }
        
        public override void Down()
        {
           // DropColumn("dbo.reservation", "customer_uid");
        }
    }
}
