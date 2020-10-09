namespace AltranSIWallet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixNameProjectManagerEntity : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Projects", "ProjectManagerId");
            RenameColumn(table: "dbo.Projects", name: "ProjectManger_Id", newName: "ProjectManagerId");
            RenameIndex(table: "dbo.Projects", name: "IX_ProjectManger_Id", newName: "IX_ProjectManagerId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Projects", name: "IX_ProjectManagerId", newName: "IX_ProjectManger_Id");
            RenameColumn(table: "dbo.Projects", name: "ProjectManagerId", newName: "ProjectManger_Id");
            AddColumn("dbo.Projects", "ProjectManagerId", c => c.Int());
        }
    }
}
