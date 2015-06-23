namespace Komrad.Template.DataAccess
{
    using global::NHibernate;

    public interface ISessionProvider
    {
        ISession CurrentSession { get; }
    }
}
