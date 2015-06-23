namespace Komrad.Template.DataAccess.NHibernate
{
    using System.Data;
    using global::NHibernate.Dialect;
    using JetBrains.Annotations;

    [UsedImplicitly]
    public class PostgreSQL94Dialect : PostgreSQL82Dialect
    {
        public PostgreSQL94Dialect()
        {
            RegisterColumnType(DbType.Object, "json");
        }
    }
}
