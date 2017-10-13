namespace ShoppersSquare_proto.Migrations
{
    using ShoppersSquare_proto.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;

    internal sealed class Configuration : DbMigrationsConfiguration<ShoppersSquare_proto.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "ShoppersSquare_proto.Models.ApplicationDbContext";
        }

        protected override void Seed(ShoppersSquare_proto.Models.ApplicationDbContext context)
        {
            context.Categories.AddOrUpdate(c => c.Name,
                new ProductType { Id = 0, Name = "Electronics", ImageUrl = "https://afatrading.co.ke/images/home.jpg" },
                new ProductType { Id = 1, Name = "Home and Furniture", ImageUrl = "http://rizshops.com/images/furn1.jpg" },
                new ProductType { Id = 2, Name = "Clothing and Accesories", ImageUrl = "http://www.summerhillbaths.co.uk/includes/templates/summerhillbaths//images/banner.jpg" },
                new ProductType { Id = 3, Name = "Footwear", ImageUrl = "http://www.florsheim.com/shop/resources/images/index/index1-125-banner.jpg" },
                new ProductType { Id = 4, Name = "Beauty and Personal Care", ImageUrl = "https://www.latestinbeauty.com/pub/static/frontend/lib/iammee/en_GB/Lib_IammeeCatalog/images/all-banner.jpg" }
            );
            //var storeManagerRole = "StoreManager";
            //var userEmail = "storemanager@shoppers.square";
            //var userPassword = "monoTHEmanager";


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
        }
    }
}
