namespace TMS.Layer.State
{
    public interface IDirtyStateMarker : IStateMarker
    {
        void MarkAsDirty();
    }
}
