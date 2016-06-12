namespace TMS.Layer.Persistence
{
    public interface IWriter<T>
    {
        void Save(T objectToSave);
    }
}
