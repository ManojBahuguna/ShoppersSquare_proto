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
                new ProductType { Id = 0, Name = "Electronics", ImageUrl = "http://www.nashikfame.com/wp-content/uploads/2017/02/trison-article-slider.jpg" },
                new ProductType { Id = 1, Name = "Home and Furniture", ImageUrl = "https://www.kimball.com/getmedia/de7a7f5a-ce84-406c-a4a5-636dde8acc4a/Desks_Main_Priority.aspx" },
                new ProductType { Id = 2, Name = "Clothing and Accesories", ImageUrl = "https://newyorkfashiongh.com/wp-content/uploads/2017/09/o-TRADING-CLOTHES-facebook.jpg" },
                new ProductType { Id = 3, Name = "Footwear", ImageUrl = "http://www.mywestside.com/images/gallery/womens/Footwear/footwear2_24052016.jpg" },
                new ProductType { Id = 4, Name = "Beauty and Personal Care", ImageUrl = "https://scstylecaster.files.wordpress.com/2016/09/worst-makeup-products.jpg" }
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
