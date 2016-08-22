using System.Linq;
using TMS.Data.Entities.Activities;
using TMS.Data.Entities.Areas;
using TMS.Data.Entities.PeopleAreas;
using TMS.Layer.Builders;
using TMS.Layer.Extensions;
using TMS.ModelLayer;
using TMS.ModelLayer.Activities;
using TMS.ModelLayer.Areas;
using TMS.ModelLayer.People;

namespace TMS.Database.Builders.Areas
{
    public class AreaEntityBuilder : AreaVisitorBase, IEntityBuilder<Area, AreaEntity>
    {
        private AreaEntity _entity;
        private readonly IEntityBuilder<Activity, ActivityEntity> _activityEntityBuilder;

        public AreaEntityBuilder(IEntityBuilder<Activity,ActivityEntity> activityEntityBuilder)
        {
            _activityEntityBuilder = activityEntityBuilder;
        }

        public override IAreaVisitor Visit(Name name)
        {
            _entity.Name = name.Value;
            return this;
        }

        public override IAreaVisitor Visit(PersonKey personKey)
        {
            var existing = _entity.AreaPersons.FirstOrDefault(ap => ap.PersonId == personKey.Identifier);

            if (existing == null)
                _entity.AreaPersons.Add(CreateLink(personKey));

            return this;
        }

        public override IAreaVisitor Visit(Description description)
        {
            _entity.Description = description.Value;
            return this;
        }

        public override IAreaVisitor Visit(CreationDate creationDate)
        {
            _entity.Created = creationDate.Value;
            return this;
        }

        public override IAreaVisitor Visit(AreaKey areaKey)
        {
            _entity.Id = areaKey.Identifier;
            return this;
        }

        public override IAreaVisitor Visit(Activity activity)
        {
            var existing = _entity.Activities.FirstOrDefault(a => a.Id == activity.OfType<ActivityKey>().FirstOrDefault()?.Identifier);

            if (existing == null)
                _entity.Activities.Add(_activityEntityBuilder.Create(activity));
            else
                _activityEntityBuilder.Update(activity, existing);

            return this;
        }

        public AreaEntity Create(Area data)
        {
            _entity = new AreaEntity();

            data.Accept(this);

            return _entity;
        }

        public void Update(Area data, AreaEntity existing)
        {
            _entity = existing;

            existing.Activities.DeleteMissing(data.OfType<Activity>(), (t, e) => t.OfType<ActivityKey>().Single().Identifier == e.Id);
            existing.AreaPersons.DeleteMissing(data.OfType<PersonKey>(), (p, e) => p.Identifier == e.PersonId);

            data.Accept(this);
        }

        private PeopleAreasEntity CreateLink(PersonKey key) => new PeopleAreasEntity
        {
            PersonId = key.Identifier,
            AreaId = _entity.Id
        };
    }
}
