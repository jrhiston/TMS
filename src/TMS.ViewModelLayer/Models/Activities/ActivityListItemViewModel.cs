using System;
using TMS.Layer.Visitors;
using TMS.ModelLayerInterface.Activities;
using TMS.ModelLayerInterface.Activities.Data;

namespace TMS.ViewModelLayer.Models.Activities
{
    public class ActivityListItemViewModel : IVisitor<ActivityData>, IVisitor<PersistableActivityData>
    {
        public long Id { get; set; }
        public DateTime Created { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

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
