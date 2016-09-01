using System.Web;
using System.Web.Optimization;

namespace TeamSports
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-2.2.0.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/moment.min.js",
                      "~/Scripts/bootstrap-datetimepicker.min.js",
                      "~/Scripts/main.js"));

            bundles.Add(new ScriptBundle("~/bundles/gmap").Include(
                      "~/Scripts/gmap.js"));

            bundles.Add(new ScriptBundle("~/bundles/gmap_details").Include(
                      "~/Scripts/gmap_details.js"));

            bundles.Add(new ScriptBundle("~/bundles/ace").Include(
                        "~/Scripts/ace.min.js",
                        "~/Scripts/ace-extra.min.js",
                        "~/Scripts/ace-elements.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/site.css",
                      "~/Content/events.css",
                      "~/Content/ace.min.css",
                      "~/Content/ace-skins.min.css",
                      "~/Content/ace-rtl.min.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/fonts.googleapis.com.css",
                      "~/Content/bootstrap-datetimepicker.min.css"));

        }
    }
}
