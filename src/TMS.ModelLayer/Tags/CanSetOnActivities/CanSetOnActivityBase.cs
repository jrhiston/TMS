namespace TMS.ModelLayer.Tags.CanSetOnActivities
{
    public abstract class CanSetOnActivityBase : ITagElement
    {
        public abstract bool Value { get; }

        public ITagVisitor Accept(ITagVisitor visitor) => visitor.Visit(this);

        public static CanSetOnActivityBase GetInstance(bool value)
        {
            return value ? (CanSetOnActivityBase) new CanSetOnActivity() : new CanNotSetOnActivity();
        }
    }
}
