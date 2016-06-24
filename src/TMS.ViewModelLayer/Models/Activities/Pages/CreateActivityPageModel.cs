using System;

namespace TMS.ViewModelLayer.Models.Activities.Pages
{
    public class CreateActivityPageModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }

        public long AreaId { get; set; }
    }
}
