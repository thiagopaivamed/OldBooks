using System.Web;
using System.Web.Optimization;

namespace OldBooks
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/mascara").Include(
                        "~/Scripts/jquery.mask.js",
                        "~/Scripts/mascaras.js"));

            bundles.Add(new ScriptBundle("~/bundles/datepicker").Include(
                        "~/Scripts/bootstrap-datepicker.js",
                        "~/Scripts/bootstrap-datepicker.pt-BR.js",
                        "~/Scripts/datepicker.js"));

            bundles.Add(new ScriptBundle("~/bundles/arquivos").Include(
                       "~/Scripts/fileinput.js",
                       "~/Scripts/fileinput_locale_pt-BR.js",
                       "~/Scripts/Arquivos.js"));
           
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/fileinput.css"));
        }
    }
}
