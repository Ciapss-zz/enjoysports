namespace TeamSports.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatorID_as_string : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "CreatorID", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "CreatorID", c => c.Int(nullable: false));
        }
    }
}
