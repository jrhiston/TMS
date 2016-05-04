namespace TMS.ModelLayerInterface.Activities
{
    public interface IActionable
    {
        void AddActivity(IActivity activity);
        void RemoveActivity(IActivity activity);
    }
}
