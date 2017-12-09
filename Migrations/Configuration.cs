namespace ChoreScore.Migrations
{
    using ChoreScore.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ChoreScore.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ChoreScore.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var adminRole = new IdentityRole("Admin");
            context.Roles.AddOrUpdate(r => r.Name, adminRole);

            context.SaveChanges();

            var user = new ApplicationUser
            {
                UserName = "marcus",
                Email = "jmarcusgill@gmail.com"
            };

            userManager.CreateAsync(user, "password").Wait();

            var addedUser = context.Users.First(x => x.UserName == user.UserName);

            userManager.AddToRoleAsync(addedUser.Id, "Admin").Wait();
        }
    }
}
