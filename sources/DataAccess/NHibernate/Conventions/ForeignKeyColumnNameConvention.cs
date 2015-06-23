namespace Komrad.Template.DataAccess.NHibernate.Conventions
{
    using System;
    using FluentNHibernate;
    using FluentNHibernate.Conventions;
    using JetBrains.Annotations;
    using Utilities;

    [UsedImplicitly]
    public class ForeignKeyColumnNameConvention : ForeignKeyConvention
    {
        protected override string GetKeyName(Member member, Type type)
        {
            return string.Format("{0}_id", member == null 
                ? NameConventions.ReplaceCamelCaseWithUnderscore(type.Name)
                : NameConventions.ReplaceCamelCaseWithUnderscore(member.Name));
        }
    }
}
