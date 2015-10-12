namespace TheResturantApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedforiegnCustomerReference : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.orders", "Customer_CustomerId", "dbo.customer");
            //DropIndex("dbo.orders", new[] { "Customer_CustomerId" });
            //DropColumn("dbo.orders", "Customer_CustomerId");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.orders", "Customer_CustomerId", c => c.Decimal(precision: 18, scale: 2));
            //CreateIndex("dbo.orders", "Customer_CustomerId");
            //AddForeignKey("dbo.orders", "Customer_CustomerId", "dbo.customer", "customer_id");
        }
    }
}
