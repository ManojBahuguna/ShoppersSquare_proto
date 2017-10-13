namespace ShoppersSquare_proto.Migrations
{
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
            context.Categories.SqlQuery(@"
                INSERT INTO [dbo].[ProductTypes] ([Id], [Name], [ImageUrl]) VALUES (0, N'Electronics', N'https://afatrading.co.ke/images/home.jpg')
                INSERT INTO [dbo].[ProductTypes] ([Id], [Name], [ImageUrl]) VALUES (1, N'Home and Furniture', N'http://rizshops.com/images/furn1.jpg')
                INSERT INTO [dbo].[ProductTypes] ([Id], [Name], [ImageUrl]) VALUES (2, N'Clothing and Accesories', N'http://www.summerhillbaths.co.uk/includes/templates/summerhillbaths//images/banner.jpg')
                INSERT INTO [dbo].[ProductTypes] ([Id], [Name], [ImageUrl]) VALUES (3, N'Footwear', N'http://www.florsheim.com/shop/resources/images/index/index1-125-banner.jpg')
                INSERT INTO [dbo].[ProductTypes] ([Id], [Name], [ImageUrl]) VALUES (4, N'Beauty and Personal Care', N'https://www.latestinbeauty.com/pub/static/frontend/lib/iammee/en_GB/Lib_IammeeCatalog/images/all-banner.jpg')
            ");
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
