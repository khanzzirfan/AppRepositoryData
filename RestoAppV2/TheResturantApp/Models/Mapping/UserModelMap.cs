using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheResturantApp.Models.Mapping
{
    public class UserModelMap : EntityTypeConfiguration<UserModel>
    {
        public UserModelMap()
        {
            //Primary key
            this.HasKey(t => t.ID);

            //
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //Table and Column Mappings;
            this.ToTable("user_login");
            this.Property(t => t.ID).HasColumnName("id");
            this.Property(t => t.Name).HasColumnName("user_name");
            this.Property(t => t.Role).HasColumnName("user_role");

            this.Property(t => t.PasswordHash).HasColumnName("password_hash");
            this.Property(t => t.PasswordRevision).HasColumnName("password_revision");
            this.Property(t => t.ResetKey).HasColumnName("reset_key");

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

