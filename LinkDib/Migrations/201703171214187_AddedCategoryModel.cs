namespace LinkDib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCategoryModel : DbMigration
    {
        public override void Up()
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
            CreateIndex("dbo.Links", "LinkCategory_Id");
            AddForeignKey("dbo.Links", "LinkCategory_Id", "dbo.LinkCategories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Links", "LinkCategory_Id", "dbo.LinkCategories");
            DropIndex("dbo.Links", new[] { "LinkCategory_Id" });
            DropColumn("dbo.Links", "LinkCategory_Id");
            DropTable("dbo.LinkCategories");
        }
    }
}
