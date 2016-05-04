using TMS.Layer.Visitors;
using TMS.ModelLayerInterface.Activities;
using TMS.ModelLayerInterface.Activities.Data;
using TMS.Web.Models.Areas;

namespace TMS.Web.Models.Activities
{
    public class ActivityAreaViewModel : IVisitor<ActivityData>, IVisitor<ActivityAreaData>
    {
        public ActivityViewModel Activity { get; set; }
        public AreaViewModel Area { get; set; }

        public ActivityAreaViewModel(IActivity activity)
        {
            Activity = new ActivityViewModel(activity);
        }

        public void Visit(ActivityAreaData data)
        {
            if (data != null && data.Area != null)
                Area = new AreaViewModel(data.Area);
        }

        public void Visit(ActivityData data)
        {
        }
    }
}