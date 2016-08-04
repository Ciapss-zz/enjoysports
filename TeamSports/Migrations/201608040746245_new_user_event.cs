namespace TeamSports.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_user_event : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserEvents",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        EventID = c.Guid(nullable: false),
                        UserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Events", t => t.EventID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.EventID)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserEvents", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserEvents", "EventID", "dbo.Events");
            DropIndex("dbo.UserEvents", new[] { "UserID" });
            DropIndex("dbo.UserEvents", new[] { "EventID" });
            DropTable("dbo.UserEvents");
        }
    }
}
