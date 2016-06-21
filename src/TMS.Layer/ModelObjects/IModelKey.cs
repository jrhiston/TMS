namespace TMS.Layer.ModelObjects
{
    /// <summary>
    /// Represents a key for a model object.
    /// </summary>
    public interface IModelKey
    {
        /// <summary>
        /// Get or set the identifier for this model object key.
        /// </summary>
        long Identifier { get; set; }
    }
}
