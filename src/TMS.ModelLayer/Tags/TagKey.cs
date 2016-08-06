using System;

namespace TMS.ModelLayer.Tags
{
    public class TagKey : Key, ITagElement
    {
        public TagKey(long id) : base(id)
        {
        }

        public ITagVisitor Accept(ITagVisitor visitor) => visitor.Visit(this);
    }
}
