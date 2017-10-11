using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShoppersSquare_proto
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Login",
                url: "login",
                defaults: new { controller = "Account", action = "Login" }
            );

            routes.MapRoute(
                name: "Signin",
                url: "signin",
                defaults: new { controller = "Account", action = "Login" }
            );

            routes.MapRoute(
                name: "Register",
                url: "register",
                defaults: new { controller = "Account", action = "Register" }
            );

            routes.MapRoute(
                name: "signup",
                url: "signup",
                defaults: new { controller = "Account", action = "Register" }
            );

            routes.MapRoute(
                name: "SearchProducts",
                url: "search/{query}",
                defaults: new { controller = "Products", action = "Search"}
            );

            routes.MapRoute(
                name: "Manage",
                url: "manage/{action}/{id}",
                defaults: new { controller = "Manage", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ProductsByCategory",
                url: "{categoryName}",
                defaults: new { controller = "Products", action = "Category" }
            );

            routes.MapRoute(
                name: "ProductDetails",
                url: "product/{id}/{name}",
                defaults: new { controller = "Products", action = "Details", name = UrlParameter.Optional}
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Products", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
