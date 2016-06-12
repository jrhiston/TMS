namespace TMS.Layer.Conversion
{
    /// <summary>
    /// Implement to allow a class to convert from the input, to the specified output.
    /// </summary>
    /// <typeparam name="TIn">The input to convert.</typeparam>
    /// <typeparam name="TOut">The output from the conversion</typeparam>
    public interface IConverter<in TIn, TOut>
    {
        /// <summary>
        /// Converts the given input into the output type. This is wrapped in a maybe class to signify failure.
        /// </summary>
        /// <param name="input">The input to convert</param>
        /// <returns>A potential output converted from the given input.</returns>
        Maybe<TOut> Convert(TIn input);
    }
}
