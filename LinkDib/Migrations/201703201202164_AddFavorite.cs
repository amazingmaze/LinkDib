namespace LinkDib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFavorite : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Favorites",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LinkId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.LinkId })
                .ForeignKey("dbo.Links", t => t.LinkId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.LinkId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Favorites", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Favorites", "LinkId", "dbo.Links");
            DropIndex("dbo.Favorites", new[] { "LinkId" });
            DropIndex("dbo.Favorites", new[] { "UserId" });
            DropTable("dbo.Favorites");
        }
    }
}
