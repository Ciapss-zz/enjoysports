namespace TeamSports.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class another_date_update : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "EventDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "EventDate", c => c.DateTime(nullable: false));
        }
    }
}
