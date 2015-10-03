using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TheResturantApp.Models.Mapping;

namespace TheResturantApp.Models
{
    public class TRAContext : DbContext
    {
        private string schemaName = "irfank";
        public TRAContext()
            : base("name=TRAContext")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Entity<Customer>().ToTable("customer", schemaName);

            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Entity<Order>().ToTable("orders", schemaName);

            //Setup Stoed Procedures

        }

    }
}