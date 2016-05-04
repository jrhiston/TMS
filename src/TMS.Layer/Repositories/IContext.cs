using System;

namespace TMS.Layer.Repositories
{
    public interface IContext : IDisposable
    {
        int SaveChanges();
    }
}
