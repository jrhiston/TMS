namespace TMS.ModelLayer.Tags
{
    public class ParentTag : ITagElement
    {
        public Tag Tag { get; }

        public ParentTag(Tag tag)
        {
            Tag = tag;
        }

        public ITagVisitor Accept(ITagVisitor visitor) => visitor.Visit(this);
    }
}
