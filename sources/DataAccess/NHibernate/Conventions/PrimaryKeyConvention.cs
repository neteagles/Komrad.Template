namespace Komrad.Template.DataAccess.NHibernate.Conventions
{
    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.Instances;
    using JetBrains.Annotations;

    [UsedImplicitly]
    public class PrimaryKeyConvention : IIdConvention
    {
        public void Apply(IIdentityInstance instance)
        {
            instance.Column("id");
        }
    }
}
