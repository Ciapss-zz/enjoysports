namespace TeamSports.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datepicker_update_string : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "EventDate", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "EventDate", c => c.DateTime(nullable: false));
        }
    }
}
