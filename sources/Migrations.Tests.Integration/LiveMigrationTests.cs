namespace Komrad.Template.Migrations.Tests.Integration
{
    using System;
    using Domain.Constants;
    using NUnit.Framework;

    [TestFixture]
    [Category("Live")]
    public class LiveMigrationTests
    {
        [Test]
        public void ApplyMigrations()
        {
            var migrationLog = MigrationsRunner.Run(EnvironmentConsts.SQLConnectionStringKey);
            Console.WriteLine(migrationLog);
        }
    }
}