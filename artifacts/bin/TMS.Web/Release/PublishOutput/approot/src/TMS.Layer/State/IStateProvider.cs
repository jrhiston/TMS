namespace TMS.Layer.State
{
    public interface IStateProvider :
        IDirtyStateMarker,
        IDeletedStateMarker,
        IStateReader,
        IStateWriter
    {
        void Save<T>(T obj, IStateCommitter<T> stateProcessor);
    }
}
