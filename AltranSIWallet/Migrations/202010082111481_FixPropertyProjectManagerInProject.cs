namespace AltranSIWallet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixPropertyProjectManagerInProject : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projects", "ProjectObj_Id", "dbo.Projects");
            DropIndex("dbo.Projects", new[] { "ProjectObj_Id" });
            DropColumn("dbo.Projects", "ProjectObj_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "ProjectObj_Id", c => c.Int());
            CreateIndex("dbo.Projects", "ProjectObj_Id");
            AddForeignKey("dbo.Projects", "ProjectObj_Id", "dbo.Projects", "Id");
        }
    }
}
