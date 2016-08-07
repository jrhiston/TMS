using System;
using System.Linq;
using TMS.Layer.Creators;
using TMS.Layer.Persistence;
using TMS.Layer.Readers;
using TMS.ModelLayer;
using TMS.ModelLayer.Activities;
using TMS.ModelLayer.Activities.Comments;
using TMS.ModelLayer.People;
using TMS.ModelLayer.Tags;
using TMS.ModelLayer.Tags.CanSetOnActivities;
using TMS.ViewModelLayer.Models.Activities;

namespace TMS.ApplicationLayer.Activities
{
    public class ActivityCommentCreator : ICreator<ActivityCommentViewModel>
    {
        private readonly IReader<ActivityKey, Activity> _reader;
        private readonly IWriter<Activity, ActivityKey> _writer;

        public ActivityCommentCreator(IReader<ActivityKey, Activity> reader,
            IWriter<Activity, ActivityKey> writer)
        {
            _reader = reader;
            _writer = writer;
        }

        public void Create(ActivityCommentViewModel model)
        {
            var activity = _reader.Read(new ActivityKey(model.ActivityId));

            var list = activity.Single().OfType<IActivityElement>().ToList();

            list.Add(new ActivityComment(
                new Description(model.Description),
                new CreationDate(DateTime.UtcNow),
                new PersonKey(model.CreatorId)
            ));

            _writer.Save(new Activity(list.ToArray()));
        }
    }
}
