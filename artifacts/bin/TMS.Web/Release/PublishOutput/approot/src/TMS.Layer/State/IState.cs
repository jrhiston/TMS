namespace TMS.Layer.State
{
    public interface IState
    {
        void SetStateToClean(IStateWriter stateWriter);
        void SetStateToDeleted(IStateWriter stateWriter);
        void SetStateToDirty(IStateWriter stateWriter);
        void SetStateToNew(IStateWriter stateWriter);

        void Commit<T>(IStateCommitter<T> stateProcessor, T obj);
    }
}