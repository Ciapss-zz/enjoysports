namespace TeamSports.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_cities : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Events", new[] { "LevelId" });
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Events", "CityID", c => c.Guid(nullable: false));
            CreateIndex("dbo.Events", "CityID");
            CreateIndex("dbo.Events", "LevelID");
            AddForeignKey("dbo.Events", "CityID", "dbo.Cities", "ID", cascadeDelete: true);
            DropColumn("dbo.Events", "Place");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "Place", c => c.String());
            DropForeignKey("dbo.Events", "CityID", "dbo.Cities");
            DropIndex("dbo.Events", new[] { "LevelID" });
            DropIndex("dbo.Events", new[] { "CityID" });
            DropColumn("dbo.Events", "CityID");
            DropTable("dbo.Cities");
            CreateIndex("dbo.Events", "LevelId");
        }
    }
}
