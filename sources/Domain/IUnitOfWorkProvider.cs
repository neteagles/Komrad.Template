namespace Komrad.Template.Domain
{
    using System.Data;

    public interface IUnitOfWorkProvider
    {
        IUnitOfWork Create();

        IUnitOfWork Create(IsolationLevel isolationLevel);
    }
}
