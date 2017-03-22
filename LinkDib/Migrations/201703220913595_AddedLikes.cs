namespace LinkDib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLikes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Links", "UserId", "dbo.AspNetUsers");
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LinkId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.LinkId })
                .ForeignKey("dbo.Links", t => t.LinkId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.LinkId);
            
            AddForeignKey("dbo.Links", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Links", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Likes", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Likes", "LinkId", "dbo.Links");
            DropIndex("dbo.Likes", new[] { "LinkId" });
            DropIndex("dbo.Likes", new[] { "UserId" });
            DropTable("dbo.Likes");
            AddForeignKey("dbo.Links", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
