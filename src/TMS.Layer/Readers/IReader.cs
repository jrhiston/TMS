namespace TMS.Layer.Readers
{
    public interface IReader<in T, out R>
    {
        R Read(T key);
    }
}
