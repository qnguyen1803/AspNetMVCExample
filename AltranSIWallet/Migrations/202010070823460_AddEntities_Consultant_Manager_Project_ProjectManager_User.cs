namespace AltranSIWallet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEntities_Consultant_Manager_Project_ProjectManager_User : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Consultants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Level = c.Int(nullable: false),
                        SkillsFile = c.String(),
                        UserId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        ManagerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Managers", t => t.ManagerId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ProjectId)
                .Index(t => t.ManagerId);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectObj_Id)
                .ForeignKey("dbo.ProjectManagers", t => t.ProjectManagerId, cascadeDelete: true)
                .Index(t => t.ProjectManagerId)
                .Index(t => t.ProjectObj_Id);
            
            CreateTable(
                "dbo.ProjectManagers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectManagers", "UserId", "dbo.Users");
            DropForeignKey("dbo.Projects", "ProjectManagerId", "dbo.ProjectManagers");
            DropForeignKey("dbo.Consultants", "UserId", "dbo.Users");
            DropForeignKey("dbo.Projects", "ProjectObj_Id", "dbo.Projects");
            DropForeignKey("dbo.Consultants", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Managers", "UserId", "dbo.Users");
            DropForeignKey("dbo.Consultants", "ManagerId", "dbo.Managers");
            DropIndex("dbo.ProjectManagers", new[] { "UserId" });
            DropIndex("dbo.Projects", new[] { "ProjectObj_Id" });
            DropIndex("dbo.Projects", new[] { "ProjectManagerId" });
            DropIndex("dbo.Managers", new[] { "UserId" });
            DropIndex("dbo.Consultants", new[] { "ManagerId" });
            DropIndex("dbo.Consultants", new[] { "ProjectId" });
            DropIndex("dbo.Consultants", new[] { "UserId" });
            DropTable("dbo.ProjectManagers");
            DropTable("dbo.Projects");
            DropTable("dbo.Users");
            DropTable("dbo.Managers");
            DropTable("dbo.Consultants");
        }
    }
}
