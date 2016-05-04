using System;
using TMS.Layer.ModelObjects;
using TMS.ModelLayerInterface.Tags;
using TMS.ModelLayerInterface.Tags.Data;
using TMS.ModelLayerInterface.Tags.Decorators;

namespace TMS.ModelLayer.Tags.Decorators
{
    public class PersistableTag : DecoratorBase<PersistableTagData, TagData>, IPersistableTag
    {
        private ITagKey _key;

        public PersistableTag(IOwnedTag tag, PersistableTagData data) : base(tag)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            
            _key = data.Key;
        }

        protected override PersistableTagData GetData() => new PersistableTagData
        {
            Key = _key
        };
    }
}
