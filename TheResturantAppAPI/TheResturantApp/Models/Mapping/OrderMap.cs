using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheResturantApp.Models.Mapping
{
    public class OrderMap:EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            //Primary key
            this.HasKey(t => t.Id);
            this.Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.ToTable("orders");
            this.Property(t => t.Id).HasColumnName("order_id");
            this.Property(t => t.CustomerId).HasColumnName("customer_id");

            this.Property(t => t.CustomerId).HasColumnName("order_name");
            this.Property(t => t.CustomerId).HasColumnName("order_date");
            this.Property(t => t.CustomerId).HasColumnName("required_date");
            this.Property(t => t.CustomerId).HasColumnName("order_complete");
            this.Property(t => t.CustomerId).HasColumnName("comments");
            this.Property(t => t.CustomerId).HasColumnName("order_discount");



            this.Property(t => t.TotalAmount).HasColumnName("order_total_amount");
            this.Property(t => t.TaxAmount).HasColumnName("tax_amount");

            this.Property(t => t.NetAmount).HasColumnName("net_amount");
            this.Property(t => t.Comments).HasColumnName("comments");

            this.Property(t => t.InsertDateTime).HasColumnName("insert_datetime");
            this.Property(t => t.UpdateDateTime).HasColumnName("update_datetime");

            this.Property(t => t.InsertProcess).HasColumnName("insert_process");
            this.Property(t => t.UpdateProcess).HasColumnName("update_process");

            this.Property(t => t.InsertUser).HasColumnName("insert_user");
            this.Property(t => t.Updateuser).HasColumnName("update_user");


        }

    }
}
