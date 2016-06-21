using System;
using TMS.Layer.Visitors;
using TMS.ModelLayerInterface.Activities;
using TMS.ModelLayerInterface.Activities.Data;

namespace TMS.ViewModelLayer.Models.Activities
{
    public class ActivityViewModel : IVisitor<ActivityData>
    {
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
            Created = data.CreationDate;
        }
    }
}
