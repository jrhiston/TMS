using TMS.ModelLayer;
using TMS.ModelLayer.Tags;

namespace TMS.ViewModelLayer.Models.Tags
{
    public class TagListItemViewModel : TagVisitorBase
    {
        public long Id { get; private set; }
        public string Name { get; private set; }

        public override ITagVisitor Visit(TagKey tagKey)
        {
            Id = tagKey.Identifier;
            return this;
        }

        public override ITagVisitor Visit(Name name)
        {
            Name = name.Value;
            return this;
        }
    }
}
