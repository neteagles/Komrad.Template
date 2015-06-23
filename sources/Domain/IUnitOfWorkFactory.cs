namespace Komrad.Template.Domain
{
    using System.Data;

    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create(bool isNested, IsolationLevel isolationLevel);
    }
}
