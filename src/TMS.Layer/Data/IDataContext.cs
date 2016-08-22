using System;
using Microsoft.EntityFrameworkCore;
using TMS.Layer.Entities;

namespace TMS.Layer.Data
{
    public interface IDataContext<TData> : IDisposable where TData : class
    {
        DbSet<TData> Entities { get; }

        int SaveChanges();
    }
}
