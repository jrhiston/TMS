using TMS.Layer.Factories;

namespace TMS.Layer.Data
{
    public interface IDataContextFactory<TData> : IQueryFactory<IDataContext<TData>>
        where TData : class
    {
    }
}
