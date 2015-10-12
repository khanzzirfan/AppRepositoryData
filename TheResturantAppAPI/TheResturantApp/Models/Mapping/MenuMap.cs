using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheResturantApp.Models.Mapping
{
    public class MenuMap : EntityTypeConfiguration<Menu>
    {

        public MenuMap()
        {
            //Primary key
            this.HasKey(t => t.ID);

            //
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //Table and Column Mappings;
            this.ToTable("menu");
            this.Property(t => t.ID).HasColumnName("menu_id");
            this.Property(t => t.Name).HasColumnName("menu_name");
            this.Property(t => t.Description).HasColumnName("menu_description");

            this.Property(t => t.MenuTypeId).HasColumnName("menu_type_id");
            this.Property(t => t.CategoryId).HasColumnName("menu_category_id");
            this.Property(t => t.Price).HasColumnName("menu_price");
            this.Property(t => t.ThumbUrl).HasColumnName("thumb_url");
            this.Property(t => t.LargeUrl).HasColumnName("large_url");
            this.Property(t => t.SmallUrl).HasColumnName("small_url");

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
