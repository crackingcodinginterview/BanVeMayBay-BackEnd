namespace BanVeMayBay.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BanVeMayBay.DataContexts.AirticketDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BanVeMayBay.DataContexts.AirticketDataContext context)
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
            var airroute = new Airroute { Code = "GGG" };
            var airport = new Airport { Code = "AAA", Name = "San Bay HCM", Airroutes = new List<Airroute> { airroute } };
            context.Airport.Add(airport);
            context.Airroute.Add(airroute);
        }
    }
}
