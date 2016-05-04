namespace TMS.Layer.Repositories
{
    /// <summary>
    /// Represents a persistable repository. This will allow the saving and deleting of a given type.
    /// </summary>
    /// <typeparam name="TData">The type of object to be persisted.</typeparam>
    /// <typeparam name="TKey">The key of the object for deletion.</typeparam>
    public interface IPersistableRepository<in TData, in TKey>
    {
        /// <summary>
        /// Save the given data into the repository.
        /// </summary>
        /// <param name="data">The data to save.</param>
        void Save(TData data);

        /// <summary>
        /// Delete the item that corresponds to the given key.
        /// </summary>
        /// <param name="key">The key that identifies an item to delete.</param>
        void Delete(TKey key);
    }
}
