namespace Komrad.Template.Commands
{
    using Domain;
    using Frameplate.CQRS;

    public abstract class CommandBase<TContext> : ICommand<TContext>
        where TContext : class, ICommandContext
    {
        public IQueryBuilder Query { get; set; }

        public IUnitOfWorkProvider UnitOfWork { get; set; }

        public abstract void Execute(TContext context);
    }
}
