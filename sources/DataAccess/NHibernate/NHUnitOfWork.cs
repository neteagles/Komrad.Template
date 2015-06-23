namespace Komrad.Template.DataAccess.NHibernate
{
    using System;
    using System.Data;
    using Domain;
    using global::NHibernate;
    using global::NHibernate.Context;

    public class NHUnitOfWork : IUnitOfWork
    {
        private readonly ISession _session;
        private ITransaction _transaction;

        public NHUnitOfWork(ISession session, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));

            CurrentSessionContext.Bind(session);

            _session = session;
            _transaction = session.BeginTransaction(isolationLevel);
        }

        public void Dispose()
        {
            if (!_transaction.WasCommitted && !_transaction.WasRolledBack)
                _transaction.Rollback();
            _transaction.Dispose();
            _transaction = null;

            CurrentSessionContext.Unbind(_session.SessionFactory);
            _session.Dispose();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public bool Finished => _transaction == null;

        public void Save<TEntity>(TEntity entity)
            where TEntity : class, IEntity
        {
            _session.Save(entity);
        }

        public void Update<TEntity>(TEntity entity)
            where TEntity : class, IEntity
        {
            _session.Update(entity);
        }

        public void Delete<TEntity>(TEntity entity)
            where TEntity : class, IEntity
        {
            _session.Delete(entity);
        }
    }
}
