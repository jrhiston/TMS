namespace TMS.Layer.State
{
    public interface IDeletedStateMarker : IStateMarker
    {
        void MarkAsDeleted();
    }
}
