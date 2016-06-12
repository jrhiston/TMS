using System;
using System.Collections.Generic;
using TMS.Layer.ModelObjects;
using TMS.ModelLayerInterface.Tags;
using TMS.ModelLayerInterface.Tags.Data;
using TMS.ModelLayerInterface.Tags.Decorators;

namespace TMS.ModelLayer.Tags.Decorators
{
    public class TaggableTag : DecoratorBase<TaggableTagData, TagData>, ITaggableTag
    {
        private readonly List<ITag> _tags;

        public TaggableTag(IPersistableTag tag, TaggableTagData data) : base(tag)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            
            _tags = data.Tags;
        }

        protected override TaggableTagData GetData() => new TaggableTagData
        {
            Tags = _tags
        };
    }
}
