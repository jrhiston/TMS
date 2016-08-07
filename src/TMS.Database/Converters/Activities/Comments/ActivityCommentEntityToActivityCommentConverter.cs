using TMS.Database.Entities.Activities.Comments;
using TMS.Layer;
using TMS.Layer.Conversion;
using TMS.ModelLayer;
using TMS.ModelLayer.Activities.Comments;
using TMS.ModelLayer.People;

namespace TMS.Database.Converters.Activities.Comments
{
    public class ActivityCommentEntityToActivityCommentConverter : IConverter<ActivityCommentEntity, ActivityComment>
    {
        public Maybe<ActivityComment> Convert(ActivityCommentEntity input) => new Maybe<ActivityComment>(
            new ActivityComment(
                new ActivityCommentKey(input.Id),
                new Description(input.Description),
                new CreationDate(input.Created),
                new PersonKey(input.AuthorId)));
    }
}
