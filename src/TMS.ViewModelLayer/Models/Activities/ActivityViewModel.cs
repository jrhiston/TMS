using System;
using TMS.Layer.Visitors;
using TMS.ModelLayerInterface.Activities;
using TMS.ModelLayerInterface.Activities.Data;

namespace TMS.ViewModelLayer.Models.Activities
{
    public class ActivityViewModel : IVisitor<ActivityData>, IVisitor<PersistableActivityData>
    {
        public long Id { get; set; }
        public DateTime Created { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }

        public ActivityViewModel()
        {
        }

        public ActivityViewModel(IActivity activity)
        {
            activity.Accept(() => this);
        }

        public void Visit(ActivityData data)
        {
            Title = data.Title;
            Description = data.Description;
            Created = data.Created;
        }

        public void Visit(PersistableActivityData data)
        {
            Id = data.Key.Identifier;
        }
    }
}
