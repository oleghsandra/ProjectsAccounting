using System.Web;
using System.Web.Optimization;

namespace ProjectsAccounting.UI
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/invoices").Include(
                        "~/Scripts/Site/invoices.js"));

            bundles.Add(new ScriptBundle("~/bundles/invoicing").Include(
                        "~/Scripts/Site/invoicing.js"));

            bundles.Add(new ScriptBundle("~/bundles/projects").Include(
                        "~/Scripts/Site/projects.js"));

            bundles.Add(new ScriptBundle("~/bundles/rates").Include(
                        "~/Scripts/Site/rates.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.dataTables.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/bootstrap-datepicker.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/Datatables/jquery.dataTables.css",
                      "~/Content/bootstrap-datepicker.min.css"));
        }
    }
}
