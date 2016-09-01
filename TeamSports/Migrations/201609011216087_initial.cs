namespace TeamSports.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        GeoLat = c.String(),
                        GeoLng = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Description = c.String(),
                        MaxSlots = c.Int(nullable: false),
                        AvailableSlots = c.Int(nullable: false),
                        CurrentSlots = c.Int(nullable: false),
                        GeoLat = c.String(),
                        GeoLng = c.String(),
                        EventDate = c.DateTime(nullable: false),
                        EventTime = c.String(),
                        CityID = c.Guid(nullable: false),
                        Owner = c.String(maxLength: 128),
                        SportID = c.Guid(nullable: false),
                        LevelID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Cities", t => t.CityID, cascadeDelete: true)
                .ForeignKey("dbo.Levels", t => t.LevelID, cascadeDelete: true)
                .ForeignKey("dbo.Sports", t => t.SportID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Owner)
                .Index(t => t.CityID)
                .Index(t => t.Owner)
                .Index(t => t.SportID)
                .Index(t => t.LevelID);
            
            CreateTable(
                "dbo.Levels",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Sports",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.UserEvents", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserEvents", "EventID", "dbo.Events");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Events", "Owner", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Events", "SportID", "dbo.Sports");
            DropForeignKey("dbo.Events", "LevelID", "dbo.Levels");
            DropForeignKey("dbo.Events", "CityID", "dbo.Cities");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.UserEvents", new[] { "UserID" });
            DropIndex("dbo.UserEvents", new[] { "EventID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Events", new[] { "LevelID" });
            DropIndex("dbo.Events", new[] { "SportID" });
            DropIndex("dbo.Events", new[] { "Owner" });
            DropIndex("dbo.Events", new[] { "CityID" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.UserEvents");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Sports");
            DropTable("dbo.Levels");
            DropTable("dbo.Events");
            DropTable("dbo.Cities");
        }
    }
}
