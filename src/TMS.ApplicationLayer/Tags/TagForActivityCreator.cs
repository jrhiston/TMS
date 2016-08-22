using System;
using System.Linq;
using TMS.Layer.Creators;
using TMS.Layer.Persistence;
using TMS.Layer.Readers;
using TMS.ModelLayer.Activities;
using TMS.ModelLayer.Tags;
using TMS.ViewModelLayer.Models.Tags;

namespace TMS.ApplicationLayer.Tags
{
    public class TagForActivityCreator : ICreator<AddTagToActivityViewModel>
    {
        private readonly IReader<ActivityKey, Activity> _activityReader;
        private readonly IWriter<Activity, ActivityKey> _activityWriter;
        private readonly IReader<TagKey, Tag> _tagReader;

        public TagForActivityCreator(IReader<ActivityKey, Activity> activityReader,
            IReader<TagKey, Tag> tagReader,
            IWriter<Activity, ActivityKey> activityWriter)
        {
            _activityReader = activityReader;
            _tagReader = tagReader;
            _activityWriter = activityWriter;
        }

        public void Create(AddTagToActivityViewModel data)
        {
            var existingActivity = _activityReader.Read(new ActivityKey(data.ActivityId));

            if (!existingActivity.Any())
                throw new InvalidOperationException($"Activity does not exist for id {data.ActivityId}");

            var activity = existingActivity.Single();

            var tags = activity.OfType<Tag>();

            // Don't do anything if tag already exists.
            if (tags.Any(t => t.OfType<TagKey>().Single().Identifier == data.TagToAddId))
                return;

            var tagToAdd = _tagReader.Read(new TagKey(data.TagToAddId));

            if (!tagToAdd.Any())
                throw new InvalidOperationException("Tag to add does not exist");

            _activityWriter.Save(new Activity(activity.Append(tagToAdd.Single()).ToArray()));
        }
    }
}
