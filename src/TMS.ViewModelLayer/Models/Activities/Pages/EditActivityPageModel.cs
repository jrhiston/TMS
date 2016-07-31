using System.Collections.Generic;
using TMS.ViewModelLayer.Models.Tags;

namespace TMS.ViewModelLayer.Models.Activities.Pages
{
    public class EditActivityPageModel : ActivityPageModelBase
    {
        public IEnumerable<TagViewModel> Tags { get; set; }
    }
}
