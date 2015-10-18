using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheResturantApp.Models.Mapping
{
    public class TransactionMap: EntityTypeConfiguration<Transactions>
    {
        public TransactionMap()
        {
            //Primary key
            this.HasKey(t => t.ID);

            //
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //Table and Column Mappings;
            this.ToTable("order_transaction");
            this.Property(t => t.ID).HasColumnName("transaction_id");

            this.Property(t => t.OrderID).HasColumnName("order_id");
            this.Property(t => t.MenuID).HasColumnName("menu_id");
            this.Property(t => t.UnitPrice).HasColumnName("unit_price");

            this.Property(t => t.Quantity).HasColumnName("quantity");
            this.Property(t => t.Discount).HasColumnName("discount");
            this.Property(t => t.OrderAmount).HasColumnName("amount");
            this.Property(t => t.PricePlanId).HasColumnName("price_plan_id");
            this.Property(t => t.Comments).HasColumnName("Comments");


            //Audit Fields always
            this.Property(t => t.Active).HasColumnName("active");
            this.Property(t => t.InsertDateTime).HasColumnName("insert_datetime");
            this.Property(t => t.UpdateDateTime).HasColumnName("update_datetime");

            this.Property(t => t.InsertProcess).HasColumnName("insert_process");
            this.Property(t => t.UpdateProcess).HasColumnName("update_process");
            this.Property(t => t.InsertUser).HasColumnName("insert_user");
            this.Property(t => t.UpdateUser).HasColumnName("update_user");


        }
    }
}
