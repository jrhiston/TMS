namespace TMS.Layer.Factories
{
    /// <summary>
    /// Use this factory to create an object that accepts no data.
    /// </summary>
    /// <typeparam name="TProduce">The type of object this factory is to produce.</typeparam>
    public interface IQueryFactory<out TProduce>
    {
        /// <summary>
        /// Create the object of the specified type.
        /// </summary>
        /// <returns>An object of the specified type.</returns>
        TProduce Create();
    }
}
