using System;
using System.Collections.Generic;
using System.Linq;
using TMS.Layer.Visitors;
using TMS.ModelLayer.TMS.ModelLayerInterface.Areas;
using TMS.ModelLayerInterface.Areas.Data;
using TMS.ViewModelLayer.Models.Activities;
using TMS.ViewModelLayer.Models.People;

namespace TMS.ViewModelLayer.Models.Areas
{
    public class AreaViewModel : 
        IVisitor<AreaData>, 
        IVisitor<PersistableActivitiesAreaData>, 
        IVisitor<PersistableAreaData>,
        IVisitor<AreaWithPeopleData>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public List<ActivityListItemViewModel> Activities { get; }
        public List<PersonListItemViewModel> AssociatedPeople { get; }

        public long Id { get; set; }

        public AreaViewModel()
        {
            Activities = new List<ActivityListItemViewModel>();
            AssociatedPeople = new List<PersonListItemViewModel>();
        }

        public AreaViewModel(IArea area) : this()
        {
            area.Accept(() => this);

            foreach (var activity in Activities)
            {
                activity.AreaId = Id;
            }
        }

        public void Visit(AreaData data)
        {
            Name = data.Name;
            Description = data.Description;
            Created = data.Created;
        }

        public void Visit(PersistableActivitiesAreaData data)
        {
            var activities = data.Activities?
                .Select(activity => new ActivityListItemViewModel(activity))
                .ToList();

            if (activities != null)
                Activities.AddRange(activities);
        }

        public void Visit(PersistableAreaData data)
        {
            Id = data.AreaKey?.Identifier ?? 0;
        }

        public void Visit(AreaWithPeopleData data)
        {
            var associatedPeople = data
                .People?
                .Select(item => new PersonListItemViewModel(item))
                .ToList();

            if (associatedPeople != null)
                AssociatedPeople.AddRange(associatedPeople);
        }
    }
}
