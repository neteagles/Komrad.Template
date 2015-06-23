namespace Komrad.Template.DataAccess.NHibernate
{
    using System.Data;
    using Domain;
    using global::NHibernate;

    public class NHUnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly ISessionFactory _sessionFactory;

        public NHUnitOfWorkFactory(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public IUnitOfWork Create(bool isNested, IsolationLevel isolationLevel)
        {
            return new NHUnitOfWork(_sessionFactory.OpenSession(), isolationLevel);
        }
    }
}
