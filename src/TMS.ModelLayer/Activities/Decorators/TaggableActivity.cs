using System;
using System.Collections.Generic;
using System.Linq;
using TMS.Layer.ModelObjects;
using TMS.ModelLayerInterface.Activities.Data;
using TMS.ModelLayerInterface.Activities.Decorators;
using TMS.ModelLayerInterface.Tags;

namespace TMS.ModelLayer.Activities.Decorators
{
    public class TaggableActivity : DecoratorBase<TaggableActivityData, ActivityData>, ITaggableActivity
    {
        private readonly List<ITag> _tags;

        public TaggableActivity(IPersistableActivity activity,
            TaggableActivityData data) : base(activity)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            _tags = data.Tags.ToList();
        }

        protected override TaggableActivityData GetData() => new TaggableActivityData
        {
            Tags = _tags
        };
    }
}
