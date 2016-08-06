namespace TMS.Layer.Visitors
{
    /// <summary>
    /// Represents a visitor. Implement this interface with the expected data as the type.
    /// </summary>
    /// <typeparam name="TData">The type of data to provide to the visitor.</typeparam>
    public interface IVisitor<TData>
    {
        /// <summary>
        /// Visit the visitor. This accepts data of the type given. 
        /// 
        /// This should be called from a visited object.
        /// </summary>
        /// <param name="data">Data to pass to the visitor.</param>
        IVisitor<TData> Visit(TData data);
    }
}
