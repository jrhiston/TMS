using TMS.Layer.Data;

namespace TMS.Layer.Factories
{
    public class Factory<TData, TReturned> : IFactory<TData, TReturned> where TData : IData where TReturned : class
    {
        private readonly IFactoryRegistrar _factoryConstructor;

        public Factory(IFactoryRegistrar factoryConstructor)
        {
            _factoryConstructor = factoryConstructor;
        }

        public TReturned Create(TData data) => _factoryConstructor.Create<TReturned, TData>(data);
    }

    /// <summary>
    /// Use this class for creation of normal model objects.
    /// 
    /// N.B. If no data is expected to be accepted, use the <see cref="IQueryFactory{TProduce}"/> class.
    /// </summary>
    /// <typeparam name="TData">The data to give to the <paramref name="TProduce"/> object.</typeparam>
    /// <typeparam name="TReturned">The object this factory shall create</typeparam>
    public interface IFactory<TData, TReturned>
    {
        /// <summary>
        /// Create the object specified, using the data given.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        TReturned Create(TData data);
    }
}
