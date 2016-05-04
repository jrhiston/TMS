using TMS.Layer.Data;

namespace TMS.Layer.Factories
{
    /// <summary>
    /// Use this class for creation of normal model objects.
    /// 
    /// N.B. If no data is expected to be accepted, use the <see cref="IQueryFactory{TProduce}"/> class.
    /// </summary>
    /// <typeparam name="TData">The data to give to the <paramref name="TProduce"/> object.</typeparam>
    /// <typeparam name="TProduce">The object this factory shall create</typeparam>
    public interface IFactory<in TData, out TProduce>
        where TData : IData
    {
        /// <summary>
        /// Create the object specified, using the data given.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        TProduce Create(TData data);
    }
}
