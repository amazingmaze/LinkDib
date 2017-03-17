namespace LinkDib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLinkAndLinkMessage3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Links", "Message_Id", "dbo.LinkMessages");
            DropForeignKey("dbo.Links", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Links", new[] { "Message_Id" });
            DropIndex("dbo.Links", new[] { "User_Id" });
            AlterColumn("dbo.Links", "Url", c => c.String(nullable: false));
            AlterColumn("dbo.Links", "Message_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Links", "User_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.LinkMessages", "Message", c => c.String(nullable: false));
            CreateIndex("dbo.Links", "Message_Id");
            CreateIndex("dbo.Links", "User_Id");
            AddForeignKey("dbo.Links", "Message_Id", "dbo.LinkMessages", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Links", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Links", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Links", "Message_Id", "dbo.LinkMessages");
            DropIndex("dbo.Links", new[] { "User_Id" });
            DropIndex("dbo.Links", new[] { "Message_Id" });
            AlterColumn("dbo.LinkMessages", "Message", c => c.String());
            AlterColumn("dbo.Links", "User_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Links", "Message_Id", c => c.Int());
            AlterColumn("dbo.Links", "Url", c => c.String());
            CreateIndex("dbo.Links", "User_Id");
            CreateIndex("dbo.Links", "Message_Id");
            AddForeignKey("dbo.Links", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Links", "Message_Id", "dbo.LinkMessages", "Id");
        }
    }
}
