using TMS.Layer.ModelObjects;
using TMS.ModelLayerInterface.Tags;
using TMS.ModelLayerInterface.Tags.Data;
using TMS.ModelLayerInterface.Tags.Decorators;

namespace TMS.ModelLayer.Tags.Decorators
{
    public class ReusableTag : DecoratorBase<ReusableTagData, TagData>, IReusableTag
    {
        private readonly bool _reusable;

        public ReusableTag(ITag tag, bool reusable) : base(tag)
        {
            _reusable = reusable;
        }

        protected override ReusableTagData GetData() => new ReusableTagData
        {
            Reusable = _reusable
        };
    }
}
