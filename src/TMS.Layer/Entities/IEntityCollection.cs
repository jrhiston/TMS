using System.Linq;

namespace TMS.Layer.Entities
{
    public interface IEntityCollection<TEntity> : IQueryable<TEntity>
    {
        void Add(TEntity entity);
    }
}
