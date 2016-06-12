using System;

namespace TMS.Layer.Repositories
{
    public interface IUnitOfWork<TContext> : IDisposable where TContext : IContext
    {
        int Save();
        TContext Context { get; }
    }
}
