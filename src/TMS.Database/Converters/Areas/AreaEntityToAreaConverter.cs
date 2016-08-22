using System.Collections.Generic;
using System.Linq;
using TMS.Data.Entities.Activities;
using TMS.Data.Entities.Areas;
using TMS.Layer;
using TMS.Layer.Conversion;
using TMS.ModelLayer;
using TMS.ModelLayer.Activities;
using TMS.ModelLayer.Areas;
using TMS.ModelLayer.People;

namespace TMS.Database.Converters.Areas
{
    public class AreaEntityToAreaConverter : IConverter<AreaEntity, Area>
    {
        private readonly IConverter<ActivityEntity, Activity> _activityConverter;

        public AreaEntityToAreaConverter(IConverter<ActivityEntity,Activity> activityConverter)
        {
            _activityConverter = activityConverter;
        }


        public Maybe<Area> Convert(AreaEntity input)
        {
            var list = new List<IAreaElement>
            {
                new AreaKey(input.Id),
                new Name(input.Name),
                new Description(input.Description),
                new CreationDate(input.Created)
            };

            if (input.Activities != null && input.Activities.Any())
                list.AddRange(input.Activities?.Select(a => _activityConverter.Convert(a).SingleOrDefault()));

            if (input.AreaPersons != null && input.AreaPersons.Any())
                list.AddRange(input.AreaPersons?.Select(p => new PersonKey(p.PersonId)));

            return new Maybe<Area>(new Area(list.ToArray()));
        }
    }
}
