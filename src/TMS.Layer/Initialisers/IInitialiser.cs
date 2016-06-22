namespace TMS.Layer.Initialisers
{
    /// <summary>
    /// Creates and initialises an object of type <see cref="TOutput"/>. It should take the input data and initialise and return the given type.
    /// </summary>
    /// <typeparam name="TInputData">Data to be used for initialisation.</typeparam>
    /// <typeparam name="TOutput">The output that has been initialised.</typeparam>
    public interface IInitialiser<in TInputData, out TOutput> where TInputData : IInitialiserData<TOutput>
    {
        /// <summary>
        /// Creates and initialises an object of type <see cref="TOutput"/>, using the given data.
        /// </summary>
        /// <param name="data">The data to use to initialise an object.</param>
        /// <returns>An initialised object of type <see cref="TOutput"/>.</returns>
        TOutput Initialise(TInputData data);
    }
}
