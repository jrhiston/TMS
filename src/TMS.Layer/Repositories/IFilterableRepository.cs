using System.Collections.Generic;
using TMS.Layer;

namespace TMS.Layer.Repositories
{
    /// <summary>
    /// Implement to define a repository that accepts some filter data, and might return a list of <see cref="TItem"/> objects.
    /// </summary>
    /// <typeparam name="TItem">The item type to return a list of</typeparam>
    /// <typeparam name="TFilterData">The filter type.</typeparam>
    public interface IFilterableRepository<TItem, in TFilterData>
    {
        /// <summary>
        /// Retrieve a list of <see cref="TItem"/> objects using the given filter data <see cref="TFilterData"/>.
        /// </summary>
        /// <param name="filter">The filter data</param>
        /// <returns>A potential list of objects of type <see cref="TItem"/></returns>
        Maybe<IEnumerable<TItem>> List(TFilterData filter);
    }
}
