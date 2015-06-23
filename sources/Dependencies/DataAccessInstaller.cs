namespace Komrad.Template.Dependencies
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using DataAccess;
    using DataAccess.NHibernate;
    using Domain;
    using JetBrains.Annotations;
    using NHibernate;

    [UsedImplicitly]
    public class DataAccessInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                // NHibernate    
                Component.For<IUnitOfWorkProvider>().ImplementedBy<NHUnitOfWorkProvider>()
                    .LifestylePerThread(),
                Component.For<IUnitOfWorkFactory>().ImplementedBy<NHUnitOfWorkFactory>()
                    .LifestylePerThread(),
                Component.For<ISessionProvider>().ImplementedBy<PerRequestSessionProvider>()
                    .LifestylePerThread(),
                Component.For<ILinqProvider>().ImplementedBy<NHLinqProvider>()
                    .LifestylePerThread(),
                Component.For<ISessionFactory>().UsingFactoryMethod(x => NHConfigurationFactory.CreateConfiguration()
                                                                        .BuildSessionFactory())
                    .LifestyleSingleton()
                );
        }
    }
}
