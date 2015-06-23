namespace Komrad.Template.Web
{
    using System.Web.Mvc;
    using BootstrapperTasks;
    using MvcExtensions;
    using MvcExtensions.Windsor;

    public class MvcApplication : WindsorMvcApplication
    {
        public MvcApplication()
        {
            Bootstrapper.BootstrapperTasks
                .Include<RegisterAreas>()
                .Include<RegisterControllers>()
                .Include<RegisterRoutes>()
                .Include<RegisterBundles>()
                .Include<RegisterModelMetadata>()
                //.Include<ConfigureLog4net>()
                .Include<RegisterProfiles>()
                ;
        }

        protected override void OnStart()
        {
            GlobalFilters.Filters.Add(new HandleErrorAttribute());
        }
    }
}
