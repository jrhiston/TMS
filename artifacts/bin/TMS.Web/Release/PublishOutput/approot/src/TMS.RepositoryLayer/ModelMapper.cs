namespace TMS.RepositoryLayer
{
    /// <summary>
    /// Maps model object to data objects and vice versa.
    /// </summary>
    /// <typeparam name="TDataObjectType"></typeparam>
    /// <typeparam name="RModelObjectType"></typeparam>
    public abstract class ModelMapper<TDataObjectType, RModelObjectType>
    {
        /// <summary>
        /// Convert a data object from the database to a model object.
        /// </summary>
        /// <param name="dataObject">The data object to convert.</param>
        /// <returns>The corresponding model object</returns>
        public abstract RModelObjectType ConvertToModelObject(TDataObjectType dataObject);

        /// <summary>
        /// Convert a model object into a database object.
        /// </summary>
        /// <param name="dataObject">The model object to convert.</param>
        /// <returns>A data object.</returns>
        public abstract TDataObjectType ConvertToDataObject(RModelObjectType dataObject);
    }
}
