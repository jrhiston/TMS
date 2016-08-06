using System.Collections.Generic;
using System.Linq;
using TMS.Database.Entities.Activities;
using TMS.Database.Entities.Tags;
using TMS.Layer;
using TMS.Layer.Conversion;
using TMS.ModelLayer;
using TMS.ModelLayer.Activities;
using TMS.ModelLayer.Areas;
using TMS.ModelLayer.People;
using TMS.ModelLayer.Tags;

namespace TMS.Database.Converters.Activities
{
    public class ActivityEntityToActivityConverter : IConverter<ActivityEntity, Activity>
    {
        private readonly IConverter<TagEntity, Tag> _tagConverter;

        public ActivityEntityToActivityConverter(IConverter<TagEntity,Tag> tagConverter)
        {
            _tagConverter = tagConverter;
        }

        public Maybe<Activity> Convert(ActivityEntity input)
        {
            var list = new List<IActivityElement>
            {
                new Name(input.Title),
                new Description(input.Description),
                new CreationDate(input.Created),
                new ActivityKey(input.Id),
                new PersonKey(input.OwnerId),
                new AreaKey(input.AreaId)
            };  

            if (input.Tags != null && input.Tags.Any())
                list.AddRange(input.Tags.Select(t => _tagConverter.Convert(t.Tag).Single()));

            return new Maybe<Activity>(new Activity(list.ToArray()));
        }
    }
}
