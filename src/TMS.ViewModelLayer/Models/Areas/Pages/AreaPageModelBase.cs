using System;

namespace TMS.ViewModelLayer.Models.Areas.Pages
{
    public abstract class AreaPageModelBase
    {
        public long AreaId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
    }
}
