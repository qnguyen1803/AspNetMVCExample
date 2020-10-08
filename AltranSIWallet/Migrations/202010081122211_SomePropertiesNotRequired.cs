namespace AltranSIWallet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomePropertiesNotRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Salary", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Users", "EntryDate", c => c.DateTime());
            AlterColumn("dbo.Projects", "ProjectManagerId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projects", "ProjectManagerId", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "EntryDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "Salary", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
