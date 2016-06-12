namespace TMS.Layer.Repositories
{
    /// <summary>
    /// Represents a query command. Given some data, it will potentially provide an output.
    /// </summary>
    /// <typeparam name="TIn"></typeparam>
    /// <typeparam name="TOut"></typeparam>
    public interface IQueryCommand<in TIn, TOut>
    {
        /// <summary>
        /// Execute the query command.
        /// </summary>
        /// <param name="data">The data to use for querying.</param>
        /// <returns>A potential output based on the given data.</returns>
        Maybe<TOut> ExecuteCommand(TIn data);
    }
}
