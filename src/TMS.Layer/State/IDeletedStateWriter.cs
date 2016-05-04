namespace TMS.Layer.State
{
    public interface IDeletedStateWriter<T> : IStateCommitter<T>
    {
        void CommitOnDelete(T objectToCommit);
    }
}
