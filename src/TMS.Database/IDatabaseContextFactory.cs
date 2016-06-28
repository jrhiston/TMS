using TMS.Layer.Factories;

namespace TMS.Database
{
    public interface IDatabaseContextFactory<TEntity> : IQueryFactory<IDatabaseContext<TEntity>>
        where TEntity : class
    {
    }
}
