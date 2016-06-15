using System;
using TMS.Layer;

namespace TMS.Database
{
    public interface IDbContextTypeProvider : IServiceInitialiserDataProvider
    {
        Type GetDbContextType();
    }
}
