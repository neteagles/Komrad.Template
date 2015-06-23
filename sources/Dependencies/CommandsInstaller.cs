namespace Komrad.Template.Dependencies
{
    using Castle.Facilities.TypedFactory;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using Frameplate.CQRS;
    using JetBrains.Annotations;

    [UsedImplicitly]
    public class CommandsInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<TypedFactoryFacility>();

            var commands = Classes
                .FromAssemblyNamed("Komrad.Template.Commands")
                .BasedOn(typeof (ICommand<>))
                .WithService.AllInterfaces()
                .LifestyleTransient();

            container.Register(
                commands,
                Component.For<ICommandBuilder>().ImplementedBy<CommandBuilder>().LifestyleSingleton(),
                Component.For<ICommandFactory>().AsFactory().LifestyleSingleton()
                );
        }
    }
}
