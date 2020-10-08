namespace AltranSIWallet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManagerIdUserIdNotRequired : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Profils", "UserId", "dbo.Users");
            DropForeignKey("dbo.Profils", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Profils", new[] { "UserId" });
            AlterColumn("dbo.Profils", "UserId", c => c.Int());
            CreateIndex("dbo.Profils", "UserId");
            AddForeignKey("dbo.Profils", "UserId", "dbo.Users", "Id");
            AddForeignKey("dbo.Profils", "ProjectId", "dbo.Projects", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Profils", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Profils", "UserId", "dbo.Users");
            DropIndex("dbo.Profils", new[] { "UserId" });
            AlterColumn("dbo.Profils", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Profils", "UserId");
            AddForeignKey("dbo.Profils", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Profils", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
