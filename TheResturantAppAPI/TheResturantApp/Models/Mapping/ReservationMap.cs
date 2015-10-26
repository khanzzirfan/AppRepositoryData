using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheResturantApp.Models.Mapping
{
    public class ReservationMap : EntityTypeConfiguration<Reservation>
    {
        public ReservationMap()
        {

            //Primary key
            this.HasKey(t => t.ID);

            //
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //Table and Column Mappings;
            this.ToTable("reservation");
            this.Property(t => t.ID).HasColumnName("reservation_id");
            this.Property(t => t.Name).HasColumnName("name");

            this.Property(t => t.Guests).HasColumnName("guests");
            this.Property(t => t.StatusID).HasColumnName("status_id");
            this.Property(t => t.Email).HasColumnName("email");
            this.Property(t => t.Phone).HasColumnName("phone_number");
            this.Property(t => t.Comments).HasColumnName("comments");

            this.Property(t => t.Date).HasColumnName("start_date");
            this.Property(t => t.Time).HasColumnName("start_time");
            this.Property(t => t.TableID).HasColumnName("table_id");
            this.Property(t => t.CustomerId).HasColumnName("customer_uid");

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
