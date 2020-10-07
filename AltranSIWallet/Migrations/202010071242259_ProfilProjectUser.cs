namespace AltranSIWallet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProfilProjectUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Profils",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Level = c.Int(),
                        SkillsFile = c.String(),
                        ProjectId = c.Int(),
                        ManagerId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Profils", t => t.ManagerId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ProjectId)
                .Index(t => t.ManagerId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Username = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 100),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EntryDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ProjectManagerId = c.Int(nullable: false),
                        ProjectObj_Id = c.Int(),
                        ProjectManger_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectObj_Id)
                .ForeignKey("dbo.Profils", t => t.ProjectManger_Id)
                .Index(t => t.ProjectObj_Id)
                .Index(t => t.ProjectManger_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "ProjectManger_Id", "dbo.Profils");
            DropForeignKey("dbo.Profils", "UserId", "dbo.Users");
            DropForeignKey("dbo.Projects", "ProjectObj_Id", "dbo.Projects");
            DropForeignKey("dbo.Profils", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Profils", "ManagerId", "dbo.Profils");
            DropIndex("dbo.Projects", new[] { "ProjectManger_Id" });
            DropIndex("dbo.Projects", new[] { "ProjectObj_Id" });
            DropIndex("dbo.Profils", new[] { "ManagerId" });
            DropIndex("dbo.Profils", new[] { "ProjectId" });
            DropIndex("dbo.Profils", new[] { "UserId" });
            DropTable("dbo.Projects");
            DropTable("dbo.Users");
            DropTable("dbo.Profils");
        }
    }
}
