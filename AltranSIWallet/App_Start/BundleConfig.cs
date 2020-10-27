using System.Web;
using System.Web.Optimization;

namespace AltranSIWallet
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                          "~/Content/bootstrap.css",
                          "~/Content/font-awesome.css",
                          "~/Content/toastr.min.css",
                          "~/Content/site.css"));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));
            bundles.Add(new ScriptBundle("~/bundles/toastr").Include(
                      "~/Scripts/toastr.js"));
            bundles.Add(new ScriptBundle("~/bundles/baseScript").Include(
                        "~/Scripts/angular.min.js",
                         "~/Scripts/custom/app.js"));
            bundles.Add(new ScriptBundle("~/bundles/enums").Include(
                        "~/Scripts/custom/enums.js"));
            bundles.Add(new ScriptBundle("~/bundles/angularConsultant").Include(
                        "~/Scripts/custom/consultant.js"));
            bundles.Add(new ScriptBundle("~/bundles/angularManager").Include(
                        "~/Scripts/custom/manager.js"));
            bundles.Add(new ScriptBundle("~/bundles/angularProject").Include(
                        "~/Scripts/custom/project.js"));
            bundles.Add(new ScriptBundle("~/bundles/angularProjectManager").Include(
                        "~/Scripts/custom/project-manager.js"));
        }

    }
}
