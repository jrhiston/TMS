using Microsoft.EntityFrameworkCore;
using System;

namespace TMS.Database
{
    public interface IDatabaseContext<TEntity> : IDisposable where TEntity : class
    {
        DbSet<TEntity> Entities { get; }

        int SaveChanges();
    }
}
