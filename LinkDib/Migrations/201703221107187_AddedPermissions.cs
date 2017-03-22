namespace LinkDib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPermissions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Links", "Permission", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Links", "Permission");
        }
    }
}
