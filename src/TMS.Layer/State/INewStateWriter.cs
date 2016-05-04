namespace TMS.Layer.State
{
    public interface INewStateWriter<T> : IStateCommitter<T>
    {
        void CommitOnNew(T objectToCommit);
    }
}
