using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheResturantApp.Models.Mapping
{
    public class MenuCategoryMap : EntityTypeConfiguration<MenuCategory>
    {
        public MenuCategoryMap()
        {
            //Primary key
            this.HasKey(t => t.ID);

            //
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //Table and Column Mappings;
            this.ToTable("menu_category");
            this.Property(t => t.ID).HasColumnName("category_id");
            this.Property(t => t.Description).HasColumnName("category_name");

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
