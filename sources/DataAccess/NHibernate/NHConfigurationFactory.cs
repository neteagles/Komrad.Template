namespace Komrad.Template.DataAccess.NHibernate
{
    using Domain;
    using FluentNHibernate.Automapping;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Conventions.Helpers;
    using global::NHibernate.Cfg;
    using global::NHibernate.Context;
    using JetBrains.Annotations;

    [UsedImplicitly]
    public class NHConfigurationFactory
    {
        public static Configuration CreateConfiguration()
        {
            var config = PostgreSQLConfiguration.PostgreSQL94
                .ConnectionString(x => x.FromConnectionStringWithKey("Main"))
                .UseReflectionOptimizer()
                .AdoNetBatchSize(100);

            var persistenceModel = AutoMap
                .AssemblyOf<IEntity>(new AutomappingConfiguration())
                .UseOverridesFromAssemblyOf<NHConfigurationFactory>()
                .Conventions.AddFromAssemblyOf<NHConfigurationFactory>();

            var autoPersistenceModel = persistenceModel.Conventions
                .Setup(z => z.Add(AutoImport.Never()));
             
            var fluentConfiguration = Fluently
                .Configure()
                .CurrentSessionContext<ThreadStaticSessionContext>()
                .Database(config)
                .Mappings(x => x.AutoMappings.Add(autoPersistenceModel)); 

            return fluentConfiguration.BuildConfiguration();
        }
    }
}
