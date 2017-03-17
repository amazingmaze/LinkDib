namespace LinkDib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLinkAndLinkMessage2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LinkMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Links", "Message_Id", c => c.Int());
            CreateIndex("dbo.Links", "Message_Id");
            AddForeignKey("dbo.Links", "Message_Id", "dbo.LinkMessages", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Links", "Message_Id", "dbo.LinkMessages");
            DropIndex("dbo.Links", new[] { "Message_Id" });
            DropColumn("dbo.Links", "Message_Id");
            DropTable("dbo.LinkMessages");
        }
    }
}
