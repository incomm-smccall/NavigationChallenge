using System.Web.Optimization;

namespace NavigationChallenge.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery-using.js",
                "~/Scripts/plyr.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                "~/Scripts/umb/popper.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/custom/navtest.js"
            ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/Site.css",
                "~/Content/plyr.css"
            ));
        }
    }
}