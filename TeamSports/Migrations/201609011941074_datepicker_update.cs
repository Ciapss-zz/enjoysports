namespace TeamSports.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datepicker_update : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "EventTime", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "EventTime", c => c.String());
        }
    }
}
