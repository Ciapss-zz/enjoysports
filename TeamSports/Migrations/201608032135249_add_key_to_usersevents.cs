namespace TeamSports.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_key_to_usersevents : DbMigration
    {
        public override void Up()
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
        
        public override void Down()
        {
            DropTable("dbo.UserEvents");
        }
    }
}
