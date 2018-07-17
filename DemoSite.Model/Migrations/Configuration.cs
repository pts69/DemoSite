using DemoSite.Model.Entities;

namespace DemoSite.Model.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DemoSite.Model.MyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DemoSite.Model.MyDbContext context)
        {

            context.Vehicles.AddOrUpdate(
                x => x.VehicleId,
                new Vehicle { VehicleId = 1, RegistrationNo = "Car 1" },
                new Vehicle { VehicleId = 2, RegistrationNo = "Car 2" },
                new Vehicle { VehicleId = 3, RegistrationNo = "Car 3" }

            );

        }
    }
}
