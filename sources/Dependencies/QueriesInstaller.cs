namespace Komrad.Template.Dependencies
{
    using Castle.Facilities.TypedFactory;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using Frameplate.CQRS;
    using JetBrains.Annotations;

    [UsedImplicitly]
    public class QueriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var queries = Classes
                .FromAssemblyNamed("Komrad.Template.Queries")
                .BasedOn(typeof(IQuery<,>))
                .WithService.AllInterfaces()
                .LifestyleTransient();            

            container.Register(
                queries,
                Component.For<IQueryBuilder>().AsFactory().LifestyleSingleton(),
                Component.For<IQueryFactory>().AsFactory().LifestyleSingleton(),
                Component.For(typeof(IQueryDescriptor<>)).ImplementedBy(typeof(QueryDescriptor<>)).LifestyleSingleton()
                );
        }
    }
}
