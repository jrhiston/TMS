using System.Collections.Generic;
using TMS.ViewModelLayer.Models.Activities;
using TMS.ViewModelLayer.Models.People;

namespace TMS.ViewModelLayer.Models.Areas
{
    public class AreaEditPageModel
    {
        public string AreaName { get; set; }
        public string AreaDescription { get; set; }

        public List<PersonListItemViewModel> AssociatedPeople { get; set; }

        public List<ActivityListItemViewModel> Activities { get; set; }

        public AreaEditPageModel()
        {
            AssociatedPeople = new List<PersonListItemViewModel>();
            Activities = new List<ActivityListItemViewModel>();
        }
    }
}
