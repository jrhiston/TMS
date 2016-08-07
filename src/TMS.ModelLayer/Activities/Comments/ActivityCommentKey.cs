namespace TMS.ModelLayer.Activities.Comments
{
    public class ActivityCommentKey : Key, IActivityCommentElement
    {
        public ActivityCommentKey(long id) : base(id)
        {
        }

        public IActivityCommentVisitor Accept(IActivityCommentVisitor visitor) => visitor.Visit(this);
    }
}
