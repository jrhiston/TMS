using System;
using TMS.Layer.ModelObjects;
using TMS.ModelLayerInterface.People;
using TMS.ModelLayerInterface.Tags;
using TMS.ModelLayerInterface.Tags.Data;
using TMS.ModelLayerInterface.Tags.Decorators;

namespace TMS.ModelLayer.Tags.Decorators
{
    public class OwnedTag : DecoratorBase<OwnedTagData, TagData>, IOwnedTag
    {
        private readonly IPersonKey _owner;
        private readonly ITag _tag;

        public OwnedTag(ITag tag, IPersonKey owner) : base(tag)
        {
            if (owner == null)
                throw new ArgumentNullException(nameof(owner));
            
            _owner = owner;
        }

        protected override OwnedTagData GetData() => new OwnedTagData
        {
            Owner = _owner
        };
    }
}
