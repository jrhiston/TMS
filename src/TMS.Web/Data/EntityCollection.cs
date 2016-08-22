using Microsoft.EntityFrameworkCore;
using TMS.Layer.Entities;

namespace TMS.Web.Data
{
    public class EntityCollection<TEntity> : DbSet<TEntity>, IEntityCollection<TEntity> where TEntity : class
    {
        void IEntityCollection<TEntity>.Add(TEntity entity)
        {
            Add(entity);
        }
    }
}
