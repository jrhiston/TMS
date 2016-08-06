using TMS.Layer.ModelObjects;
using TMS.ModelLayer.Activities;

namespace TMS.ModelLayer.Tags
{
    public class Tag : AggregateRoot<ITagElement, ITagVisitor>, IActivityElement
    {
        public Tag(params ITagElement[] elements) : base(elements)
        {
        }

        public IActivityVisitor Accept(IActivityVisitor visitor) => (visitor.Visit(this));
    }
}
