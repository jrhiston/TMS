namespace TMS.Layer.Repositories
{
    /// <summary>
    /// Implement to create a repository that is queryable. Provides a way to get and list objects.
    /// </summary>
    /// <typeparam name="TItem">The type of object to list and get.</typeparam>
    /// <typeparam name="TKey">A key to use for the get.</typeparam>
    public interface IQueryableRepository<TItem, in TKey>
    {
        /// <summary>
        /// Retrieve an object of type <see cref="TItem"/> with the key object of type <see cref="TKey"/>.
        /// </summary>
        /// <param name="key">The key to identify an item.</param>
        /// <returns>Potentially returns an item that matches the key given.</returns>
        Maybe<TItem> Get(TKey key);
    }
}
