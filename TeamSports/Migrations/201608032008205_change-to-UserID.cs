namespace TeamSports.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changetoUserID : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Events", name: "User_Id", newName: "UserID");
            RenameIndex(table: "dbo.Events", name: "IX_User_Id", newName: "IX_UserID");
            DropColumn("dbo.Events", "CreatorID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "CreatorID", c => c.String());
            RenameIndex(table: "dbo.Events", name: "IX_UserID", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Events", name: "UserID", newName: "User_Id");
        }
    }
}
