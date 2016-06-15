using System.Collections.Generic;

namespace TMS.Database
{
    public interface IDatabaseContext<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Entities { get; }
    }
}
