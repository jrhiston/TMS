namespace TMS.ModelLayer.Tags
{
    public class Reusable : ITagElement
    {
        public bool Value { get; }

        public Reusable(bool value)
        {
            Value = value;
        }

        public ITagVisitor Accept(ITagVisitor visitor) => visitor.Visit(this);
    }
}
