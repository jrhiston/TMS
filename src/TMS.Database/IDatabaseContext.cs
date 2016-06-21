using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace TMS.Database
{
    public interface IDatabaseContext<TEntity> where TEntity : class
    {
        DbSet<TEntity> Entities { get; }

        int SaveChanges();
    }
}
