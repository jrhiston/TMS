using System;
using TMS.Layer.ModelObjects;
using TMS.ModelLayerInterface.Tags;
using TMS.ModelLayerInterface.Tags.Data;
using TMS.ModelLayerInterface.Tags.Decorators;

namespace TMS.ModelLayer.Tags.Decorators
{
    public class DeletedTag : DecoratorBase<DeletedTagData, TagData>, IDeletedTag
    {
        private readonly bool _deleted;

        public DeletedTag(ITag tag, DeletedTagData data) : base(tag)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            _deleted = data.Deleted;
        }

        protected override DeletedTagData GetData() => new DeletedTagData
        {
            Deleted = _deleted
        };
    }
}
