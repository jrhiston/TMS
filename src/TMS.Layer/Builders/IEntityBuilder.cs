namespace TMS.Layer.Builders
{
    /// <summary>
    /// An abstraction to help in converting domain objects into their entity counterparts.
    /// </summary>
    /// <typeparam name="TData">The tyhpe of the domain object.</typeparam>
    /// <typeparam name="TResult">The type of entity</typeparam>
    public interface IEntityBuilder<TData, TResult>
    {
        /// <summary>
        /// Create a new entity from the given data.
        /// </summary>
        /// <param name="data">Data to use to create the entity.</param>
        /// <returns>A new entity.</returns>
        TResult Create(TData data);

        /// <summary>
        /// Update an existing entity that you provide.
        /// </summary>
        /// <param name="data">The data to update with.</param>
        /// <param name="existing">The existing entity.</param>
        void Update(TData data, TResult existing);
    }
}
