namespace TeamSports.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class geo_locations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "GeoLat", c => c.String());
            AddColumn("dbo.Events", "GeoLng", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "GeoLng");
            DropColumn("dbo.Events", "GeoLat");
        }
    }
}
