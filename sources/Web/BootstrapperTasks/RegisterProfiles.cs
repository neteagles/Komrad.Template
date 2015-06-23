namespace Komrad.Template.Web.BootstrapperTasks
{
    using JetBrains.Annotations;
    using MvcExtensions;

    [UsedImplicitly]
    public class RegisterProfiles : BootstrapperTask
    {
        public override TaskContinuation Execute()
        {
            return TaskContinuation.Continue;
        }
    }
}