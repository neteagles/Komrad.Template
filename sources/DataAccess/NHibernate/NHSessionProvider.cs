namespace Komrad.Template.DataAccess.NHibernate
{
    using System;
    using global::NHibernate;

    public class PerRequestSessionProvider : ISessionProvider, IDisposable
    {
        private readonly ISessionFactory _sessionFactory;
        private bool _disposed;
        private ISession _session;

        public PerRequestSessionProvider(ISessionFactory sessionFactory)
        {
            if (sessionFactory == null)
                throw new ArgumentNullException(nameof(sessionFactory));

            _sessionFactory = sessionFactory;
        }

        public void Dispose()
        {
            if (_disposed)
                return;

            if (_session == null)
                return;

            _session.Dispose();
            _session = null;
            _disposed = true;
        }

        public ISession CurrentSession
        {
            get
            {
                if (_disposed)
                    throw new InvalidOperationException("Object already disposed. Probably container has wrong lifestyle type");

                if (_session != null)
                    return _session;

                return _session = _sessionFactory.OpenSession();
            }
        }
    }
}
