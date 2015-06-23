namespace Komrad.Template.DataAccess.NHibernate
{
    using System.Linq;
    using Domain;
    using global::NHibernate.Linq;

    public class NHLinqProvider : ILinqProvider
    {
        private readonly ISessionProvider _sessionProvider;

        public NHLinqProvider(ISessionProvider sessionProvider)
        {
            _sessionProvider = sessionProvider;
        }

        public IQueryable<TEntity> GetQueryable<TEntity>()
            where TEntity : class, IEntity
        {
            return _sessionProvider.CurrentSession.Query<TEntity>();
        }
    }
}
