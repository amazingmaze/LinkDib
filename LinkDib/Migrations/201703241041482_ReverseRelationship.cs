namespace LinkDib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReverseRelationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserNotifications", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserNotifications", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.UserNotifications", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserNotifications", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.UserNotifications", "ApplicationUser_Id");
            AddForeignKey("dbo.UserNotifications", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
