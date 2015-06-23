namespace Komrad.Template.DataAccess.NHibernate.Conventions
{
    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.Instances;
    using JetBrains.Annotations;
    using Utilities;

    [UsedImplicitly]
    public class ColumnNameConvention : IPropertyConvention
    {
        public void Apply(IPropertyInstance instance)
        {
            instance.Column(NameConventions.ReplaceCamelCaseWithUnderscore(instance.Name));
        }
    }
}
