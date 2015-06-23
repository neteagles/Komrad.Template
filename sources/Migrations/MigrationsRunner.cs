// @Komrad.Revolver If: sqlserver Then: [DatabaseType]=sqlserver
// @Komrad.Revolver If: postgres Then: [DatabaseType]=postgres
// @Komrad.Revolver If: mysql Then: [DatabaseType]=mysql
namespace Komrad.Template.Migrations
{
    using System.Configuration;
    using System.Text;
    using FluentMigrator.Runner.Announcers;
    using FluentMigrator.Runner.Initialization;

    public static class MigrationsRunner
    {
        private const string DatabaseType = "@Komrad.Revolver [DatabaseType]";

        public static string Run(string connectionStringKey)
        {
            var connectionString = ConfigurationManager.ConnectionStrings[connectionStringKey].ConnectionString;

            var migrationLog = new StringBuilder();
            var announcer = new TextWriterAnnouncer(s => migrationLog.Append(s));
            var runnerContext = new RunnerContext(announcer)
            {
                Database = DatabaseType,
                Connection = connectionString,
                Targets = new[] { typeof(MigrationsRunner).Assembly.FullName }
            };

            new TaskExecutor(runnerContext).Execute();

            return migrationLog.ToString();
        }
    }
}