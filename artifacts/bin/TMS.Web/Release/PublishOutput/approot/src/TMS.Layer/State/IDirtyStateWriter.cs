namespace TMS.Layer.State
{
    public interface IDirtyStateWriter<T> : IStateCommitter<T>
    {
        void CommitOnDirty(T objectToCommit);
    }
}
