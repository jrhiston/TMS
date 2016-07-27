using TMS.Layer.Visitors;
using TMS.ModelLayerInterface.Tags;
using TMS.ModelLayerInterface.Tags.Data;

namespace TMS.ViewModelLayer.Models.Tags
{
    public class TagListItemViewModel : IVisitor<TagData>, IVisitor<PersistableTagData>
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public TagListItemViewModel(ITag tag)
        {
            tag.Accept(() => this);
        }

        public void Visit(TagData data)
        {
            Name = data.Name;
        }

        public void Visit(PersistableTagData data)
        {
            Id = data.Key.Identifier;
        }
    }
}
