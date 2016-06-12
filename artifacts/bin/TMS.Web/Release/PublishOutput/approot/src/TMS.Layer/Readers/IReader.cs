namespace TMS.Layer.Readers
{
    public interface IReader<in T, R>
    {
        Maybe<R> Read(T key);
    }
}
