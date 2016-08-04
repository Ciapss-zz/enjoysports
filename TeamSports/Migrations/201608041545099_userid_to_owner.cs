namespace TeamSports.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userid_to_owner : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Events", name: "UserID", newName: "Owner");
            RenameIndex(table: "dbo.Events", name: "IX_UserID", newName: "IX_Owner");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Events", name: "IX_Owner", newName: "IX_UserID");
            RenameColumn(table: "dbo.Events", name: "Owner", newName: "UserID");
        }
    }
}
