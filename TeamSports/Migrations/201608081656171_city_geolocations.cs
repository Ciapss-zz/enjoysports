namespace TeamSports.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class city_geolocations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cities", "GeoLat", c => c.String());
            AddColumn("dbo.Cities", "GeoLng", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cities", "GeoLng");
            DropColumn("dbo.Cities", "GeoLat");
        }
    }
}
