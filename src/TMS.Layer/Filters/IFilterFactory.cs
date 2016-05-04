using TMS.Layer.Data;
using TMS.Layer.Factories;

namespace TMS.Layer.Filters
{
    /// <summary>
    /// Implement to create a factory object for a <see cref="IFilter{TReturnedModel}"/> object.
    /// </summary>
    /// <typeparam name="TReturnedModel">The type of returned model the <see cref="IFilter{TReturnedModel}"/> object will produce.</typeparam>
    public interface IFilterFactory<TReturnedModel> : IFactory<IData, IFilter<TReturnedModel>>
    {
    }
}