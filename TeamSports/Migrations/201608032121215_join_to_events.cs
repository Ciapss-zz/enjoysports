namespace TeamSports.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class join_to_events : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "MaxSlots", c => c.Int(nullable: false));
            AddColumn("dbo.Events", "AvailableSlots", c => c.Int(nullable: false));
            AddColumn("dbo.Events", "CurrentSlots", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "CurrentSlots");
            DropColumn("dbo.Events", "AvailableSlots");
            DropColumn("dbo.Events", "MaxSlots");
        }
    }
}
