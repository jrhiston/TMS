using System;

namespace TMS.Layer.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void Begin();
        void Commit();
        void Rollback();
    }
}
