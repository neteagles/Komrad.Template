namespace Komrad.Template.Queries
{
    using System.Linq;
    using Domain;
    using Frameplate.CQRS;

    public abstract class LinqQueryBase<TCriterion, TResult> : QueryBase<TCriterion, TResult>
        where TCriterion : class, ICriterion
    {
        public ILinqProvider LinqProvider { get; set; }

        public IUnitOfWorkProvider UnitOfWork { get; set; }

        protected IQueryable<TEntity> Query<TEntity>()
            where TEntity : class, IEntity
        {
            return LinqProvider.GetQueryable<TEntity>();
        }

        public override TResult Execute(TCriterion criterion)
        {
            using (UnitOfWork.Create())
                return FetchResult(criterion);
        }

        protected abstract TResult FetchResult(TCriterion criterion);
    }
}
