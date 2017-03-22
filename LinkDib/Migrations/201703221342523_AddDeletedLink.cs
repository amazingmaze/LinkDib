namespace LinkDib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDeletedLink : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Links", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Links", "IsDeleted");
        }
    }
}
