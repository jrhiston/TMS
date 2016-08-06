using System;
using System.Collections;
using System.Collections.Generic;
using TMS.ModelLayer;
using TMS.ModelLayer.Activities;
using TMS.ModelLayer.Areas;
using TMS.ModelLayer.People;
using TMS.ViewModelLayer.Models.Activities;
using TMS.ViewModelLayer.Models.People;

namespace TMS.ViewModelLayer.Models.Areas
{
    public class AreaViewModel : AreaVisitorBase
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

        public override IAreaVisitor Visit(AreaKey areaKey)
        {
            Id = areaKey.Identifier;
            return this;
        }

        public override IAreaVisitor Visit(Name name)
        {
            Name = name.Value;
            return this;
        }

        public override IAreaVisitor Visit(CreationDate creationDate)
        {
            Created = creationDate.Value;
            return this;
        }

        public override IAreaVisitor Visit(Activity activity)
        {
            Activities.Add((ActivityListItemViewModel)activity.Accept(new ActivityListItemViewModel()));
            return this;
        }

        public override IAreaVisitor Visit(Description description)
        {
            Description = description.Value;
            return this;
        }

        public override IAreaVisitor Visit(PersonKey personKey)
        {
            AssociatedPeople.Add((PersonListItemViewModel)personKey.Accept(new PersonListItemViewModel()));
            return this;
        }
    }
}
