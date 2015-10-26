using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheResturantApp.Models.Mapping
{
    public class RestoBuildMap : EntityTypeConfiguration<RestoBuild>
    {
        public RestoBuildMap()
        {
            //Table and Column Mappings;
            //Primary key
            this.HasKey(t => t.ID);
            this.Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.ToTable("resto_build");
            this.Property(t => t.BuildVersion).HasColumnName("build_version");
            this.Property(t => t.BuildDate).HasColumnName("build_date");
        }
    }
}
