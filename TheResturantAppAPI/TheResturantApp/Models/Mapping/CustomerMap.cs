using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;
using System.Data.Entity.ModelConfiguration;

using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheResturantApp.Models.Mapping
{
    public class CustomerMap:EntityTypeConfiguration<Customer>
    {
        // For customize reverse Enginner templates for Existing database with code first apporach
        //https://msdn.microsoft.com/en-nz/data/jj593170.aspx
        //Also follow this
        //http://www.codeproject.com/Articles/165720/Using-the-Code-First-Model-Configuration-Classes

        //Also more info
        //http://weblogs.asp.net/scottgu/entity-framework-4-code-first-custom-database-schema-mapping


        //this.HashSet(t=> t.)
        public CustomerMap()
        { 
            //Primary key
            this.HasKey(t => t.CustomerId);
            
            //
            this.Property(t => t.CustomerId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            //Table and Column Mappings;
            this.ToTable("customer");
            this.Property(t => t.CustomerId).HasColumnName("customer_id");
            this.Property(t => t.Name).HasColumnName("customer_name");
            this.Property(t => t.Phone).HasColumnName("customer_phone");

            this.Property(t => t.InsertDatetime).HasColumnName("insert_datetime");
            this.Property(t => t.InsertUser).HasColumnName("insert_user");
            this.Property(t => t.InsertProcess).HasColumnName("insert_process");

            this.Property(t => t.UpdateDateTime).HasColumnName("update_datetime");
            this.Property(t => t.UpdateUser).HasColumnName("update_user");
            this.Property(t => t.UpdateProcess).HasColumnName("update_process");



        }
    }
}