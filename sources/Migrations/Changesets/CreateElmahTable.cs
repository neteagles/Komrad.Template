namespace Komrad.Template.Migrations.Changesets
{
    using FluentMigrator;
    using JetBrains.Annotations;

    [Migration(1), UsedImplicitly]
    public class CreateElmahTable : ForwardOnlyMigration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("Komrad.Template.Migrations.Scripts.Elmah.Postgres.sql");
        }
    }
}