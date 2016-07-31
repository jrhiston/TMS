using System;
using System.Collections.Generic;
using System.Linq;
using TMS.Layer.Visitors;
using TMS.ModelLayerInterface.Activities;
using TMS.ModelLayerInterface.Activities.Data;
using TMS.ViewModelLayer.Models.Tags;

namespace TMS.ViewModelLayer.Models.Activities
{
    public class ActivityViewModel : IVisitor<ActivityData>, IVisitor<PersistableActivityData>, IVisitor<TaggableActivityData>
    {
        public long Id { get; private set; }
        public DateTime Created { get; private set; }
        public string Description { get; private set; }
        public string Title { get; private set; }
        public List<TagViewModel> Tags { get; private set; }

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

        public void Visit(TaggableActivityData data)
        {
            Tags = data.Tags.Select(t => new TagViewModel(t)).ToList();
        }
    }
}
