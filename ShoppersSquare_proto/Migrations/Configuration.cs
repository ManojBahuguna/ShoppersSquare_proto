namespace ShoppersSquare_proto.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using ShoppersSquare_proto.Models;
    using System.Data.Entity.Migrations;
    using System.Linq;

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
            var storeManagerRoleName = "StoreManager";
            var storeManagerEmail = "storemanager@shoppers.square";
            var storeManagerPassword = "sh0ppers.SQUARE";

            if (!context.Roles.Any(r => r.Name == storeManagerRoleName))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var storeManagerRole = new IdentityRole { Name = storeManagerRoleName };

                roleManager.Create(storeManagerRole);
            }

            if (!context.Users.Any(u => u.UserName == storeManagerEmail))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var storeManagerUser = new ApplicationUser
                {
                    FirstName = "Manager",
                    UserName = storeManagerEmail,
                    Email = storeManagerEmail,
                    PhoneNumber = "+91-8586838473",
                    Address = "Uttarakhand, India, Asia, Earth, Solar System, The Milky Way",
                };

                userManager.Create(storeManagerUser, storeManagerPassword);
                userManager.AddToRole(storeManagerUser.Id, storeManagerRoleName);
            }

            context.Categories.AddOrUpdate(c => c.Name,
                new ProductType { Id = 0, Name = "Electronics", ImageUrl = "http://www.nashikfame.com/wp-content/uploads/2017/02/trison-article-slider.jpg" },
                new ProductType { Id = 1, Name = "Home and Furniture", ImageUrl = "https://www.kimball.com/getmedia/de7a7f5a-ce84-406c-a4a5-636dde8acc4a/Desks_Main_Priority.aspx" },
                new ProductType { Id = 2, Name = "Clothing and Accesories", ImageUrl = "https://newyorkfashiongh.com/wp-content/uploads/2017/09/o-TRADING-CLOTHES-facebook.jpg" },
                new ProductType { Id = 3, Name = "Footwear", ImageUrl = "http://www.mywestside.com/images/gallery/womens/Footwear/footwear2_24052016.jpg" },
                new ProductType { Id = 4, Name = "Beauty and Personal Care", ImageUrl = "https://scstylecaster.files.wordpress.com/2016/09/worst-makeup-products.jpg" }
            );

            context.OrderStates.AddOrUpdate(s => s.Name,
                new OrderState { Id = 0, Name = "In Process", Description = "The order is being processed by the store. It will be shipped soon." },
                new OrderState { Id = 1, Name = "Shipped", Description = "The order is shipped from the store. It will be delivered soon." },
                new OrderState { Id = 2, Name = "Delivered", Description = "The order is delivered to the given address." },
                new OrderState { Id = 3, Name = "Cancelled", Description = "The order was cancelled." },
                new OrderState { Id = 4, Name = "Returned", Description = "The order has returned to the store." }
            );


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
