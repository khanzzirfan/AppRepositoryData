using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using TheResturantApp.Models.Mapping;

namespace TheResturantApp.Models
{
    public class TRAContext : IdentityDbContext<IdentityUser>
    {
        //private string schemaName = "irfank";
        public TRAContext()
            : base("name=TRAContext")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuType> MenuTypes { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Entity<Customer>().ToTable("customer");

            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Entity<Order>().ToTable("orders");

            modelBuilder.Configurations.Add(new MenuTypeMap());
            modelBuilder.Entity<MenuType>().ToTable("menu_type");

          
            modelBuilder.Configurations.Add(new MenuMap());
            modelBuilder.Entity<Menu>().ToTable("menu");

            modelBuilder.Configurations.Add(new MenuCategoryMap());
            modelBuilder.Entity<MenuCategory>().ToTable("menu_category");

            modelBuilder.Configurations.Add(new TransactionMap());
            modelBuilder.Entity<Transactions>().ToTable("order_transaction");
            //Setup Stoed Procedures
            
            modelBuilder.Configurations.Add(new ReservationMap());
            modelBuilder.Entity<Reservation>().ToTable("reservation");

            modelBuilder.Configurations.Add(new UserModelMap());
            modelBuilder.Entity<UserModel>().ToTable("user_login");
            
        }

    }
}