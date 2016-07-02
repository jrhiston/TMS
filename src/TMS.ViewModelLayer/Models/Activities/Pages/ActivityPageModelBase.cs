using System;

namespace TMS.ViewModelLayer.Models.Activities.Pages
{
    public abstract class ActivityPageModelBase
    {
        public long Id { get; set; }
        public long AreaId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
    }
}
