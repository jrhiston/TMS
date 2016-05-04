using System;
using System.Collections.Generic;
using TMS.Layer.ModelObjects;
using TMS.ModelLayerInterface.Activities;
using TMS.ModelLayerInterface.People;
using TMS.ModelLayerInterface.People.Data;
using TMS.ModelLayerInterface.People.Decorators;

namespace TMS.ModelLayer.People.Decorators
{
    public class ActionablePerson : DecoratorBase<ActionablePersonData, PersonData>, IActionablePerson
    {
        private readonly List<IActivity> _activities;

        public ActionablePerson(IPerson person, List<IActivity> activities) : base(person)
        {
            if (activities == null)
                throw new ArgumentNullException(nameof(activities));
            
            _activities = activities;
        }

        protected override ActionablePersonData GetData() => new ActionablePersonData
        {
            Activities = _activities
        };
    }
}
