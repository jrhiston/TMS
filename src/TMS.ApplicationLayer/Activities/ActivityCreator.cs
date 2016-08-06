using System;
using System.Collections.Generic;
using TMS.Layer.Creators;
using TMS.Layer.Persistence;
using TMS.ModelLayer;
using TMS.ModelLayer.Activities;
using TMS.ModelLayer.Areas;
using TMS.ModelLayer.People;
using TMS.ViewModelLayer.Models.Activities.Pages;

namespace TMS.ApplicationLayer.Activities
{
    public class ActivityCreator : ICreator<Tuple<ActivityPageModelBase, PersonKey>>
    {
        private readonly IWriter<Activity, ActivityKey> _activityWriter;

        public ActivityCreator(IWriter<Activity, ActivityKey> activityWriter)
        {
            _activityWriter = activityWriter;
        }

        public void Create(Tuple<ActivityPageModelBase, PersonKey> input)
        {
            var model = input.Item1;
            var personKey = input.Item2;

            var list = new List<IActivityElement>
            {
                new Name(model.Name),
                new Description(model.Description),
                new AreaKey(model.AreaId),
                personKey
            };

            if (model.Id > 0)
                list.Add(new ActivityKey(model.Id));
            else
                list.Add(new CreationDate(model.Created));

            _activityWriter.Save(new Activity(list.ToArray()));
        }
    }
}
