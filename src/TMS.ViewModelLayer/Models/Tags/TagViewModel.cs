using System;
using TMS.Layer.Visitors;
using TMS.ModelLayerInterface.Tags;
using TMS.ModelLayerInterface.Tags.Data;

namespace TMS.ViewModelLayer.Models.Tags
{
    public class TagViewModel : IVisitor<TagData>, IVisitor<PersistableTagData>
    {
        public bool CanSetOnActivity { get; private set; }
        public DateTime Created { get; private set; }
        public string Description { get; private set; }
        public string Name { get; private set; }
        public long Identifier { get; private set; }

        public TagViewModel(ITag tag)
        {
            tag.Accept(() => this);
        }

        public void Visit(TagData data)
        {
            Name = data.Name;
            Description = data.Description;
            CanSetOnActivity = data.CanSetOnActivity;
            Created = data.Created;
        }

        public void Visit(PersistableTagData data)
        {
            Identifier = data.Key.Identifier;
        }
    }
}
