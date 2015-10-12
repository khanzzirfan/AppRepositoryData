namespace TheResturantApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMenuTabless : DbMigration
    {
        public override void Up()
        {
            /***
            RenameColumn(table: "dbo.orders", name: "CustomerId", newName: "order_discount");
            RenameColumn(table: "dbo.orders", name: "TotalAmount", newName: "order_total_amount");
            RenameColumn(table: "dbo.orders", name: "TaxAmount", newName: "order_tax_amount");
            RenameColumn(table: "dbo.orders", name: "NetAmount", newName: "net_amount");
            RenameColumn(table: "dbo.orders", name: "InsertDateTime", newName: "insert_datetime");
            RenameColumn(table: "dbo.orders", name: "InsertProcess", newName: "insert_process");
            RenameColumn(table: "dbo.orders", name: "InsertUser", newName: "insert_user");
            RenameColumn(table: "dbo.orders", name: "UpdateDateTime", newName: "update_datetime");
            RenameColumn(table: "dbo.orders", name: "UpdateProcess", newName: "update_process");
            DropPrimaryKey("dbo.customer");
            DropPrimaryKey("dbo.orders");
            CreateTable(
                "dbo.menu_type",
                c => new
                    {
                        menu_type_id = c.Decimal(nullable: false, precision: 18, scale: 2, identity: true),
                        menu_type = c.String(nullable: false, maxLength: 100),
                        active = c.String(maxLength: 1),
                        insert_datetime = c.DateTime(nullable: false),
                        insert_user = c.String(maxLength: 100),
                        insert_process = c.String(maxLength: 100),
                        update_datetime = c.DateTime(nullable: false),
                        update_user = c.String(maxLength: 100),
                        update_process = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.menu_type_id);
            
            CreateTable(
                "dbo.menu",
                c => new
                    {
                        menu_id = c.Decimal(nullable: false, precision: 18, scale: 2, identity: true),
                        menu_name = c.String(nullable: false, maxLength: 100),
                        menu_description = c.String(nullable: false, maxLength: 100),
                        menu_type_id = c.Int(nullable: false),
                        menu_category_id = c.Int(nullable: false),
                        menu_price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        active = c.String(maxLength: 1),
                        insert_datetime = c.DateTime(nullable: false),
                        insert_user = c.String(maxLength: 100),
                        insert_process = c.String(maxLength: 100),
                        update_datetime = c.DateTime(nullable: false),
                        update_user = c.String(maxLength: 100),
                        update_process = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.menu_id);
            
            AddColumn("dbo.orders", "order_id", c => c.Decimal(nullable: false, precision: 18, scale: 2, identity: true));
            AddColumn("dbo.orders", "OrderName", c => c.String(maxLength: 100));
            AddColumn("dbo.orders", "OrderDate", c => c.DateTime());
            AddColumn("dbo.orders", "RequiredDate", c => c.DateTime());
            AddColumn("dbo.orders", "OrderComplete", c => c.DateTime());
            AddColumn("dbo.orders", "Discount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.orders", "Active", c => c.String(maxLength: 1));
            AddColumn("dbo.orders", "update_user", c => c.String(maxLength: 100));
            AddColumn("dbo.orders", "Customer_CustomerId", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.customer", "customer_id", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.orders", "insert_process", c => c.String(maxLength: 100));
            AlterColumn("dbo.orders", "insert_user", c => c.String(maxLength: 100));
            AlterColumn("dbo.orders", "update_datetime", c => c.DateTime(nullable: false));
            AddPrimaryKey("dbo.customer", "customer_id");
            AddPrimaryKey("dbo.orders", "order_id");
            CreateIndex("dbo.orders", "Customer_CustomerId");
            AddForeignKey("dbo.orders", "Customer_CustomerId", "dbo.customer", "customer_id");
            DropColumn("dbo.orders", "Id");
            DropColumn("dbo.orders", "Updateuser");

    *******/
        }
        
        public override void Down()
        {
            /***
            AddColumn("dbo.orders", "Updateuser", c => c.String(maxLength: 100));
            AddColumn("dbo.orders", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.orders", "Customer_CustomerId", "dbo.customer");
            DropIndex("dbo.orders", new[] { "Customer_CustomerId" });
            DropPrimaryKey("dbo.orders");
            DropPrimaryKey("dbo.customer");
            AlterColumn("dbo.orders", "update_datetime", c => c.DateTime());
            AlterColumn("dbo.orders", "insert_user", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.orders", "insert_process", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.customer", "customer_id", c => c.Int(nullable: false));
            DropColumn("dbo.orders", "Customer_CustomerId");
            DropColumn("dbo.orders", "update_user");
            DropColumn("dbo.orders", "Active");
            DropColumn("dbo.orders", "Discount");
            DropColumn("dbo.orders", "OrderComplete");
            DropColumn("dbo.orders", "RequiredDate");
            DropColumn("dbo.orders", "OrderDate");
            DropColumn("dbo.orders", "OrderName");
            DropColumn("dbo.orders", "order_id");
            DropTable("dbo.menu");
            DropTable("dbo.menu_type");
            AddPrimaryKey("dbo.orders", "Id");
            AddPrimaryKey("dbo.customer", "customer_id");
            RenameColumn(table: "dbo.orders", name: "update_process", newName: "UpdateProcess");
            RenameColumn(table: "dbo.orders", name: "update_datetime", newName: "UpdateDateTime");
            RenameColumn(table: "dbo.orders", name: "insert_user", newName: "InsertUser");
            RenameColumn(table: "dbo.orders", name: "insert_process", newName: "InsertProcess");
            RenameColumn(table: "dbo.orders", name: "insert_datetime", newName: "InsertDateTime");
            RenameColumn(table: "dbo.orders", name: "net_amount", newName: "NetAmount");
            RenameColumn(table: "dbo.orders", name: "order_tax_amount", newName: "TaxAmount");
            RenameColumn(table: "dbo.orders", name: "order_total_amount", newName: "TotalAmount");
            RenameColumn(table: "dbo.orders", name: "order_discount", newName: "CustomerId");
            *********/
        }
    }
}
