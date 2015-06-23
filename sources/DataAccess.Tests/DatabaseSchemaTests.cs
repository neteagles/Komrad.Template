namespace Komrad.Template.DataAccess.Tests
{
    using global::NHibernate.Cfg;
    using global::NHibernate.Tool.hbm2ddl;
    using NHibernate;
    using NUnit.Framework;

    [TestFixture]
    [Category("Live")]
    public class DatabaseSchemaTests
    {
        private static Configuration _configuration;

        [TestFixtureSetUp]
        public static void FixtureSetUp()
        {
            _configuration = NHConfigurationFactory.CreateConfiguration();
        }

        [Test]
        public void GenerateSchemaCreationScript()
        {
            new SchemaExport(_configuration).Execute(true, false, false);
        }
    }
}
