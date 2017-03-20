using LinkDib.Models;

namespace LinkDib.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LinkDib.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LinkDib.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //var category1 = new Category
            //{
            //    Name = "News"
            //};
            //var category2 = new Category
            //{
            //    Name = "Information/Data"
            //};

            //context.Categories.AddOrUpdate(category1);
            //context.Categories.AddOrUpdate(category2);
            //context.SaveChanges();

            //var link1 = new Link
            //{
            //    UserId = "4e059acd-e772-4dce-89b1-c04cf770d95c",
            //    Url = "http://www.google.se",
            //    Message = "Look at this!",
            //    CategoryId = category2.Id,
            //    DateTime = DateTime.Now
            //};

            //var link2 = new Link
            //{
            //    UserId = "4e059acd-e772-4dce-89b1-c04cf770d95c",
            //    Url = "http://www.aftonbladet.se",
            //    Message = "News!",
            //    CategoryId = category1.Id,
            //    DateTime = DateTime.Now
            //};


            //context.Links.AddOrUpdate(link1);
            //context.Links.AddOrUpdate(link2);
            //context.SaveChanges();
        }
    }
}
