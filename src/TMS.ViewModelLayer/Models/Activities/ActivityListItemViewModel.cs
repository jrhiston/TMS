using System;
using TMS.Layer.Visitors;
using TMS.ModelLayerInterface.Activities;
using TMS.ModelLayerInterface.Activities.Data;

namespace TMS.ViewModelLayer.Models.Activities
{
    public class ActivityListItemViewModel : IVisitor<ActivityData>, IVisitor<PersistableActivityData>
    {
        public long Id { get; private set; }
        public DateTime Created { get; private set; }
        public string Description { get; private set; }
        public string Name { get; private set; }
        public long AreaId { get; set; }

        public ActivityListItemViewModel(IActivity activity)
        {
            activity.Accept(() => this);
        }

        public void Visit(ActivityData data)
        {
            Name = data.Title;
            Description = data.Description;
            Created = data.Created;
        }

        public void Visit(PersistableActivityData data)
        {
            Id = data.Key?.Identifier ?? 0;
        }
    }
}
