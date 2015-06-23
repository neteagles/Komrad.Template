namespace Komrad.Template.DataAccess.NHibernate.Conventions
{
    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.Instances;
    using JetBrains.Annotations;

    [UsedImplicitly]
	public class PropertyLengthConvention : IPropertyConvention
	{
		public void Apply(IPropertyInstance instance)
		{
			instance.Length(short.MaxValue);
		}
	}
}
