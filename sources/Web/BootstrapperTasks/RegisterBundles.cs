namespace Komrad.Template.Web.BootstrapperTasks
{
    using System.Web.Optimization;
    using JetBrains.Annotations;
    using MvcExtensions;

    [UsedImplicitly]
    public class RegisterBundles : BootstrapperTask
    {
        public override TaskContinuation Execute()
        {
            var bundles = BundleTable.Bundles;

            bundles.Add(new ScriptBundle("~/bundles/scripts-common")
                            .Include("~/Scripts/jquery-2.1.3.js",
                                     "~/Scripts/bootstrap.js",
                                     "~/Scripts/jquery.waypoints.min.js"));

            return TaskContinuation.Continue;
        }
    }
}
