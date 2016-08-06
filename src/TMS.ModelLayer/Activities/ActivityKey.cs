namespace TMS.ModelLayer.Activities
{
    public class ActivityKey : Key, IActivityElement
    {
        public ActivityKey(long id) : base(id)
        {
        }

        public IActivityVisitor Accept(IActivityVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
