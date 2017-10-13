using System.Web;
using System.Web.Optimization;

namespace ShoppersSquare_proto
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            
            bundles.Add(new StyleBundle("~/Content/fontawesome").Include(
                        "~/Content/font-awesome.css"));

            bundles.Add(new StyleBundle("~/Content/styles").Include(
                      "~/Content/Css/site.css"));
        }
    }
}
