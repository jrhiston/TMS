using System.Collections.Generic;

namespace TMS.Layer.Filters
{
    /// <summary>
    /// Implement to create a filter object. This allows the listing of model objects.
    /// 
    /// A filter object should be instantiated through a factory object.
    /// </summary>
    /// <typeparam name="TReturnedModel">The type of model object the filter will return a list of.</typeparam>
    public interface IFilter<TReturnedModel>
    {
        /// <summary>
        /// Returns a list of <see cref="TReturnedModel"/> objects.
        /// 
        /// Instantiate from it's corresponding <see cref="IFilterFactory{TReturnedModel}"/>
        /// object in order to supply filtering data.
        /// </summary>
        /// <returns></returns>
        Maybe<IEnumerable<TReturnedModel>> List();
    }
}