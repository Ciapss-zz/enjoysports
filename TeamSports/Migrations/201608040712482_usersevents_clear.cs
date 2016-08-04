namespace TeamSports.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usersevents_clear : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.UserEvents");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserEvents",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        UserID = c.String(),
                        EventID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
    }
}
