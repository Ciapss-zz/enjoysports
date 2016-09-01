namespace TeamSports.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TeamSports.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TeamSports.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TeamSports.Models.ApplicationDbContext context)
        {
            context.Cities.AddOrUpdate(x => x.ID,
                new City() { ID = Guid.NewGuid(), Name = "Basel", GeoLat = "47.559765", GeoLng = "7.587936" },
                new City() { ID = Guid.NewGuid(), Name = "Bern", GeoLat = "46.948321", GeoLng = "7.447740" },
                new City() { ID = Guid.NewGuid(), Name = "Biel/Bienne", GeoLat = "47.137015", GeoLng = "7.246635" },
                new City() { ID = Guid.NewGuid(), Name = "Geneva", GeoLat = "46.204430", GeoLng = "6.143058" },
                new City() { ID = Guid.NewGuid(), Name = "Lausanne", GeoLat = "46.519520", GeoLng = "6.631550" },
                new City() { ID = Guid.NewGuid(), Name = "Lucerne", GeoLat = "47.049720", GeoLng = "8.306680" },
                new City() { ID = Guid.NewGuid(), Name = "St. Gallen", GeoLat = "47.424060", GeoLng = "9.377446" },
                new City() { ID = Guid.NewGuid(), Name = "Winterthur", GeoLat = "47.499716", GeoLng = "8.724277" },
                new City() { ID = Guid.NewGuid(), Name = "Zurich", GeoLat = "47.376969", GeoLng = "8.540490" }
                );
            context.Levels.AddOrUpdate(x => x.ID,
                new Level() { ID = Guid.NewGuid(), Name = "Beginner" },
                new Level() { ID = Guid.NewGuid(), Name = "Intermediate" },
                new Level() { ID = Guid.NewGuid(), Name = "Professional" }
                );
            context.Sports.AddOrUpdate(x => x.ID,
                new Sport() { ID = Guid.NewGuid(), Name = "Tennis" },
                new Sport() { ID = Guid.NewGuid(), Name = "Golf" },
                new Sport() { ID = Guid.NewGuid(), Name = "Football" },
                new Sport() { ID = Guid.NewGuid(), Name = "Basketball" },
                new Sport() { ID = Guid.NewGuid(), Name = "Voleyball" },
                new Sport() { ID = Guid.NewGuid(), Name = "Baseball" },
                new Sport() { ID = Guid.NewGuid(), Name = "Running" },
                new Sport() { ID = Guid.NewGuid(), Name = "Cycling" },
                new Sport() { ID = Guid.NewGuid(), Name = "Mountain Biking" }
                );
        }
    }
}
