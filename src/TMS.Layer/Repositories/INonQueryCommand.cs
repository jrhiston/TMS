namespace TMS.Layer.Repositories
{
    /// <summary>
    /// Represents a command that is a nonquery.
    /// </summary>
    /// <typeparam name="TIn"></typeparam>
    public interface INonQueryCommand<in TIn>
    {
        void ExecuteCommand(TIn data);
    }
}
