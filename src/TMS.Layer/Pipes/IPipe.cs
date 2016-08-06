namespace TMS.Layer.Pipes
{
    public interface IPipe<T>
    {
        T Pipe(T item);
    }
}
