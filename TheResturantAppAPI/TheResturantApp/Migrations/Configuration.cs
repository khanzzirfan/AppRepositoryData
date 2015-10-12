namespace TheResturantApp.Migrations
{
    using Microsoft.AspNet.Identity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Threading.Tasks;
    using TheResturantApp.Models;
    using Microsoft.AspNet.Identity.EntityFramework;


    internal sealed class Configuration : DbMigrationsConfiguration<TheResturantApp.Models.TRAContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TheResturantApp.Models.TRAContext context)
        {
            Console.WriteLine("Executing Add User Method");
            var username = "Irfank";
            var manager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(new TRAContext()));
            var userlogin = new IdentityUser()
            {
                UserName = username,
            };

            var userExists = context.Users.Any(c => c.UserName == username);

            if(!userExists)
                manager.Create(userlogin, "Green0987");

        }
    }
}
