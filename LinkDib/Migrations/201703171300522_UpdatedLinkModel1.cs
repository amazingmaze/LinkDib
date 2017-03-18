namespace LinkDib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedLinkModel1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Links", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Links", new[] { "User_Id" });
            AddColumn("dbo.Links", "UserId", c => c.String(nullable: false));
            DropColumn("dbo.Links", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Links", "User_Id", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Links", "UserId");
            CreateIndex("dbo.Links", "User_Id");
            AddForeignKey("dbo.Links", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
