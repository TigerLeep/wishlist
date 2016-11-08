using WishList.Models;

namespace WishList.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WishList.Models.WishListContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WishList.Models.WishListContext context)
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

            context.Users.AddOrUpdate(
                u => u.Name,
                new User() { Name = "Lee" },
                new User() { Name = "Lisa" },
                new User() { Name = "Grandma" },
                new User() { Name = "Crystal" },
                new User() { Name = "Lucas" },
                new User() { Name = "Daniel" },
                new User() { Name = "Matthew" },
                new User() { Name = "Ryan" },
                new User() { Name = "Heather" },
                new User() { Name = "David" },
                new User() { Name = "Jessica" },
                new User() { Name = "Aurora" },
                new User() { Name = "Alanna" }
                );
        }
    }
}
