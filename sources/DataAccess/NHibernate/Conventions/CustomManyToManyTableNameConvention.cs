namespace Komrad.Template.DataAccess.NHibernate.Conventions
{
    using System;
    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.Inspections;
    using Utilities;

    public class CustomManyToManyTableNameConvention : ManyToManyTableNameConvention
    {
        protected override string GetBiDirectionalTableName(IManyToManyCollectionInspector collection,
            IManyToManyCollectionInspector otherSide)
        {
            return GetTableName(collection.EntityType, otherSide.EntityType);
        }

        protected override string GetUniDirectionalTableName(IManyToManyCollectionInspector collection)
        {
            return GetTableName(collection.EntityType, collection.ChildType);
        }

        private static string GetTableName(Type entityType, Type otherSideType)
        {
            return string.Format("{0}_{1}",
                                 NameConventions.GetTableName(entityType),
                                 NameConventions.GetTableName(otherSideType));
        }
    }
}
