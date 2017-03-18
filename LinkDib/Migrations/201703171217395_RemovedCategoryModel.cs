namespace LinkDib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedCategoryModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Links", "LinkCategory_Id", "dbo.LinkCategories");
            DropIndex("dbo.Links", new[] { "LinkCategory_Id" });
            AddColumn("dbo.Links", "LinkCategory", c => c.String());
            DropColumn("dbo.Links", "LinkCategory_Id");
            DropTable("dbo.LinkCategories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.LinkCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Links", "LinkCategory_Id", c => c.Int());
            DropColumn("dbo.Links", "LinkCategory");
            CreateIndex("dbo.Links", "LinkCategory_Id");
            AddForeignKey("dbo.Links", "LinkCategory_Id", "dbo.LinkCategories", "Id");
        }
    }
}
